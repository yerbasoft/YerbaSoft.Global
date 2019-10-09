using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWork.Interface.Forms.Tools
{
    public partial class CommentHtml : UserControl
    {
        public CommentHtml()
        {
            InitializeComponent();
        }

        public void Show(DTO.JiraObjs.Comment comment)
        {
            var backcolor = "#FFFFFF"; //$"#{this.BackColor.R.ToString("X")}{this.BackColor.G.ToString("X")}{this.BackColor.B.ToString("X")}";

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

            web.DocumentText = html.Replace("{body}", BLL.Factory.Jira.Config.CommentToHtml(comment.content));
        }
    }
}
