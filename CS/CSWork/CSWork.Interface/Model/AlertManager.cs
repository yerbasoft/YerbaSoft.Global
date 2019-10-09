using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSWork.DTO.WorkDatas;
using CSWork.Interface.Properties;

namespace CSWork.Interface.Model
{
    public class AlertManager
    {
        private Utils Utils { get; set; }

        public AlertManager(Utils utils)
        {
            this.Utils = utils;
            if (BLL.Factory.Config.Global.General.ModuleAlarma)
                StartService();

            BLL.Factory.Config.Global.General.OnModuleAlarmaChange += (value) => { if (value) StartService(); else StopService(); };
        }

        private void StartService()
        {
            BLL.Factory.Cache.OnIssueChangeData += OnIssueChangeData;
        }

        private void StopService()
        {
            BLL.Factory.Cache.OnIssueChangeData -= OnIssueChangeData;
        }

        public void ShowNotification(Forms.Notification.NotificationType info)
        {
            if (!BLL.Factory.Config.Global.General.ModuleAlarma)
                return;

            // para que corra en otro thread y se cierre al cerrarse la ventana
            new Thread((obj) =>
            {
                Application.Run(new Forms.Notification((Forms.Notification.NotificationType)obj, this.Utils));
            }).Start(info);
        }

        private void OnIssueChangeData(object sender, IEnumerable<Issue.Changes> changes)
        {
            var issue = (Issue)sender;

            string header = null;
            string body = "";

            var actions = new List<Forms.Notification.NotificationAction>()
            {
                new Forms.Notification.NotificationAction()
                {
                    Text = "Ver",
                    Image = Resources.scroll_view.ToBitmap(),
                    OnClick = (a) => this.Utils.Action.OpenIssue((Issue)a.Tag),
                    Tag = issue
                },
                new Forms.Notification.NotificationAction()
                {
                    Text = "Abrir",
                    Image = Resources.earth_view.ToBitmap(),
                    OnClick = (a) => {
                        this.Utils.Action.DoOpenUrl(BLL.Factory.Jira.Config.GetIssueUrl((string)a.Tag));
                    },
                    Tag = issue.Key
                }
            };


            foreach (var change in changes)
            {
                bool show = false;
                if (change.Property == "Priority" && BLL.Factory.Config.Global.Alarmas.IssuePriorityChanged) show = true;
                if (change.Property == "Adjuntos" && BLL.Factory.Config.Global.Alarmas.IssueAdjuntoChanged) show = true;
                if (change.Property == "Comments" && BLL.Factory.Config.Global.Alarmas.IssueCommentChanged) show = true;

                if (show)
                {
                    if (header != null)
                        header = Recursos.Get<string>($"MsgIssueChangeHeader");
                    else
                        header = Recursos.Get<string>($"MsgIssueChangeHeader_{change.Property}");

                    var content = Recursos.Get<string>($"MsgIssueChangeBody_{change.Property}");

                    string insert = null;
                    string delete = null;
                    string update = null;
                    if (change.OldValue == null && change.NewValue != null)
                        insert = Recursos.Get<string>($"MsgIssueChangeBody_{change.Property}_insert");
                    if (change.OldValue != null && change.NewValue == null)
                        delete = Recursos.Get<string>($"MsgIssueChangeBody_{change.Property}_delete");
                    if (change.OldValue != null && change.NewValue != null)
                        update = Recursos.Get<string>($"MsgIssueChangeBody_{change.Property}_update");

                    content = content.Replace("{update}", update)
                                     .Replace("{delete}", delete)
                                     .Replace("{insert}", insert)
                                     .Replace("{old}", change.OldValue?.ToString())
                                     .Replace("{new}", change.NewValue?.ToString());

                    body += content;



                    // Acciones especiales
                    if (change.Property == "Adjuntos" && change.OldValue == null && change.NewValue != null)
                    {
                        actions.Add(new Forms.Notification.NotificationAction()
                        {
                            Text = change.NewValue.ToString(),
                            Image = Resources.book_blue_find.ToBitmap(),
                            Tag = new { issue, file = change.NewValue },
                            OnClick = (obj) => this.Utils.Action.DoOpenUrl(((Issue)((dynamic)obj.Tag).issue).GetAdjunto((string)((dynamic)obj.Tag).file).Content)
                        });
                    }
                }
            }

            if (header == null) // nada que mostrar
                return;

            header = header.Replace("{issue}", issue.Key);

            var info = new Forms.Notification.NotificationType()
            {
                Header = header,
                Body = body,
                Image = Resources.scroll_refresh.ToBitmap(),
                TimerToClose = null,
                Actions = actions
            };

            ShowNotification(info);

        }

    }
}
