using SIR.Common.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SIR.Common.Connector
{
    /// <summary>
    /// Clase base para los Connectores que contiene funciones helpers para las implementaciones
    /// </summary>
    public abstract class Connector 
    {
        protected Uri BaseUrl;
        protected Http.ConnectorHeader ConnectorHeader;

        public Connector(Uri baseUrl, Http.ConnectorHeader header = null)
        {
            if (!baseUrl.AbsoluteUri.EndsWith("/"))
                baseUrl = new Uri($"{baseUrl.AbsoluteUri}/");
            this.BaseUrl = baseUrl;
            this.ConnectorHeader = header;
        }

        /// <summary>
        /// Devuelve una nueva insancia de cliente Http listo para ser utilizado
        /// </summary>
        /// <returns></returns>
        protected virtual HttpClient GetClient()
        {
            var header = this.ConnectorHeader ?? new Http.ConnectorHeader();

            var client = new HttpClient();
            client.BaseAddress = this.BaseUrl;
            
            foreach(var custom in header.Custom)
                client.DefaultRequestHeaders.Add(custom.Key, custom.Value);

            if (header.UseContentTypeJSON)
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            if (header.BasicAuthorization != null)
            {
                string param = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{header.BasicAuthorization.User}:{header.BasicAuthorization.Pass}"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("basic", param);
            }

            return client;
        }

        /// <summary>
        /// Llama a un método GET
        /// </summary>
        /// <param name="method">url relativa</param>
        protected SIR.Common.DTO.Response<System.Net.HttpStatusCode> Get(string method)
        {
            try
            {
                System.Net.HttpStatusCode result;
                using (var client = GetClient())
                {
                    var response = client.GetAsync(method).Result;
                    result = response.StatusCode;
                }

                return new Response<System.Net.HttpStatusCode>(result);
            }
            catch(Exception ex)
            {
                return new Response<System.Net.HttpStatusCode>(ex);
            }
        }
        /// <summary>
        /// Llama a un método GET y devuelve el objeto tipado
        /// </summary>
        /// <typeparam name="T">Tipo de dato devuelto</typeparam>
        /// <param name="method">url relativa</param>
        protected SIR.Common.DTO.Response<T> Get<T>(string method)
        {
            try
            {
                var result = new Response<T>(true);
                using (var client = GetClient())
                {
                    var response = client.GetAsync(method).Result;

                    var value = response.Content.ReadAsStringAsync();
                    if (result.Success = response.IsSuccessStatusCode)
                        result.SetData(Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value.Result));
                    else
                        result.AddError($"{response.StatusCode}: {value.Result}");
                }

                return result;
            }
            catch (Exception ex)
            {
                return new Response<T>(ex);
            }
        }

        /// <summary>
        /// Llama a un método POST
        /// </summary>
        /// <param name="method">url relativa</param>
        /// <param name="data">objeto a enviar en el body</param>
        protected SIR.Common.DTO.Response<System.Net.HttpStatusCode> Post(string method, object data = null)
        {
            try
            {
                System.Net.HttpStatusCode result;
                using (var client = GetClient())
                {
                    var response = client.PostAsync(method, GetHttpContent(data)).Result;
                    result = response.StatusCode;
                }

                return new Response<System.Net.HttpStatusCode>(result);
            }
            catch (Exception ex)
            {
                return new Response<System.Net.HttpStatusCode>(ex);
            }
        }
        /// <summary>
        /// Llama a un método POST y devuelve el objeto tipado
        /// </summary>
        /// <typeparam name="T">Tipo de dato devuelto</typeparam>
        /// <param name="method">url relativa</param>
        /// <param name="data">objeto a enviar en el body</param>
        protected SIR.Common.DTO.Response<T> Post<T>(string method, object data = null)
        {
            try
            {
                var result = new Response<T>(true);
                using (var client = GetClient())
                {
                    var response = client.PostAsync(method, GetHttpContent(data)).Result;

                    var value = response.Content.ReadAsStringAsync();
                    if (result.Success = response.IsSuccessStatusCode)
                        result.SetData(Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value.Result));
                    else
                        result.AddError($"{response.StatusCode}: {value.Result}");
                }

                return result;
            }
            catch (Exception ex)
            {
                return new Response<T>(ex);
            }
        }

        /// <summary>
        /// Llama a un método DELETE
        /// </summary>
        /// <typeparam name="T">Tipo de dato devuelto</typeparam>
        /// <param name="method">url relativa</param>
        /// <param name="data">objeto a enviar en el body</param>
        protected SIR.Common.DTO.Response<System.Net.HttpStatusCode> Delete(string method)
        {
            try
            {
                System.Net.HttpStatusCode result;
                using (var client = GetClient())
                {
                    var response = client.DeleteAsync(method).Result;
                    result = response.StatusCode;
                }

                return new Response<System.Net.HttpStatusCode>(result);
            }
            catch (Exception ex)
            {
                return new Response<System.Net.HttpStatusCode>(ex);
            }
        }
        /// <summary>
        /// Llama a un método DELETE y devuelve el objeto tipado
        /// </summary>
        /// <typeparam name="T">Tipo de dato devuelto</typeparam>
        /// <param name="method">url relativa</param>
        protected SIR.Common.DTO.Response<T> Delete<T>(string method)
        {
            try
            {
                var result = new Response<T>(true);
                using (var client = GetClient())
                {
                    var response = client.DeleteAsync(method).Result;

                    var value = response.Content.ReadAsStringAsync();
                    if (result.Success = response.IsSuccessStatusCode)
                        result.SetData(Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value.Result));
                    else
                        result.AddError($"{response.StatusCode}: {value.Result}");
                }

                return result;
            }
            catch (Exception ex)
            {
                return new Response<T>(ex);
            }
        }

        /// <summary>
        /// Llama a un método PUT
        /// </summary>
        /// <param name="method">url relativa</param>
        /// <param name="data">objeto a enviar en el body</param>
        protected SIR.Common.DTO.Response<System.Net.HttpStatusCode> Put(string method, object data = null)
        {
            try
            {
                System.Net.HttpStatusCode result;
                using (var client = GetClient())
                {
                    var response = client.PutAsync(method, GetHttpContent(data)).Result;
                    result = response.StatusCode;
                }

                return new Response<System.Net.HttpStatusCode>(result);
            }
            catch (Exception ex)
            {
                return new Response<System.Net.HttpStatusCode>(ex);
            }
        }
        /// <summary>
        /// Llama a un método PUT y devuelve el objeto tipado
        /// </summary>
        /// <typeparam name="T">Tipo de dato devuelto</typeparam>
        /// <param name="method">url relativa</param>
        /// <param name="data">objeto a enviar en el body</param>
        protected SIR.Common.DTO.Response<T> Put<T>(string method, object data = null)
        {
            try
            {
                var result = new Response<T>(true);
                using (var client = GetClient())
                {
                    var response = client.PutAsync(method, GetHttpContent(data)).Result;

                    var value = response.Content.ReadAsStringAsync();
                    if (result.Success = response.IsSuccessStatusCode)
                        result.SetData(Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value.Result));
                    else
                        result.AddError($"{response.StatusCode}: {value.Result}");
                }

                return result;
            }
            catch (Exception ex)
            {
                return new Response<T>(ex);
            }
        }

        private HttpContent GetHttpContent(object data)
        {
            HttpContent content = null;
            if (data != null)
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            return content;
        }
    }
}
