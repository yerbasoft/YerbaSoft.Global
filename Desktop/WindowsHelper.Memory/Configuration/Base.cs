using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsHelper.Memory.Configuration
{
    internal abstract class Base
    {
        internal abstract string TypeName { get; }

        [YerbaSoft.DTO.Mapping.Direct]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [YerbaSoft.DTO.Mapping.Direct]
        public string Name { get; set; }

        [YerbaSoft.DTO.Mapping.Direct]
        public string Icon { get; set; }

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
                        var icoFile = new System.IO.FileInfo(this.Icon);

                        if (icoFile.Exists)
                        {
                            if (icoFile.Extension == ".exe")
                                img = System.Drawing.Icon.ExtractAssociatedIcon(this.Icon).ToBitmap();
                            else
                                img = System.Drawing.Image.FromFile(this.Icon);
                        }
                        else
                        {
                            var res = (System.Drawing.Icon)WindowsHelper.Memory.Properties.Resources.ResourceManager.GetObject(this.Icon);
                            if (res != null)
                                img = res.ToBitmap();
                        }
                    }
                    catch (Exception ex)
                    {
                        Global.Log(ex);
                    }
                }

                return img ?? Memory.DefaultIcon.ToBitmap();
            }
        }

        internal virtual ToolStripMenuItem GetMenu()
        {
            var m = new ToolStripMenuItem(this.Name);
            m.Tag = this;
            m.Image = this.Image;
            m.Click += OnMenuClick;

            return m;
        }

        private void OnMenuClick(object sender, EventArgs e)
        {
            var info = (Configuration.Base)((ToolStripItem)sender).Tag;

            Global.Log($"{Memory.AppName} :: {info.Name} :: OnClick :: Start");

            Thread thread = new Thread(() => { info.Run(); });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
