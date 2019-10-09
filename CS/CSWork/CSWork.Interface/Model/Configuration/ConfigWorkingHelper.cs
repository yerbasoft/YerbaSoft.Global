using CSWork.DTO.GlobalConfigs;
using CSWork.Interface.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWork.Interface.Model.Configuration
{
    public class ConfigWorkingHelper : ConfigBase
    {
        public List<JiraFilter> FiltrosJira { get; private set; } = new List<JiraFilter>();

        private CheckBox cbWorkWithoutIssue => GetControl<CheckBox>("pWorkGeneral", "cbWorkWithoutIssue");

        private Button bWorkRefreshJiraFilters => GetControl<Button>("pWorkFiltros", "pWorkFiltrosJira", "bWorkRefreshJiraFilters");
        private TextBox tWorkJiraFiltersFilter => GetControl<TextBox>("pWorkFiltros", "pWorkFiltrosJira", "tWorkJiraFiltersFilter");
        private DataGridView gWorkJiraFilters => GetControl<DataGridView>("pWorkFiltros", "pWorkFiltrosJira", "gWorkJiraFilters");
        private Button bWorkJiraFiltersAdd => GetControl<Button>("pWorkFiltros", "pWorkFiltrosJira", "bWorkJiraFiltersAdd");

        private DataGridView gWorkFilters => GetControl<DataGridView>("pWorkFiltros", "pWorkFiltrosSys", "gWorkFilters");
        private Button bWorkFiltersRemove => GetControl<Button>("pWorkFiltros", "pWorkFiltrosSys", "bWorkFiltersRemove");


        private System.Windows.Forms.BindingSource gWorkJiraFiltersSource;
        private System.Windows.Forms.BindingSource gWorkFiltersSource;

        public ConfigWorkingHelper(Forms.Configuration form, Control container) : base(form, container)
        {
            // Establezco los DataBinding de las grillas
            this.gWorkJiraFiltersSource = new System.Windows.Forms.BindingSource();
            this.gWorkFiltersSource = new System.Windows.Forms.BindingSource();
            this.gWorkJiraFiltersSource.DataSource = typeof(CSWork.DTO.GlobalConfigs.JiraFilter);
            this.gWorkFiltersSource.DataSource = typeof(CSWork.DTO.GlobalConfigs.JiraFilter);
            this.gWorkJiraFilters.DataSource = this.gWorkJiraFiltersSource;
            this.gWorkFilters.DataSource = this.gWorkFiltersSource;
            
            bWorkRefreshJiraFilters.Image = Resources.view.ToBitmap().ZoomForControl(bWorkRefreshJiraFilters);
            bWorkJiraFiltersAdd.Image = Resources.add.ToBitmap().ZoomForControl(bWorkJiraFiltersAdd);
            bWorkFiltersRemove.Image = Resources.delete2.ToBitmap().ZoomForControl(bWorkFiltersRemove);

            cbWorkWithoutIssue.CheckedChanged += (sender, e) => { Config.Global.Work.AllowTaskWithoutIssue = cbWorkWithoutIssue.Checked; Config.SaveGlobal(); this.Form.Result.ReLoadWorkMenu = true; };
            bWorkRefreshJiraFilters.Click += OnSearchFilters;
            tWorkJiraFiltersFilter.TextChanged += (sender, e) => ReLoadFilterJiraGrid();
            bWorkJiraFiltersAdd.Click += OnAddJira;
            bWorkFiltersRemove.Click += OnRemoveJira;

            ReLoadData();
        }

        private void OnSearchFilters(object sender, EventArgs e)
        {
            this.FiltrosJira = BLL.Factory.Jira.GetFilters().Select(p => new DTO.GlobalConfigs.JiraFilter(p)).OrderBy(p => p.Name).ToList();
            ReLoadFilterJiraGrid();
        }

        private void ReLoadData()
        {
            this.gWorkFiltersSource.DataSource = Config.Global.Work.Filters.ToArray();
        }

        private void ReLoadFilterJiraGrid()
        {
            this.gWorkJiraFiltersSource.DataSource = this.FiltrosJira.Where(p => 
                                                    p.Code.ToString() == tWorkJiraFiltersFilter.Text ||
                                                    p.Name.ToUpper().Contains(tWorkJiraFiltersFilter.Text.ToUpper()));
        }

        private void OnAddJira(object sender, EventArgs e)
        {
            if (gWorkJiraFilters.SelectedRows.Count == 0)
                return;

            var filter = (JiraFilter)gWorkJiraFilters.SelectedRows[0].DataBoundItem;
            if (Config.Global.Work.Filters.Any(p => p.Code == filter.Code))
                return;

            Config.Global.Work.Filters.Add(filter);
            Config.SaveGlobal();
            this.Form.Result.ReLoadWorkMenu = true;
            ReLoadData();
        }

        private void OnRemoveJira(object sender, EventArgs e)
        {
            if (gWorkFilters.SelectedRows.Count == 0)
                return;

            var filter = (JiraFilter)gWorkFilters.SelectedRows[0].DataBoundItem;
            if (!Config.Global.Work.Filters.Any(p => p.Code == filter.Code))
                return;

            Config.Global.Work.Filters.Remove(filter);
            Config.SaveGlobal();
            this.Form.Result.ReLoadWorkMenu = true;
            ReLoadData();
        }
    }
}
