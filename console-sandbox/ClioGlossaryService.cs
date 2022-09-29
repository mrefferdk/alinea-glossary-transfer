using System;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace console_sandbox
{
    public class ClioGlossaryService
    {
        readonly string Url;

        public ClioGlossaryService(string url)
        {
            Url = url;
        }


        private Task<HttpResponseMessage> SendGetRequest()
        {
            HttpClient client = new HttpClient();
            //using (HttpClient client = new HttpClient()) {
                try {
                    return client.GetAsync(Url);
                } catch (Exception e) {
                    Console.WriteLine("Exception found");
                }

            //}

            return default;
        }


        public async Task<List<ClioGlossary>> GetClioGlossaryJson()
        {
            HttpResponseMessage response = await SendGetRequest();
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                if (!String.IsNullOrEmpty(json)) {
                    return JsonSerializer.Deserialize<List<ClioGlossary>>(json);

                } 
            }

            return new List<ClioGlossary>();
        }
    }
}

