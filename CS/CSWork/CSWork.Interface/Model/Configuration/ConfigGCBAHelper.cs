using CSWork.Interface.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWork.Interface.Model.Configuration
{
    public class ConfigGCBAHelper : ConfigBase
    {
        private DTO.GlobalConfigs.Ambiente SelectedItem { get; set; }
        private List<DTO.GlobalConfigs.AmbienteWeb> WebList { get; set; }
        private DTO.GlobalConfigs.AmbienteWeb SelectedWeb { get; set; }

        // Filter y List
        private TextBox tGCBAFilter => GetControl<TextBox>("pGCBAAmbientes", "tGCBAFilter");
        private ListBox lbGCBAAmbientes => GetControl<ListBox>("pGCBAAmbientes", "lbGCBAAmbientes");
        private Button bGCBAAmbienteNew => GetControl<Button>("pGCBAAmbientes", "bGCBAAmbienteNew");
        private Button bGCBAAmbienteDelete => GetControl<Button>("pGCBAAmbientes", "bGCBAAmbienteDelete");

        // Data
        private TextBox tGCBADataName => GetControl<TextBox>("pGCBAData", "tGCBADataName");
        private Button bGCBADataSave => GetControl<Button>("pGCBAData", "bGCBADataSave");

        // Web Server
        private TextBox tGCBAWebIP => GetControl<TextBox>("pGCBAData", "pGCBADataWeb", "tGCBAWebIP");
        private CheckBox cbGCBAWebAllowExplorer => GetControl<CheckBox>("pGCBAData", "pGCBADataWeb", "cbGCBAWebAllowExplorer");
        private CheckBox cbGCBAWebAllowRemote => GetControl<CheckBox>("pGCBAData", "pGCBADataWeb", "cbGCBAWebAllowRemote");
        private CheckBox cbGCBAUseCustomUser => GetControl<CheckBox>("pGCBAData", "pGCBADataWeb", "cbGCBAUseCustomUser");
        private TextBox tGCBACustomUser => GetControl<TextBox>("pGCBAData", "pGCBADataWeb", "tGCBACustomUser");
        private TextBox tGCBACustomPass => GetControl<TextBox>("pGCBAData", "pGCBADataWeb", "tGCBACustomPass");

        // Webs
        private Button bGCBAWebsNew => GetControl<Button>("pGCBAData", "pGCBAWebs", "bGCBAWebsNew");
        private Button bGCBAWebsDelete => GetControl<Button>("pGCBAData", "pGCBAWebs", "bGCBAWebsDelete");
        private ListBox lbGCBAWebsList => GetControl<ListBox>("pGCBAData", "pGCBAWebs", "lbGCBAWebsList");
        private TextBox tGCBAWebsName => GetControl<TextBox>("pGCBAData", "pGCBAWebs", "tGCBAWebsName");
        private TextBox tGCBAWebsUrl => GetControl<TextBox>("pGCBAData", "pGCBAWebs", "tGCBAWebsUrl");


        public ConfigGCBAHelper(Forms.Configuration form, Control container) : base(form, container)
        {
            bGCBAAmbienteNew.Image = Resources.add.ToBitmap().ZoomForControl(bGCBAAmbienteNew);
            bGCBAAmbienteDelete.Image = Resources.delete2.ToBitmap().ZoomForControl(bGCBAAmbienteDelete);
            bGCBADataSave.Image = Resources.data_disk.ToBitmap().ZoomForControl(bGCBADataSave);

            tGCBAFilter.TextChanged += (sender, e) => ReLoadData();
            lbGCBAAmbientes.SelectedIndexChanged += (sender, e) => { SetData((DTO.GlobalConfigs.Ambiente)lbGCBAAmbientes.SelectedItem); };
            cbGCBAUseCustomUser.CheckedChanged += (sender, e) => { tGCBACustomUser.Enabled = tGCBACustomPass.Enabled = cbGCBAUseCustomUser.Checked; };
            bGCBAAmbienteNew.Click += (sender, e) => SetData();
            bGCBAAmbienteDelete.Click += (sender, e) => DeleteSelected();
            bGCBADataSave.Click += (sender, e) => SaveChanges();

            lbGCBAWebsList.SelectedIndexChanged += (sender, e) => SetWebData((DTO.GlobalConfigs.AmbienteWeb)lbGCBAWebsList.SelectedItem);
            bGCBAWebsNew.Click += (sender, e) => SetWebData();
            bGCBAWebsDelete.Click += (sender, e) => DeleteSelectedWeb();
            tGCBAWebsName.TextChanged += (sender, e) => EditWebData();
            tGCBAWebsUrl.TextChanged += (sender, e) => EditWebData();


            ReLoadData();
        }

        private void SaveChanges()
        {
            this.SelectedItem.Name = tGCBADataName.Text;
            this.SelectedItem.WebServerIP = tGCBAWebIP.Text;
            this.SelectedItem.AllowExplorer = cbGCBAWebAllowExplorer.Checked;
            this.SelectedItem.AllowRemote = cbGCBAWebAllowRemote.Checked;
            this.SelectedItem.UseCustomUser = cbGCBAUseCustomUser.Checked;
            this.SelectedItem.CustomUser = tGCBACustomUser.Text;
            this.SelectedItem.CustomPass = tGCBACustomPass.Text;

            // webs
            this.SelectedItem.Webs = WebList.Where(p => !string.IsNullOrEmpty(p.Name)).ToList();   // guardo el status con las modificaciones

            if (!Config.Global.Ambientes.Any(p => p == this.SelectedItem))
                Config.Global.Ambientes.Add(this.SelectedItem);
            Config.SaveGlobal();

            this.Form.Result.ReLoadAmbientesMenu = true;

            ReLoadData(this.SelectedItem);
        }

        private void DeleteSelected()
        {
            var del = Config.Global.Ambientes.SingleOrDefault(p => p == this.SelectedItem);
            Config.Global.Ambientes.Remove(del);
            Config.SaveGlobal();
            ReLoadData();
        }

        private void ReLoadData(DTO.GlobalConfigs.Ambiente autoselect = null)
        {
            lbGCBAAmbientes.Items.Clear();
            lbGCBAAmbientes.Items.AddRange(Config.Global.Ambientes.Where(p => p.Name.ToUpper().Contains(tGCBAFilter.Text.ToUpper())).OrderBy(p => p.Name).ToArray());

            if (autoselect != null && lbGCBAAmbientes.Items.Contains(autoselect))
                lbGCBAAmbientes.SelectedItem = autoselect;
            else if (lbGCBAAmbientes.Items.Count > 0)
                lbGCBAAmbientes.SelectedIndex = 0;
            else
                SetData();
        }

        private void SetData(DTO.GlobalConfigs.Ambiente item = null)
        {
            item = item ?? new DTO.GlobalConfigs.Ambiente();
            tGCBADataName.Text = item.Name;
            tGCBAWebIP.Text = item.WebServerIP;
            cbGCBAWebAllowExplorer.Checked = item.AllowExplorer;
            cbGCBAWebAllowRemote.Checked = item.AllowRemote;
            cbGCBAUseCustomUser.Checked = item.UseCustomUser;
            tGCBACustomUser.Text = item.CustomUser;
            tGCBACustomPass.Text = item.CustomPass;

            this.SelectedItem = item;
            this.WebList = item.Webs.Select(p => p.Clone()).ToList();

            ReLoadDataWebs();
        }
               
        private void ReLoadDataWebs()
        {
            lbGCBAWebsList.Items.Clear();
            lbGCBAWebsList.Items.AddRange(this.WebList.OrderBy(p => p.Name).ToArray());

            if (lbGCBAWebsList.Items.Count > 0)
                lbGCBAWebsList.SelectedIndex = 0;
            else
                SetWebData();
        }

        private void SetWebData(DTO.GlobalConfigs.AmbienteWeb item = null)
        {
            item = item ?? new DTO.GlobalConfigs.AmbienteWeb();

            this.SelectedWeb = null;    // para que no dispare eventos de edit
            tGCBAWebsName.Text = item.Name;
            tGCBAWebsUrl.Text = item.RelativeUrl;
            this.SelectedWeb = item;
        }

        private void DeleteSelectedWeb()
        {
            var del = WebList.SingleOrDefault(p => p == this.SelectedWeb);
            WebList.Remove(del);
            ReLoadDataWebs();
        }

        private void EditWebData()
        {
            if (this.SelectedWeb == null)
                return;

            this.SelectedWeb.Name = tGCBAWebsName.Text;
            this.SelectedWeb.RelativeUrl = tGCBAWebsUrl.Text;

            if (string.IsNullOrEmpty(SelectedWeb.Name) && WebList.Contains(SelectedWeb))
            {
                this.WebList.Remove(SelectedWeb);
                lbGCBAWebsList.Items.Remove(SelectedWeb);
            }
            else if (!string.IsNullOrEmpty(SelectedWeb.Name) && !WebList.Contains(SelectedWeb))
            {
                this.WebList.Add(SelectedWeb);
                lbGCBAWebsList.Items.Add(SelectedWeb);
            }
        }
    }
}
