using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSWork.DTO.GlobalConfigs;
using CSWork.DTO.WorkDatas;
using CSWork.Interface.Forms;
using CSWork.Interface.Properties;

namespace CSWork.Interface.Model
{
    public class Utils
    {
        public class Actions
        {
            public Utils Utils { get; }

            public Actions(Utils utils)
            {
                this.Utils = utils;
            }

            /// <summary>
            /// Ejecuta la transición de un issue
            /// </summary>
            /// <param name="issue"></param>
            /// <param name="transition"></param>
            public void DoIssueTransition(DTO.WorkDatas.Issue issue, DTO.WorkDatas.Transition transition)
            {
                // Realizar la transicion de estados
                // ¿pedir comentarios?


                var obj = DTO.JiraObjs.Comments.Factory.GetHeader(new DTO.JiraObjs.Comments.IContent[]
                {
                    new DTO.JiraObjs.Comments.Paragraph( new DTO.JiraObjs.Comments.Text("texto descriptivo mínimo"))
                });


                BLL.Factory.Jira.IssueTransition(issue.Key, transition.Id, obj);
            }
            
            /// <summary>
            /// Abre una URL en el explorador
            /// </summary>
            /// <param name="url"></param>
            public void DoOpenUrl(string url)
            {
                if (string.IsNullOrEmpty(BLL.Factory.Config.Global.General.App.Web))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true, Verb = "OPEN" });
                }
                else
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(BLL.Factory.Config.Global.General.App.Web) { UseShellExecute = true, Arguments = url });
                }
            }

            /// <summary>
            /// Ejecuta el comando CMD.EXE con los comandos especificados
            /// </summary>
            /// <param name="commands"></param>
            public void DoRunCmd(string commands)
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = false;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                foreach (var c in (commands ?? "").Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    cmd.StandardInput.WriteLine(c.Trim());
                    cmd.StandardInput.Flush();
                    Application.DoEvents();
                }
                cmd.StandardInput.Close();
                cmd.WaitForExit();
            }

            /// <summary>
            /// Abre la pantalla de visualización de Issue
            /// </summary>
            /// <param name="issue"></param>
            public void OpenIssue(Issue issue)
            {
                this.Utils.Safe(this.Utils.MainForm, () => { (new Forms.IssueForm(issue, this.Utils)).Show(); });
            }

            public void DoLink(Link link)
            {
                if (link.IsFile || link.IsFolder)
                {
                    DoOpenFile(link.Path);
                }
            }

            internal void DoOpenFile(string filepath)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filepath) { UseShellExecute = true, Verb = "OPEN" });
            }
        }

        public class Menus
        {
            public Utils Utils { get; }

            public Menus(Utils utils)
            {
                this.Utils = utils;
            }

            /// <summary>
            /// Crea un nuevo menú que abrirá una url en un explorador
            /// </summary>
            public ToolStripMenuItem CreateOpenUrlMenu(string text, string url, Image image = null)
            {
                var menu = new ToolStripMenuItem(text, image ?? Resources.earth_view.ToBitmap());
                menu.Tag = url;
                menu.Click += (sender, e) => this.Utils.Action.DoOpenUrl(this.Utils.GetTag<string>(sender));
                return menu;
            }

            /// <summary>
            /// Crea un nuevo menú que ejecutará una línea de comandos
            /// </summary>
            public ToolStripMenuItem CreateCmdMenu(string text, string commands, Image image = null)
            {
                var menu = new ToolStripMenuItem(text, image ?? Resources.nut_and_bolt.ToBitmap());
                menu.Tag = commands;
                menu.Click += (sender, e) => this.Utils.Action.DoRunCmd(this.Utils.GetTag<string>(sender));
                return menu;
            }

            public ToolStripMenuItem CreateTransitionMenu(Issue issue, Transition tran)
            {
                return new ToolStripMenuItem(tran.Name, Resources.navigate_right.ToBitmap(), (obj, e2) =>
                {
                    this.Utils.Action.DoIssueTransition(obj.GetTag<dynamic>().issue, obj.GetTag<dynamic>().tran);
                }).Do(m => { m.Tag = new { issue, tran }; });
            }

            public void CreateSubFoldersMenu(ToolStripMenuItem mainmenu, Link link, System.IO.DirectoryInfo dir)
            {
                if (!dir.Exists)
                    return;

                var subdirs = new System.IO.DirectoryInfo[0];
                if (link.ShowSubFolders)
                {
                    subdirs = dir.GetDirectories("*", System.IO.SearchOption.TopDirectoryOnly);
                }

                mainmenu.DropDownItems.Clear();
                if (link.ShowOpenFolder)
                {
                    mainmenu.DropDownItems.Add(new ToolStripMenuItem("Abrir Carpeta", Resources.Open_Folder_yellow.ToBitmap(), (sender, e) => {
                        Utils.Action.DoOpenFile(sender.GetTag<string>());
                    }).Do((m) => { m.Tag = dir.FullName; }));

                    mainmenu.DropDownItems.Add(new ToolStripSeparator());
                }

                foreach(var subdir in subdirs.OrderBy(p => p.FullName))
                {
                    var mSubdir = new ToolStripMenuItem();
                    mSubdir.Text = subdir.Name;
                    mSubdir.Image = Recursos.GetImage(link.Icon);
                    mSubdir.Tag = link;
                    mSubdir.DropDownOpening += (sender, e) => { CreateSubFoldersMenu((ToolStripMenuItem)sender, sender.GetTag<Link>(), subdir); };

                    mainmenu.DropDownItems.Add(mSubdir);
                }

                AgregateFilesMenu(mainmenu, link.FolderFileFilter, dir);
            }

            private void AgregateFilesMenu(ToolStripMenuItem mainmenu, string pattern, System.IO.DirectoryInfo dir)
            {
                var files = dir.GetFiles(pattern, System.IO.SearchOption.TopDirectoryOnly);
                foreach(var file in files.OrderBy(p => p.FullName))
                {
                    var menu = new ToolStripMenuItem(file.Name, Recursos.GetImage(file.FullName), (sender, e) => { Utils.Action.DoOpenFile(sender.GetTag<string>()); });
                    menu.Tag = file.FullName;
                    mainmenu.DropDownItems.Add(menu);
                }
            }
        }

        public class Animations
        {
            public Utils Utils { get; }

            public Animations(Utils utils)
            {
                this.Utils = utils;
            }

            /// <summary>
            /// Ejecuta la animación de "Aparecer/Desaparecer"
            /// </summary>
            /// <param name="control">formulario</param>
            /// <param name="toOpacity">valor de opacidad final</param>
            /// <param name="onterminate">evento que se ejecutará al terminar la animación</param>
            /// <param name="rate">taza de salto de opacidad</param>
            /// <param name="sleep">tiempo entre salto y salto de opacidad</param>
            public void AnimationOpacity(Form control, double toOpacity, EventHandler onterminate, double rate = 0.04, int sleep = 100)
            {
                new Thread((obj) =>
                {
                    var _control = (Form)((dynamic)obj).control;
                    var _opacity = (double)((dynamic)obj).toOpacity;
                    var _onTerminate = (EventHandler)((dynamic)obj).onterminate;
                    var _rate = (double)((dynamic)obj).rate;
                    var _sleep = (int)((dynamic)obj).sleep;

                    var _factor = (_control.Opacity > _opacity) ? -1d : 1d;
                    while (true)
                    {
                        this.Utils.Safe(_control, () => { _control.Opacity += _factor * _rate; });

                        if ((control.Opacity >= _opacity && _factor > 0) ||
                            (control.Opacity <= _opacity && _factor < 0))
                            break;

                        Thread.Sleep(_sleep);
                    }

                    _onTerminate?.Invoke(control, null);
                }).Start(new { control, toOpacity, onterminate, rate, sleep });
            }
        }

        public class Works
        {
            public static Forms.Tools.FindIssue FindIssueForm;
            public Utils Utils { get; }

            public Works(Utils utils)
            {
                this.Utils = utils;
            }

            public void FindIssue()
            {
                if (FindIssueForm != null)
                {
                    FindIssueForm.Focus();
                    return;
                }

                using(FindIssueForm = new Forms.Tools.FindIssue(this.Utils))
                {
                    FindIssueForm.ShowDialog();
                }
                FindIssueForm = null;
            }
        }

        public Form MainForm;

        public Actions Action { get; }
        public Menus Menu { get; }
        public Animations Animation { get; }
        public Works Work { get; }

        public Utils(Form mainForm)
        {
            this.MainForm = mainForm;
            this.Action = new Actions(this);
            this.Menu = new Menus(this);
            this.Animation = new Animations(this);
            this.Work = new Works(this);
        }

        public void Safe(Control control, MethodInvoker safe)
        {
            if (control.InvokeRequired)
                control.Invoke(safe, null);
            else
                safe.Invoke();
        }

        public T GetTag<T>(object sender)
        {
            return (T)((dynamic)sender).Tag;
        }
    }
}
