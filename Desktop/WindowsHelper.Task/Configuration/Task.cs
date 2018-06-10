using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.Task.Configuration
{
    internal class Task
    {
        [YerbaSoft.DTO.Mapping.Direct]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [YerbaSoft.DTO.Mapping.Direct]
        public string Name { get; set; }

        [YerbaSoft.DTO.Mapping.Direct]
        public string Icon { get; set; }
        
        [YerbaSoft.DTO.Mapping.SubClass]
        public Triggers Triggers { get; set; }

        [YerbaSoft.DTO.Mapping.SubClass]
        public Actions Actions { get; set; }

        /// <summary>
        /// Devuelve la imágen correspondiente a éste menú
        /// </summary>
        protected virtual System.Drawing.Image Image
        {
            get
            {
                System.Drawing.Image img = null;
                if (!string.IsNullOrEmpty(this.Icon))
                {
                    try
                    {
                        var path = this.Icon;
                        if (path.StartsWith(@".\"))
                            path = System.IO.Path.Combine(Config.AppPath, path.Substring(2));

                        var icoFile = new System.IO.FileInfo(path);

                        if (icoFile.Extension.ToLower() == ".exe")
                            img = System.Drawing.Icon.ExtractAssociatedIcon(path).ToBitmap();
                        else
                            img = System.Drawing.Image.FromFile(path);
                    }
                    catch (Exception ex)
                    {
                        Global.Log(ex);
                    }
                }

                return img ?? WindowsHelper.Task.Task.DefaultIcon.ToBitmap();
            }
        }
        
        public bool IsRunning { get; private set; } = false;

        private ToolStripItem Menu { get; set; }

        internal virtual ToolStripItem GetMenu()
        {
            this.Menu = this.Menu ?? new ToolStripMenuItem(this.Name);
            this.Menu.Tag = this;
            this.Menu.Image = this.Image;
            this.Menu.Click += OnMenuClick;

            return this.Menu;
        }

        private void OnMenuClick(object sender, EventArgs e)
        {
            var info = (Configuration.Task)((ToolStripItem)sender).Tag;

            Global.Log($"{WindowsHelper.Task.Task.AppName} :: {info.Name} :: OnClick :: Start");

            try
            {
                System.Threading.Tasks.Task.Run(() => {
                    try
                    {
                        info.MenuClick();
                        Global.Log($"{WindowsHelper.Task.Task.AppName} :: {info.Name} :: OnClick :: Finish");
                    }
                    catch (Exception ex)
                    {
                        Global.Log(ex);
                    }
                });
            }
            catch (Exception ex)
            {
                Global.Log(ex);
            }
        }

        #region Main Events

        internal void Start()
        {
            this.IsRunning = true;
        }
        internal void Stop()
        {
            this.IsRunning = false;
        }
        internal void MenuClick()
        {

        }

        #endregion
    }
}
