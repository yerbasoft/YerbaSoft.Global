using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSWork.DTO.JiraObjs;
using CSWork.Interface.Properties;

namespace CSWork.Interface.Forms.Tools
{
    public partial class FindIssue : Form
    {
        public class DataSourceType
        {
            public string Issue { get; set; }
            public string Estado { get; set; }
            public string Titulo { get; set; }
            private Comment Comment { get; set; }

            public DataSourceType(Issue obj)
            {
                this.Issue = obj.key;
                this.Estado = obj.fields.status.name;
                this.Titulo = obj.fields.summary;
                this.Comment = obj.fields.description;
            }

            public Comment GetComment() => this.Comment;
        }

        public Model.Utils Utils { get; set; }

        public FindIssue(Model.Utils utils)
        {
            InitializeComponent();
            this.Icon = Resources.scroll_view;
            this.Utils = utils;
            this.grid.DataSource = new BindingSource() { DataSource = typeof(DataSourceType) };            
        }

        private void BSearch_Click(object sender, EventArgs e)
        {
            pSearching.Visible = true;
            bSearch.Enabled = false;

            var t = tFilter.Text;
            /*
            if (t.Length < 4)
                return;
                */
            var jql = new List<string> { /*$"(key={t})"*/ };

            // OR'S
            if (cbFilterTitle.Checked || cbFilterDesc.Checked || cbFilterComments.Checked)
            {
                var bytext = new List<string>();
                if (cbFilterTitle.Checked)
                    bytext.Add($"(summary~\"{t}\")");
                if (cbFilterDesc.Checked)
                    bytext.Add($"(description~\"{t}\")");
                if (cbFilterComments.Checked)
                    bytext.Add($"(comments~\"{t}\")");

                jql.Add($"( {string.Join(" OR ", bytext)} )");
            }

            var query = string.Join(" AND ", jql);

            new Task(() =>
            {
                var data = BLL.Factory.Jira.Search("search?jql=" + query, false);
                data = data ?? new Issue[0];
                this.Utils.Safe(grid, () =>
                {
                    ((BindingSource)grid.DataSource).DataSource = data.Select(p => new DataSourceType(p)).OrderBy(p => p.Issue);
                    pSearching.Visible = false;
                    bSearch.Enabled = true;
                });
            }).Start();
        }

        private void Grid_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.grid.CurrentCell = this.grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                mGridMenu.Tag = this.grid.Rows[e.RowIndex].DataBoundItem;
                e.ContextMenuStrip = mGridMenu;
            }
        }

        private void MOpenWeb_Click(object sender, EventArgs e)
        {
            var data = mGridMenu.GetTag<DataSourceType>();
            this.Utils.Action.DoOpenUrl(BLL.Factory.Jira.Config.GetIssueUrl(data.Issue));
        }

        private void Grid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.grid.SelectedRows.Count > 0)
            {
                var data = (DataSourceType)this.grid.SelectedRows[0].DataBoundItem;
                preview.Show(data.GetComment());
            }
            else
            {
                preview.Show(new Comment());
            }
        }
    }
}
