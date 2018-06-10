using System.Web.Mvc;

namespace YerbaSoft.Web.Games.Clue.Models.Site
{
    public class Html
    {
        /// <summary>
        /// Devuelve un Partial como string asinable a una variable de javascript
        /// </summary>
        /// <param name="partial"></param>
        /// <returns></returns>
        public static string GetPartialString(MvcHtmlString partial)
        {
            var strineable = partial.ToString()
                                .Replace("\"", "\\\"")  // "        ->      \"
                                .Replace("\r\n", "")    // Enter    ->      
                                .Replace("<", "\\<")    // <        ->      \<
                                .Replace(">", "\\>");   // >        ->      \>

            return "\"" + strineable + "\"";
        }
    }
}