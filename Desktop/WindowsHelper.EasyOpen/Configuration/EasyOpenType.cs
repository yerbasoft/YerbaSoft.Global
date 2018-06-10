using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHelper.EasyOpen.Configuration
{
    internal abstract class EasyOpenType
    {
        internal abstract string TypeName { get; }

        [YerbaSoft.DTO.Mapping.Direct]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [YerbaSoft.DTO.Mapping.Direct]
        public string Name { get; set; }

        [YerbaSoft.DTO.Mapping.Direct]
        public virtual string Icon { get; set; }

        internal abstract void Run();
        
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

                return img ?? EasyOpen.DefaultIcon.ToBitmap();
            }
        }

        internal virtual ToolStripItem GetMenu()
        {
            var m = new ToolStripMenuItem(this.Name);
            m.Tag = this;
            m.Image = this.Image;
            m.Click += OnMenuClick;

            return m;
        }

        private void OnMenuClick(object sender, EventArgs e)
        {
            var info = (Configuration.EasyOpenType)((ToolStripItem)sender).Tag;

            Global.Log($"{EasyOpen.AppName} :: {info.Name} :: OnClick :: Start");

            try
            {
                Task.Run(() => {
                    try
                    {
                        info.Run();
                        Global.Log($"{EasyOpen.AppName} :: {info.Name} :: OnClick :: Finish");
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
    }
}
