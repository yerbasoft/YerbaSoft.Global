using CSWork.DTO.WorkDatas;
using CSWork.Interface.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWork.Interface.Forms.Tools
{
    public partial class RegisterWork : Form
    {
        public RegisterWork(string key)
        {
            InitializeComponent();
            this.Icon = Resources.stopwatch;

            LoadIssues(key);
        }

        private void LoadIssues(string selectedIssue)
        {
            this.cbIssues.Items.Clear();
            this.cbIssues.Items.AddRange(BLL.Factory.Work.GetWorkingOn().OrderBy(p => p.Key).ToArray());
            this.cbIssues.Text = selectedIssue;
        }

        private void CbIssues_TextChanged(object sender, EventArgs e)
        {
            var founded = cbIssues.Items.OfType<Issue>().FirstOrDefault(p => p.Key == cbIssues.Text);
            if (founded != null)
                cbIssues.SelectedItem = founded;            
        }

        private void BOK_Click(object sender, EventArgs e)
        {
            DTO.JiraObjs.Issue issue;
            if (cbIssues.SelectedItem != null)
            {
                issue = ((Issue)cbIssues.SelectedItem).Original;
            }
            else
            {
                issue = BLL.Factory.Jira.GetIssue(cbIssues.Text);
                if (issue?.id == 0)
                {
                    MessageBox.Show("No se encuentra el issue seleccionado en Jira", "Issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var comment = DTO.JiraObjs.Comments.Factory.GetHeader(
                new DTO.JiraObjs.Comments.Paragraph(
                    new DTO.JiraObjs.Comments.Text(tComment.Text)
                    )
                );

            BLL.Factory.Jira.AddWork(issue, comment, tTime.Text, DateTime.Now);
        }
    }
}
