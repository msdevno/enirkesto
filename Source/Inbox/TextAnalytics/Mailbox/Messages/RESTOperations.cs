using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Bifrost.Serialization;

namespace TextAnalytics.Mailbox.Messages
{
    public class RESTOperations
    {
        ISerializer _serializer;
        public RESTOperations(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public async Task<T> POST<T>(string url, object payload)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var payloadAsJson = _serializer.ToJson(payload);

            try
            {
                var content = new StringContent(payloadAsJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);

                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return _serializer.FromJson<T>(result);
            }
            catch { 

            }

            return default(T);
        }


        public async Task<T> PUT<T>(string url, object payload)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var payloadAsJson = _serializer.ToJson(payload);

            try
            {
                var content = new StringContent(payloadAsJson, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(url, content);

                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return _serializer.FromJson<T>(result);
            }
            catch { 

            }

            return default(T);
        }


        public async Task<string> PUT(string url, object payload)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var payloadAsJson = _serializer.ToJson(payload);

            try
            {
                var content = new StringContent(payloadAsJson, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(url, content);

                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch(Exception ex) { 
                var i=0;
                i++;

            }

            return string.Empty;
        }
        

    }
}