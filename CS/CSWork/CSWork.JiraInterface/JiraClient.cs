using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CSWork.DTO.JiraObjs.Post;

namespace CSWork.JiraInterface
{
    internal class JiraClient
    {
        private System.Net.Http.HttpClient Http;
        private const string ApiUrl = "/rest/api/3/";

        private string Url { get; set; }
        private string User { get; set; }
        private string Token { get; set; }

        public JiraClient(string url, string user, string token)
        {
            this.Url = url;
            this.User = user;
            this.Token = token;

            // Conexión
            Http = new System.Net.Http.HttpClient();
            Http.BaseAddress = new Uri(this.Url ?? "http:\\\\www.google.com.ar");
            var param = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", user, token)));
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", param);
        }

        public T Get<T>(string method)
        {
            if (method.StartsWith(this.Url))
                method = method.Substring(this.Url.Length);
            if (method.StartsWith(ApiUrl))
                method = method.Substring(ApiUrl.Length);

            //var param = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            //var req = new StringContent(param, System.Text.Encoding.UTF8, "application/json");
            var response = Http.GetAsync(ApiUrl + method).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            if (content.Trim().StartsWith("<html>"))
                return default;

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
        }

        public System.Net.HttpStatusCode Post(string url, object obj)
        {
            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(obj), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return Http.PostAsync(ApiUrl + url, httpContent).Result.StatusCode;
        }

        public T Post<T>(string url, object obj)
        {
            HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(obj), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = Http.PostAsync(ApiUrl + url, httpContent).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            if (content.Trim().StartsWith("<html>"))
                return default;

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
        }
    }
}
