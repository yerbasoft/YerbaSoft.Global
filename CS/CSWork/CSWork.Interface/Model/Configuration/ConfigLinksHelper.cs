using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSWork.DTO.GlobalConfigs;
using CSWork.Interface.Forms;
using CSWork.Interface.Properties;

namespace CSWork.Interface.Model.Configuration
{
    internal class ConfigLinksHelper : ConfigBase
    {
        public TextBox tFilter => GetControl<TextBox>("gLinks", "tLinksFilter");
        public TreeView tvLinks => GetControl<TreeView>("gLinks", "tvLinks");

        public TextBox tEditName => GetControl<TextBox>("gLinkData", "tLinkEditName");
        public TextBox tEditPath => GetControl<TextBox>("gLinkData", "tLinkEditPath");
        public Button bEditPathFind => GetControl<Button>("gLinkData", "tLinkEditPathFind");

        public Panel PicPanel => GetControl<Panel>("gLinkData", "gLinkDataImage", "gLinkDataImageDiv");
        public TextBox tImgCustom => GetControl<TextBox>("gLinkData", "gLinkDataImage", "tLinkImgCustom");
        public Button bImgCustomFind => GetControl<Button>("gLinkData", "gLinkDataImage", "bLinkImgCustomFind");

        public CheckBox cbShowFolderContent => GetControl<CheckBox>("gLinkData", "gLinkFolder", "cbLinkShowFolderContent");
        //public CheckBox cbLazyLoad => GetControl<CheckBox>("gLinkData", "gLinkFolder", "cbLinkLazyLoad");
        public CheckBox cbShowOpen => GetControl<CheckBox>("gLinkData", "gLinkFolder", "cbLinkShowOpen");
        public CheckBox cbShowSubFolders => GetControl<CheckBox>("gLinkData", "gLinkFolder", "cbLinkShowSubFolders");
        public TextBox tFolderFileFilter => GetControl<TextBox>("gLinkData", "gLinkFolder", "tLinkFolderFileFilter");

        public Button bSave => GetControl<Button>("gLinkData", "bLinkSave");

        public TreeNode SelectedNode { get; set; }
        public Link SelectedLink => SelectedNode.GetTag<Link>();

        public ConfigLinksHelper(Forms.Configuration form, Control container) : base(form, container)
        {
            // form event
            form.ResizeEnd += (sender, e) => BuildImagePictures(false);

            // events
            bEditPathFind.Click += (sender, e) => OpenDialog("path");
            bImgCustomFind.Click += (sender, e) => OpenDialog("img");

            cbShowFolderContent.CheckedChanged += (sender, e) => UpdateChecksStatus();
            cbShowSubFolders.CheckedChanged += (sender, e) => UpdateChecksStatus();
            tvLinks.AfterSelect += (sender, e) => SelectNode(e.Node);
            bSave.Click += (sender, e) => Save();


            // TreeList
            tvLinks.ImageList = new ImageList();
            foreach (var img in Recursos.GetAllImages())
                tvLinks.ImageList.Images.Add(img.Key, img.Value);

            BuildImagePictures();
            ReLoadData();
            tvLinks.TopNode.ExpandAll();
            SelectNode(tvLinks.TopNode);
        }
        
        private void BuildImagePictures(bool create = true)
        {
            var maxWidth = this.PicPanel.Size.Width;
            var y = 3;
            var x = 3;
            this.PicPanel.VerticalScroll.Value = this.PicPanel.VerticalScroll.Minimum;
            foreach(var img in Recursos.GetAllImages())
            {
                PictureBox pic;
                if (create)
                {
                    pic = new PictureBox();
                    this.PicPanel.Controls.Add(pic);
                    pic.Size = new System.Drawing.Size(32, 32);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.Image = img.Value;
                    pic.Tag = img.Key;
                    pic.Click += (sender, e) => SetSelectedPicture(sender.GetTag<string>());
                }
                else
                {
                    pic = this.PicPanel.Controls.OfType<PictureBox>().Single(p => p.GetTag<string>() == img.Key);
                }
                pic.Location = new System.Drawing.Point(x, y);

                x += 32 + 3;
                if (x + 32 > maxWidth)
                {
                    y += 32 + 3;
                    x = 3;
                }
            }
        }

        private void SetSelectedPicture(string icon)
        {
            PicPanel.Tag = icon;
            tImgCustom.Text = icon;
            foreach (var pic in PicPanel.Controls.OfType<PictureBox>())
            {
                pic.BackColor = pic.GetTag<string>() == icon ? Color.Yellow : Color.Transparent;
                pic.BorderStyle = pic.GetTag<string>() == icon ? BorderStyle.FixedSingle : BorderStyle.None;
            }
        }

        private void ReLoadData()
        {
            tvLinks.Nodes.Clear();

            var link = Config.Global.Link;
            var root = new TreeNode(link.Name, GetSubNodes(link));
            root.ImageKey = root.SelectedImageKey = link.Icon;
            root.Tag = link;
            root.ContextMenuStrip = GetMenuForNode(root, false, false, isRoot: true);
            tvLinks.TopNode = root;
            tvLinks.Nodes.Add(root);
        }

