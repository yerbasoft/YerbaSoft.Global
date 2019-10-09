using CSWork.DTO.JiraObjs;
using CSWork.Interface.Model;
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

namespace CSWork.Interface.Forms
{
    public partial class IssueForm : Form
    {
        public Utils Utils { get; }
        public DTO.WorkDatas.Issue Issue { get; }
        public DTO.JiraObjs.Issue WorkIssue { get; private set; }
        public DTO.JiraObjs.Issue JiraObj;
        public IEnumerable<Transition> JiraTransitions { get; }

        public IssueForm(DTO.WorkDatas.Issue issue, Model.Utils utils)
        {
            InitializeComponent();
            this.Icon = Resources.scroll;
            this.Utils = utils;
            this.Issue = issue;

            bOpenUrl.Click += (sender, e) => { this.Utils.Action.DoOpenUrl(BLL.Factory.Jira.Config.GetIssueUrl(this.Issue.Key)); };
            
            // ¿cargar en otro thread?
            this.JiraObj = BLL.Factory.Jira.GetIssue(this.Issue.Key);
            this.JiraTransitions = BLL.Factory.Jira.GetIssueTransitions(this.Issue.Key);

            ReLoadInfo();
        }

        private void ReLoadInfo()
        {
            this.Text = $"Issue {this.JiraObj.key} - {this.JiraObj.fields.summary}";
            this.lSummary.Text = this.JiraObj.fields.summary;


            // Adjuntos
            mAdjuntos.Enabled = this.JiraObj.fields.attachment.Count > 0;
            mAdjuntos.RemoveMenus();
            foreach (var adj in this.JiraObj.fields.attachment.OrderByDescending(p => p.created))
            {
                mAdjuntos.DropDownItems.Add(
                    this.Utils.Menu.CreateOpenUrlMenu($"{adj.created:dd/MM/yyyy HH:mm} {adj.filename}", adj.content, Recursos.GetImageForFile(adj.filename, adj.mimeType))
                );
            }

            // Issues relacionados
            mIssues.Enabled = this.JiraObj.fields.issuelinks.Count > 0;
            mIssues.RemoveMenus();
            foreach (var obj in this.JiraObj.fields.issuelinks)
            {
                var esWorkIssue = (obj.type.id == BLL.Factory.Config.Global.Work.Clonning.IdLinkType &&
                                   obj.inwardIssue?.fields?.issuetype?.id == BLL.Factory.Config.Global.Work.Clonning.IdIssueType);

                if (esWorkIssue)
                {
                    this.WorkIssue = obj.inwardIssue;
                }
                else
                {
                    var issue = obj.inwardIssue != null ? obj.inwardIssue : obj.outwardIssue;
                    var text = $"{(obj.inwardIssue != null ? obj.type.inward : obj.type.outward)} {issue.key} - {issue.fields.summary}";

                    mIssues.DropDownItems.Add(
                        this.Utils.Menu.CreateOpenUrlMenu(text, BLL.Factory.Jira.Config.GetIssueUrl(issue.key))
                    );
                }
            }

            // Transiciones
            mTransitions.Enabled = this.JiraTransitions.Count() > 0;
            mTransitions.RemoveMenus();
            foreach (var obj in this.JiraTransitions)
            {
                mTransitions.DropDownItems.Add(
                    this.Utils.Menu.CreateTransitionMenu(new DTO.WorkDatas.Issue(this.JiraObj), new DTO.WorkDatas.Transition(obj))
                );
            }


            // HTML's
            var backcolor = $"#{this.BackColor.R.ToString("X")}{this.BackColor.G.ToString("X")}{this.BackColor.B.ToString("X")}";

            string html = $@"<html>
                                <head>
                                    <style type=""text/css"">
                                        body {{ 
                                            background-color: {backcolor}; 
                                            font-family: -apple-system, BlinkMacSystemFont, ""Segoe UI"", Roboto, Oxygen, Ubuntu, ""Fira Sans"", ""Droid Sans"", ""Helvetica Neue"", sans-serif;
                                            font-size: 8px;
                                        }};

                                        h1 {{ font-size: 26px; }};
                                        h2 {{ font-size: 22px; }};
                                        h3 {{ font-size: 20px; }};
                                        h4 {{ font-size: 16px; }};
                                        h5 {{ font-size: 14px; }};
                                        p {{ font-size: 12px; }};

                                        {BLL.Factory.Jira.Config.GetCommentHtmlCss()}
                                    </style>
                                </head>
                                <body>{{body}}</body>
                            </html>";



            this.wDescription.DocumentText = html.Replace("{body}", BLL.Factory.Jira.Config.CommentToHtml(this.JiraObj.fields.description.content));


            var first = true;
            string body = "";
            foreach (var comment in this.JiraObj.fields.comment.comments)
            {
                var author = comment.author.displayName;
                var authorAvatarUrl = comment.author.avatarUrls.s32x32;

                var header = $@"{(!first ? "<hr>" : "")}
                                <table width=""100%"">
                                    <tr>
                                        <td style=""width:40px""><img src=""{authorAvatarUrl}"" alt=""{author}"" style=""width:32px; height:32px;""></img></td>
                                        <td style=""vertical-align: middle;"">{author}</td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>{{commentHtml}}</td>
                                    </tr>
                                </table>";
                var commentHtml = BLL.Factory.Jira.Config.CommentToHtml(comment.body.content);

                body += header.Replace("{commentHtml}", commentHtml);
                first = false;
            }

            this.wComentarios.DocumentText = html.Replace("{body}", body);
            this.wComentarios.Refresh(WebBrowserRefreshOption.Completely);
        }

        private void WComentarios_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.AbsoluteUri != "about:blank")
                e.Cancel = true;
        }

        private void BWork_Click(object sender, EventArgs e)
        {
            new Forms.Tools.RegisterWork(this.JiraObj.key).ShowDialog();
        }
    }
}
