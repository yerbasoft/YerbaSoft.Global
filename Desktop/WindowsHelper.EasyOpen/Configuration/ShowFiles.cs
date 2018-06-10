using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using YerbaSoft.DTO;

namespace WindowsHelper.EasyOpen.Configuration
{
    [YerbaSoft.DTO.Mapping.AutoMapping]
    internal class ShowFiles : EasyOpenType
    {
        internal override string TypeName => "ShowFiles";

        [YerbaSoft.DTO.Mapping.Direct]
        public string Path { get; set; }

        [YerbaSoft.DTO.Mapping.Direct(UseComplexConvert = true)]
        public bool OpenFolder { get; set; }

        [YerbaSoft.DTO.Mapping.Direct(UseComplexConvert = true)]
        public bool ShowSubFolders { get; set; }

        [YerbaSoft.DTO.Mapping.Direct]
        public string FileFilter { get; set; }

        [YerbaSoft.DTO.Mapping.Direct(UseComplexConvert = true)]
        public bool? SortByModiFecha { get; set; }

        [YerbaSoft.DTO.Mapping.Direct(UseComplexConvert = true)]
        public bool? ShowModiFecha { get; set; }

        private string _Icon;
        [YerbaSoft.DTO.Mapping.Direct]
        public override string Icon
        {
            get => _Icon = _Icon ?? @"C:\Windows\explorer.exe";
            set => _Icon = value;
        }

        internal override void Run() { }

        internal override ToolStripItem GetMenu()
        {
            var m = new ToolStripMenuItem(this.Name);
            m.Tag = this;
            m.Image = this.Image;
            m.DropDownOpening += OnOpen;

            OnClose(m, null);

            return m;
        }

        private void OnOpen(object sender, EventArgs e)
        {
            var menu = (ToolStripMenuItem)sender;
            var obj = (ShowFiles)menu.Tag;

            var dir = new System.IO.DirectoryInfo(obj.Path);
            var files = dir.EnumerateFiles(this.FileFilter ?? "*.*", System.IO.SearchOption.TopDirectoryOnly);

            menu.DropDownItems.Clear();

            if (obj.OpenFolder)
            {
                var of = new OpenFolder() { Id = Guid.NewGuid().ToString(), Name = $"Abrir Carpeta [ {obj.Name} ]", Path = this.Path };
                menu.DropDownItems.Add(of.GetMenu());
                menu.DropDownItems.Add(new ToolStripSeparator());
            }

            if (this.ShowSubFolders)
            {
                foreach(var d in dir.EnumerateDirectories().OrderBy(p => p.Name))
                {
                    var m = obj.Clone();
                    m.Name = d.Name;
                    m.Path = d.FullName;
                    menu.DropDownItems.Add(m.GetMenu());
                }
            }

            // order by
            files = files.OrderBy(p => p.Name).AsEnumerable();
            if (this.SortByModiFecha ?? false)
                files = files.OrderByDescending(p => p.LastWriteTime).AsEnumerable();

            foreach (var f in files)
            {
                if (!((System.IO.FileAttributes.Hidden & f.Attributes) == System.IO.FileAttributes.Hidden))
                {
                    var toShow = ((this.ShowModiFecha ?? false) ? $"[{f.LastWriteTime.ToString("dd/MM/yyyy HH:mm")}] " : "") + f.Name;
                    var of = new OpenFile() { Id = Guid.NewGuid().ToString(), Name = toShow, Path = f.FullName, Icon = Global.GetIconByExtension(f.Extension) };
                    menu.DropDownItems.Add(of.GetMenu());
                }
            }
        }

        private ShowFiles Clone()
        {
            var res = new ShowFiles();
            YerbaSoft.DTO.Mapping.Map.CopyTo(this, res);
            return res;
        }

        private void OnClose(object sender, EventArgs e)
        {
            var menu = (ToolStripMenuItem)sender;
            menu.DropDownItems.Clear();
            menu.DropDownItems.Add(new ToolStripSeparator());
        }
    }
}