        private void SelectNode(TreeNode node)
        {
            this.SelectedNode = node;
            tEditName.Text = SelectedLink.Name;
            tEditPath.Text = SelectedLink.Path;
            bEditPathFind.Enabled = SelectedLink.IsFile || SelectedLink.IsFolder;
            SetSelectedPicture(SelectedLink.Icon);

            cbShowFolderContent.Enabled = SelectedLink.IsFolder;
            cbShowFolderContent.Checked = SelectedLink.ShowFolderContent;
            cbShowSubFolders.Checked = SelectedLink.ShowSubFolders;
            cbShowOpen.Checked = SelectedLink.ShowOpenFolder;
            tFolderFileFilter.Text = SelectedLink.FolderFileFilter;

            UpdateChecksStatus();
        }

        private void UpdateChecksStatus()
        {
            cbShowSubFolders.Enabled = SelectedLink.IsFolder && cbShowFolderContent.Checked;
            cbShowOpen.Enabled = SelectedLink.IsFolder && cbShowFolderContent.Checked;
            tFolderFileFilter.Enabled = SelectedLink.IsFolder && cbShowFolderContent.Checked;
        }

        private TreeNode[] GetSubNodes(Link link)
        {
            var res = new List<TreeNode>();

            for(var i = 0; i < link.SubLinks.Count; i++)
            {
                var node = new TreeNode(link.SubLinks[i].Name, GetSubNodes(link.SubLinks[i]));
                node.ImageKey = node.SelectedImageKey = link.SubLinks[i].Icon;
                node.Tag = link.SubLinks[i];
                node.ContextMenuStrip = GetMenuForNode(node, i == 0, i + 1 == link.SubLinks.Count, false, link.SubLinks[i].IsSubMenu, link.SubLinks[i].IsFolder, link.SubLinks[i].IsFile);
                res.Add(node);
            }

            return res.ToArray();
        }

        private ContextMenuStrip GetMenuForNode(TreeNode node, bool isFirst, bool isLast, bool isRoot = false, bool isSubMenu = false, bool isFolder = false, bool isFile = false)
        {
            var menu = new ContextMenuStrip();

            if (!isFile && !isFolder)
                menu.Items.Add(new ToolStripMenuItem("Nuevo SubMenu", Resources.link.ToBitmap(), (sender, e) => { NewNode(sender.GetTag<TreeNode>(), subitem: true, isSubMenu:true); }).Do(m => m.Tag = node));

            if (!isFile && !isFolder)
                menu.Items.Add(new ToolStripMenuItem("Nueva Carpeta", Resources.Open_Folder_yellow.ToBitmap(), (sender, e) => { NewNode(sender.GetTag<TreeNode>(), subitem: true, isFolder: true); }).Do(m => m.Tag = node));

            if (!isFile && !isFolder)
                menu.Items.Add(new ToolStripMenuItem("Nuevo Archivo", Resources.file, (sender, e) => { NewNode(sender.GetTag<TreeNode>(), subitem: true, isFile: true); }).Do(m => m.Tag = node));

            if (!isFile && !isFolder)
                menu.Items.Add(new ToolStripMenuItem("Separador", null, (sender, e) => { NewNode(sender.GetTag<TreeNode>(), subitem: true, isSeparator: true); }).Do(m => m.Tag = node));

            if (!isFirst || !isLast)
            {
                if (menu.Items.Count > 0)
                    menu.Items.Add(new ToolStripSeparator());

                if (!isFirst)
                    menu.Items.Add(new ToolStripMenuItem("Subir", Resources.Priority3.ToBitmap(), (sender, e) => { MoveNode(sender.GetTag<TreeNode>(), -1); }).Do(m => m.Tag = node));

                if (!isLast)
                    menu.Items.Add(new ToolStripMenuItem("Bajar", Resources.Priority4.ToBitmap(), (sender, e) => { MoveNode(sender.GetTag<TreeNode>(), 1); }).Do(m => m.Tag = node));
            }

            if (!isRoot)
            {
                if (menu.Items.Count > 0)
                    menu.Items.Add(new ToolStripSeparator());

                menu.Items.Add(new ToolStripMenuItem("Eliminar", Resources.delete2.ToBitmap(), (sender, e) => { DeleteNode(sender.GetTag<TreeNode>()); }).Do(m => m.Tag = node));
            }

            return menu;
        }

        private void MoveNode(TreeNode node, int step)
        {
            var link = node.GetTag<Link>();
            var index = node.Parent.Nodes.OfType<TreeNode>().Select((p, i) => new { p, i }).Where(p => p.p == node).Single().i;
            var parent = node.Parent;
            parent.Nodes.Remove(node);
            parent.Nodes.Insert(index + step, node);

            var pLink = Config.Global.Link.FindParent(link);
            pLink.SubLinks.Remove(link);
            pLink.SubLinks.Insert(index + step, link);

            node.ContextMenuStrip.Dispose();
            node.ContextMenuStrip = GetMenuForNode(node, (index + step) == 0, (index + step) + 1 >= parent.Nodes.Count, isSubMenu: link.IsSubMenu, isFolder: link.IsFolder, isFile: link.IsFile);
            this.Form.Result.ReLoadLinksMenu = true;
        }

