using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.EasyOpen.Configuration
{
    internal class OpenFile : EasyOpenType
    {
        internal override string TypeName => "OpenFile";
        
        [YerbaSoft.DTO.Mapping.Direct]
        public string Path { get; set; }

        [YerbaSoft.DTO.Mapping.Direct]
        public string Params { get; set; }

        private string _Icon;
        [YerbaSoft.DTO.Mapping.Direct]
        public override string Icon
        {
            get => _Icon = _Icon ?? Global.GetIconByExtension(new System.IO.FileInfo(Path).Extension);
            set => _Icon = value;
        }

        protected override Image Image
        {
            get
            {
                var img = base.Image;
                if (img == EasyOpen.DefaultIcon.ToBitmap())
                {
                    var f = new System.IO.FileInfo(Path);
                    var icon = Global.GetIconByExtension(f.Extension);
                    if (icon != null)
                    {
                        this.Icon = icon;   // cambio el path del ícono por el establecido por la extensión (ésto NO sobreescribe si hay un path específico configurado)
                        return base.Image;
                    }
                }
                return img;
            }
        }

        internal override void Run()
        {
            var path = this.Path;
            if (path.StartsWith(@".\"))
                path = System.IO.Path.Combine(Config.AppPath, path.Substring(2));

            var pi = new ProcessStartInfo(path)
            {
                WorkingDirectory = System.IO.Path.GetDirectoryName(path),
                Arguments = this.Params,
                UseShellExecute = true,
                Verb = "OPEN"
            };
            Process.Start(pi);
        }
    }
}
