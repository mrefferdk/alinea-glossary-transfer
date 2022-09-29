using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace console_sandbox
{
    public class NextWordExplanationService
    {
        static HttpClient client = new HttpClient();
        readonly string Url;

        public NextWordExplanationService(string url)
        {
            Url = url;
        }

        private async Task<HttpResponseMessage> SendPostRequest(List<GlossaryDTO> glossaryList)
        {

            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(glossaryList), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return await client.PostAsync(Url, httpContent);
        }

        public async Task<bool> BulkSave(List<GlossaryDTO> glossaryList)
        {
            HttpResponseMessage response = await this.SendPostRequest(glossaryList);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return true;
            }

            return false;
        }
    }
}

