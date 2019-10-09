using CSWork.DTO.GlobalConfigs;
using CSWork.DTO.JiraObjs;
using CSWork.DTO.WorkDatas;
using CSWork.Interface.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWork.Interface.Model
{
    public class MenuBuilder
    {
        private ContextMenuStrip MainMenu;
        private BLL.Managers.Config Config => BLL.Factory.Config;
        private Utils Utils { get; set; }

        public MenuBuilder(ContextMenuStrip mainMenu, Utils utils)
        {
            this.MainMenu = mainMenu;
            this.Utils = utils;

            BLL.Factory.Work.OnWorkingIssuesListChange += (sender, e) => ReloadWorkMenu();

            ReloadMemoryMenu();
            ReloadAmbientesMenu();
            ReloadAlarmasMenu();
            ReloadWorkMenu();
            ReloadLinkMenu();
        }

        public void ReloadMemoryMenu()
        {
            var mMemory = this.MainMenu.Items.OfType<ToolStripMenuItem>().Single(p => p.Name == "mMemory");

            if (!Config.Global.General.ModuleMemory)
            {
                mMemory.Visible = false;
                return;
            }
            mMemory.Visible = true;

            mMemory.RemoveMenus(p => p.Tag != null);

            foreach(var group in Config.Global.Memory.Select(p => p.Group).Distinct().OrderBy(p => p))
            {
                var mGroup = new ToolStripMenuItem(group, Resources.note.ToBitmap());
                mGroup.Tag = group;

                foreach(var item in Config.Global.Memory.Where(p => p.Group == group).OrderBy(p => p.Key))
                {
                    var menu = new ToolStripMenuItem(item.Key, Resources.note.ToBitmap(), (sender, e) => { Clipboard.SetText(Utils.GetTag<string>(sender)); }).Do(m => { m.Tag = item.Value; });
                    mGroup.DropDownItems.Add(menu);
                }

                mMemory.DropDownItems.Add(mGroup);
            }
        }

        public void ReloadAmbientesMenu()
        {
            var mAmbientes = this.MainMenu.Items.OfType<ToolStripMenuItem>().Single(p => p.Name == "mAmbientes");

            if (!Config.Global.General.ModuleAmbiente)
            {
                mAmbientes.Visible = false;
                return;
            }
            mAmbientes.Visible = true;

            mAmbientes.RemoveMenus(p => p.Tag != null);

            foreach (var oAmbiente in Config.Global.Ambientes.OrderBy(p => p.Name))
            {
                var mAmbiente = new ToolStripMenuItem(oAmbiente.Name, Resources.data.ToBitmap());
                mAmbiente.Tag = oAmbiente;

                // open Explorer
                if (oAmbiente.AllowExplorer)
                    mAmbiente.DropDownItems.Add(this.Utils.Menu.CreateCmdMenu("Abrir en Explorer", oAmbiente.GetCmdExplorer(Config.Global.General.GCBARed), Resources.data_next.ToBitmap()));

                // open Remote Desktop
                if (oAmbiente.AllowRemote)
                    mAmbiente.DropDownItems.Add(this.Utils.Menu.CreateCmdMenu("Remote Desktop", oAmbiente.GetCmdRemoteDesktop(Config.Global.General.GCBARed), Resources.data_view.ToBitmap()));

                // separator & urls
                if ((oAmbiente.AllowExplorer || oAmbiente.AllowRemote ) && oAmbiente.Webs.Count > 0)
                    mAmbiente.DropDownItems.Add(new ToolStripSeparator());

                // Sitios
                foreach (var item in oAmbiente.Webs.OrderBy(p => p.Name))
                    mAmbiente.DropDownItems.Add(this.Utils.Menu.CreateOpenUrlMenu(item.Name, $"http://{oAmbiente.WebServerIP}{item.RelativeUrl}"));

                mAmbientes.DropDownItems.Add(mAmbiente);
            }
        }

        public void ReloadAlarmasMenu()
        {
            var mAlarmas = this.MainMenu.Items.OfType<ToolStripMenuItem>().Single(p => p.Name == "mAlarmas");

            if (!Config.Global.General.ModuleAlarma)
            {
                mAlarmas.Visible = false;
                return;
            }
            mAlarmas.Visible = true;

            return;
        }

        public void ReloadWorkMenu()
        {
            var mStartWork = this.MainMenu.Items.OfType<ToolStripMenuItem>().Single(p => p.Name == "mStartWork");

            var mStartWorkWithoutName = (ToolStripMenuItem)mStartWork.DropDownItems["mStartWorkWithoutName"];
            mStartWorkWithoutName.Visible = Config.Global.Work.AllowTaskWithoutIssue;

            // Start Work
            mStartWork.RemoveMenus(p => p.Tag != null);
            foreach(var oFilter in Config.Global.Work.Filters.OrderBy(p => p.Name))
            {
                var mFilter = new ToolStripMenuItem(oFilter.Name, Resources.funnel.ToBitmap());
                mFilter.Tag = oFilter;
                mFilter.DropDownOpening += (sender, e) =>
                {
                    ((ToolStripMenuItem)sender).RemoveMenus();
                    foreach (var oIssue in BLL.Factory.Jira.Search(sender.GetTag<DTO.GlobalConfigs.JiraFilter>().SearchUrl, true))
                    {
                        var mIssue = CreateIssueMenu(new DTO.WorkDatas.Issue(oIssue));

                        // agrego menú "Comenzar a Trabajar"
                        if (!BLL.Factory.Work.IsWorkingOn(oIssue.key))
                        {
                            var mTakeWork = new ToolStripMenuItem("Comenzar a Trabajar", Resources.media_play.ToBitmap(), (sender2, e2) =>
                            {
                                BLL.Factory.Work.StartIssue(sender2.GetTag<DTO.JiraObjs.Issue>());
                            }).Do(m => m.Tag = oIssue);
                            mIssue.DropDownItems.Insert(0, new ToolStripSeparator());
                            mIssue.DropDownItems.Insert(0, mTakeWork);
                        }

                        ((ToolStripMenuItem)sender).DropDownItems.Add(mIssue);
                    }
                };

                mStartWork.DropDownItems.Add(mFilter);
            }

            // Working
            var mWorking = this.MainMenu.Items.OfType<ToolStripMenuItem>().Single(p => p.Name == "mWorking");
            mWorking.RemoveMenus(p => p.Tag != null);
            foreach (var oIssue in BLL.Factory.Work.GetWorkingOn().OrderBy(p => p.Priority).ThenBy(p => p.Key))
            {
                mWorking.DropDownItems.Add(CreateIssueMenu(oIssue));
            }

        }

        internal void ReloadLinkMenu()
        {
            // Armar menú de Links
            var mainmenu = this.MainMenu.Items.OfType<ToolStripMenuItem>().Single(p => p.Name == "mLinks");
            mainmenu.Visible = Config.Global.General.ModuleLink;

            mainmenu.DropDownItems.Clear();
            if (Config.Global.General.ModuleLink)
                ReloadLinkMenu(mainmenu, Config.Global.Link);
        }

        private void ReloadLinkMenu(ToolStripMenuItem menu, Link link)
        {
            menu.Image = Recursos.GetImage(link.Icon);
            menu.Text = link.Name;
            menu.Tag = link;

            foreach(var l in link.SubLinks)
            {
                if (l.IsSeparator)
                    menu.DropDownItems.Add(new ToolStripSeparator());
                else 
                {
                    var m = new ToolStripMenuItem();
                    ReloadLinkMenu(m, l);
                    menu.DropDownItems.Add(m);
                }
            }

            if (link.IsFolder)
            {
                if (!link.ShowFolderContent)
                {
                    menu.Click += (sender, e) => Utils.Action.DoLink(sender.GetTag<Link>());
                    return;
                }
                
                menu.DropDownOpening += (sender, e) => { Utils.Menu.CreateSubFoldersMenu((ToolStripMenuItem)sender, sender.GetTag<Link>(), new System.IO.DirectoryInfo(sender.GetTag<Link>().Path) ); };
            }
            else
            {
                menu.Click += (sender, e) => Utils.Action.DoLink(sender.GetTag<Link>());
            }
        }


        #region Menu Create Helpers

        private ToolStripMenuItem CreateIssueMenu(DTO.WorkDatas.Issue issue)
        {
            var menu = new ToolStripMenuItem();
            menu.Tag = issue;

            issue.OnChangeData += (i, c) => ReLoadIssueMenu(menu, i);
            ReLoadIssueMenu(menu, issue);

            return menu;
        }

        private void ReLoadIssueMenu(ToolStripMenuItem menu, DTO.WorkDatas.Issue issue)
        {
            this.Utils.Safe(this.MainMenu, () =>
            {
                menu.Text = $"{issue.Key} :: {issue.Summary}";
                menu.Image = (Recursos.Get<Icon>($"Priority{issue.Priority}") ?? Resources.refresh).ToBitmap();

                // Ver
                if (!menu.SubMenus(p => p.Text == "Ver").Any())
                    menu.DropDownItems.Add(new ToolStripMenuItem("Ver", Resources.scroll_view.ToBitmap(), (sender, e) => this.Utils.Action.OpenIssue(sender.GetTag<DTO.WorkDatas.Issue>())).Do(m => m.Tag = issue));

                // Cargar Horas
                if (!menu.SubMenus(p => p.Text == "Registrar Trabajo").Any())
                    menu.DropDownItems.Add(new ToolStripMenuItem("Registrar Trabajo", Resources.stopwatch.ToBitmap(), (sender, e) =>
                        this.Utils.Safe(this.Utils.MainForm, () => { new Forms.Tools.RegisterWork(sender.GetTag<string>()).ShowDialog(); })).Do(m => m.Tag = issue.Key)
                    );

                // Abrir en Explorador
                if (!menu.SubMenus(p => p.Text == "Abrir en Explorador").Any())
                    menu.DropDownItems.Add(this.Utils.Menu.CreateOpenUrlMenu("Abrir en Explorador", BLL.Factory.Jira.Config.GetIssueUrl(issue.Key)));

                // Adjuntos (index:1)
                var mAdjuntos = menu.SubMenus(p => p.Text == "Adjuntos").SingleOrDefault();
                if (mAdjuntos == null)
                    menu.DropDownItems.Add(mAdjuntos = new ToolStripMenuItem("Adjuntos", Resources.books.ToBitmap()));
                mAdjuntos.Visible = issue.Adjuntos.Count > 0;

                if (issue.Adjuntos.Count > 0)
                {
                    mAdjuntos.RemoveMenus(p => !issue.Adjuntos.Select(a => a.Filename).Contains(((DTO.WorkDatas.Attachment)p.Tag).Filename));   // elimino los menús de archivos que ya no están mas

                    foreach (var adj in issue.Adjuntos.Where(p => !mAdjuntos.SubMenus().Select(a => ((DTO.WorkDatas.Attachment)a.Tag).Filename).Contains(p.Filename)))
                    {
                        mAdjuntos.DropDownItems.Add(
                            this.Utils.Menu.CreateOpenUrlMenu(adj.Filename, adj.Content, Recursos.GetImageForFile(adj.Filename, adj.MimeType)).Do(m => m.Tag = adj)
                        );
                    }
                }

                // Transiciones (index:2)
                var mTransicion = menu.SubMenus(p => p.Text == "Mover").SingleOrDefault();
                if (mTransicion == null)
                    menu.DropDownItems.Add(mTransicion = new ToolStripMenuItem("Mover", Resources.navigate_right.ToBitmap()));
                mTransicion.Visible = (issue.Transitions?.Count ?? 0) > 0;

                if ((issue.Transitions?.Count ?? 0) > 0)
                {
                    foreach (var m in mTransicion.SubMenus())   // oculto todos los submenús
                        m.Visible = false;

                    foreach (var tran in issue.Transitions)
                    {
                        var mExists = mTransicion.SubMenus(m => ((DTO.WorkDatas.Transition)m.GetTag<dynamic>().tran).Id == tran.Id).SingleOrDefault();

                        if (mExists != null)
                        {
                            mExists.Visible = true;
                        }
                        else
                        {
                            mTransicion.DropDownItems.Add(this.Utils.Menu.CreateTransitionMenu(issue, tran));
                        }
                    }
                }
            });
        }

        #endregion

        #region Commons / Helpers

        #endregion
    }
}