        private void DeleteNode(TreeNode node)
        {
            var del = node.GetTag<Link>();
            var parent = Config.Global.Link.FindParent(del);
            parent.SubLinks.Remove(del);
            node.Remove();
            Config.SaveGlobal();
            Form.Result.ReLoadLinksMenu = true;
        }

        private void NewNode(TreeNode node, bool subitem = false, bool isSubMenu = false, bool isFolder = false, bool isFile = false, bool isSeparator = false)
        {
            var nNode = new TreeNode();
            var link = Link.GetNew(isSubMenu, isFolder, isFile, isSeparator);
            nNode.Text = link.Name;
            nNode.ImageKey = nNode.SelectedImageKey = link.Icon;
            nNode.Tag = link;

            if (subitem)
            {
                // agrego un submenu
                nNode.ContextMenuStrip = GetMenuForNode(nNode, node.Nodes.Count == 0, true, false, isSubMenu, isFolder, isFile);
                node.Nodes.Add(nNode);
                node.GetTag<Link>().SubLinks.Add(link);
            }
            else
            {
                // lo agrego en el parent
                nNode.ContextMenuStrip = GetMenuForNode(nNode, node.Parent.Nodes.Count == 0, true, false, isSubMenu, isFolder, isFile);
                node.Parent.Nodes.Add(nNode);
                Config.Global.Link.FindParent(node.GetTag<Link>()).SubLinks.Add(link);
            }

            Config.SaveGlobal();
            Form.Result.ReLoadLinksMenu = true;

            tvLinks.SelectedNode = nNode;

            if (isFolder || isFile)
                bEditPathFind.PerformClick();
        }

        private void Save()
        {
            //validaciones
            this.SelectedLink.Name = tEditName.Text;
            this.SelectedLink.Path = tEditPath.Text;
            this.SelectedLink.Icon = PicPanel.GetTag<string>();
            if (string.IsNullOrEmpty(this.SelectedLink.Icon))
                this.SelectedLink.Icon = tImgCustom.Text;
            this.SelectedLink.ShowFolderContent = cbShowFolderContent.Checked;
            this.SelectedLink.ShowSubFolders = cbShowSubFolders.Checked;
            this.SelectedLink.ShowOpenFolder = cbShowOpen.Checked;
            this.SelectedLink.FolderFileFilter = tFolderFileFilter.Text;

            this.SelectedNode.ImageKey = this.SelectedNode.SelectedImageKey = this.SelectedLink.Icon; 
            this.SelectedNode.Text = this.SelectedLink.Name;

            Config.SaveGlobal();
            Form.Result.ReLoadLinksMenu = true;
            //actualizar nodo de alguna forma ?
        }

        private void OpenDialog(string type)
        {
            switch(type)
            {
                case "path":
                    if (this.SelectedLink.IsFolder)
                    {
                        var folders = new FolderBrowserDialog();
                        folders.SelectedPath = this.SelectedLink.Path;
                        folders.Description = "Seleccione la Ruta";
                        folders.ShowNewFolderButton = true;
                        if (folders.ShowDialog() == DialogResult.OK)
                        {
                            tEditPath.Text = folders.SelectedPath;
                            if (this.SelectedLink.Name == "Nueva Carpeta")
                                tEditName.Text = new System.IO.DirectoryInfo(folders.SelectedPath).Name;
                        }
                    }
                    else if (this.SelectedLink.IsFile)
                    {
                        var files = new OpenFileDialog();
                        files.Filter = "Todos|*.*";
                        files.InitialDirectory = this.SelectedLink.Path;
                        files.Title = "Seleccione el archivo";
                        files.CheckFileExists = true;
                        files.CheckPathExists = true;
                        files.Multiselect = false;
                        files.ReadOnlyChecked = true;
                        if (files.ShowDialog() == DialogResult.OK)
                        {
                            tEditPath.Text = files.FileName;
                            if (this.SelectedLink.Name == "Nuevo Archivo")
                            {
                                tEditName.Text = files.SafeFileName;
                                SetSelectedPicture(files.FileName);
                            }
                        }
                    }
                    break;
                case "img":
                    var images = new OpenFileDialog();
                    images.Filter = "Todos|*.*";
                    images.InitialDirectory = this.SelectedLink.Path;
                    images.Title = "Seleccione la imagen o archivo";
                    images.CheckFileExists = true;
                    images.CheckPathExists = true;
                    images.Multiselect = false;
                    images.ReadOnlyChecked = true;
                    if (images.ShowDialog() == DialogResult.OK)
                    {
                        SetSelectedPicture(images.FileName);
                    }
                    break;
            }
        }
    }
}
