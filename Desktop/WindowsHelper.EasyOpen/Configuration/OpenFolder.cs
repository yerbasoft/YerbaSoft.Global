using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.EasyOpen.Configuration
{
    internal class OpenFolder : EasyOpenType
    {
        internal override string TypeName => "OpenFolder";

        [YerbaSoft.DTO.Mapping.Direct]
        public string Path { get; set; }

        private string _Icon;
        [YerbaSoft.DTO.Mapping.Direct]
        public override string Icon
        {
            get => _Icon = _Icon ?? @"C:\Windows\explorer.exe";
            set => _Icon = value;
        }

        internal override void Run()
        {
            var path = this.Path;
            if (path.StartsWith(@".\"))
                path = System.IO.Path.Combine(Config.AppPath, path.Substring(2));

            var pi = new ProcessStartInfo("explorer.exe")
            {
                WorkingDirectory = System.IO.Path.GetDirectoryName(path),
                Arguments = path,
                UseShellExecute = true
            };
            Process.Start(pi);
        }
    }
}
