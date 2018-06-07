using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Treinus.App.Controls
{
    public static class RestApi
    {
        public static async Task<object> Get(string url, Dictionary<string, object> parameters = null)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var item in parameters)
                        url += $"/{item.Key}/{item.Value}";
                }

                var response = await client.GetAsync(url);

                return ApiReturn(response);
            }
        }

        public static async Task<object> Delete(string url, Dictionary<string, object> parameters = null, object obj = null)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var item in parameters)
                        url += $"/{item.Key}/{item.Value}";
                }

                StringContent content = null;
                if (obj != null)
                    content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

                var response = await client.DeleteAsync(url);

                return ApiReturn(response);
            }
        }

        public static async Task<object> Post(string url, object data, Dictionary<string, object> parameters = null)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var item in parameters)
                        url += $"/{item.Key}/{item.Value}";
                }

                if (data == null)
                    throw new Exception("Nenhum dado a ser atualizado");

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                return ApiReturn(response);
            }
        }

        public static async Task<object> Put(string url, object parameters)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (parameters == null)
                    throw new Exception("Nenhum dado a ser atualizado.");

                var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);

                return ApiReturn(response);
            }
        }

        private static object ApiReturn(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var placeJson = response.Content.ReadAsStringAsync().Result;

                dynamic dados = JsonConvert.DeserializeObject<dynamic>(placeJson);

                return dados;
            }
            else
                throw new ArgumentException($"Ocorreu o seguinte erro: {response.ReasonPhrase}", response.StatusCode.ToString());
        }
    }
}
