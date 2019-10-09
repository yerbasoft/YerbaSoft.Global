using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSWork.DTO.GlobalConfigs
{
    public class Jira
    {
        public const string GetTokenUrl = "https://id.atlassian.com/manage/api-tokens";

        public string Url { get; set; } = "http://cardinalconsulting.atlassian.net";
        public string User { get; set; }
        public string Token { get; set; }
        public List<int> Filters { get; set; } = new List<int>();

        public bool IsLogon()
        {
            return !string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(Token);
        }

        public string GetIssueUrl(string key)
        {
            return $"{Url}/browse/{key}";
        }

        public string CommentToHtml(object oContent)
        {
            if (oContent == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            var content = ((Newtonsoft.Json.Linq.JArray)oContent).ToObject<List<DTO.JiraObjs.CommentObj>>();

            sb.AppendLine(GetCommentToHtml(content));

            return sb.ToString();
        }

        private string GetCommentToHtml(IEnumerable<DTO.JiraObjs.CommentObj> objs)
        {
            string result = "";

            foreach (var obj in objs)
                result += GetCommentToHtml(obj);

            return result;
        }

        private string GetCommentToHtml(DTO.JiraObjs.CommentObj obj)
        {
            switch(obj.type)
            {
                case "paragraph":
                    return $"<p>{GetCommentToHtml(obj.content)}</p>";
                case "text":
                    string starts = "";
                    string ends = "";
                    foreach(var mark in obj.marks)
                    {
                        switch(mark.type)
                        {
                            case "em":
                            case "strong":
                                starts = starts + $"<{mark.type}>";
                                ends = $"</{mark.type}>" + ends;
                                break;
                            case "underline":
                                starts = starts + "<u>";
                                ends = "</u>" + ends;
                                break;
                            case "strike":
                            case "code":
                            //case "mention":
                                starts = starts + $"<span class=\"text-{mark.type}\">";
                                ends = "</span>" + ends;
                                break;
                            case "subsup":
                                starts = starts + $"<{mark.attrs.type}>";
                                ends = $"</{mark.attrs.type}>" + ends;
                                break;
                            case "textColor":
                                starts = starts + $"<span style=\"color:{mark.attrs.color}\">";
                                ends = "</span>" + ends;
                                break;
                            case "link":
                                starts = starts + $"<a href=\"{mark.attrs.href}\" alt=\"{mark.attrs.title}\">";
                                ends = "</a>" + ends;
                                break;
                        }
                    }

                    return $"{starts}{obj.text}{ends}";
                case "heading":
                    return $"<h{obj.attrs.level}>{GetCommentToHtml(obj.content)}</h{obj.attrs.level}>";
                case "mention":
                    return $"<span class=\"text-mention\">{obj.attrs.text}</span>";
                case "inlineCard":
                    return $"<a href=\"{obj.attrs.url}\">{obj.attrs.url}</a>";
                case "rule":
                    return $"<hr>";
                case "table":
                    return $"<table width=\"100%\" border=\"1\">{GetCommentToHtml(obj.content)}</table>";
                case "tableRow":
                    return $"<tr>{GetCommentToHtml(obj.content)}</tr>";
                case "tableHeader":
                    return $"<th>{GetCommentToHtml(obj.content)}</th>";
                case "tableCell":
                    return $"<td>{GetCommentToHtml(obj.content)}</td>";
                case "panel":
                    return $@"<div class=""panel-{obj.attrs.panelType}"">
                                <p>{GetCommentToHtml(obj.content)}</p>
                              </div>";
                case "blockquote":
                    return $"<{obj.type}>{GetCommentToHtml(obj.content)}</{obj.type}>";
                case "orderedList":
                    return $@"<ul type=""1"" start=""{(obj.attrs?.order ?? 1)}"">{GetCommentToHtml(obj.content)}</ul>";
                case "bulletList":
                    return $@"<ul style=""list-style-type:disc;"">{GetCommentToHtml(obj.content)}</ul>";
                case "listItem":
                    return $@"<li>{GetCommentToHtml(obj.content)}</li>";
                case "codeBlock":
                    return $@"<div class=""panel-code text-code"">{GetCommentToHtml(obj.content).Replace("\n", "<br />")}</div>";
                case "hardBreak":
                    return "<br />";


                case "media":
                case "mediaSingle":
                case "mediaGroup":
                default:
                    return $@"::{obj.type.ToUpper()}::";
            }
        }

        public string GetCommentHtmlCss()
        {
            return $@"  .text-strike {{ text-decoration: line-through; }};
                        .text-code {{ font-family: SFMono-Medium, ""SF Mono"", ""Segoe UI Mono"", ""Roboto Mono"", ""Ubuntu Mono"", Menlo, Consolas, Courier, monospace; }};
                        .text-mention {{ background: rgb(0, 82, 204); border-width: 1px; border-style: solid; border-color: transparent; border-image: initial; border-radius: 20px; }};

                        .panel-code {{ width:100%; background: rgb(200,200,200); }}
                        .panel-note {{ width:100%; background: rgb(234, 230, 255); }};
                    ";
        }
    }
}
