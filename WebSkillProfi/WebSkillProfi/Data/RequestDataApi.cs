using Newtonsoft.Json;
using WebSkillProfi.Models;
using System.Text;
using WebSkillProfi.Interfaces;

namespace WebSkillProfi.Data
{
    public class RequestDataApi : IRequestData
    {
        private HttpClient client { get; set; }
        private string url { get; set; }

        public RequestDataApi()
        {
            client = new HttpClient();
            url = "https://localhost:7268/api/Requests";
        }

        public async Task ChangeStatusRequest(Request request)
        {
            var putUrl = url + $"/{request.Id}";
            await client.PutAsync(
                requestUri: putUrl,
                content: new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8,
                mediaType: "application/json")
                );
        }

        public async Task<Request> GetRequestById(int? id)
        {
            string json = await client.GetStringAsync(url + $"/{id}");

            return JsonConvert.DeserializeObject<Request>(json);
        }

        public async Task<IEnumerable<Request>> Requests()
        {
            string json = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<IEnumerable<Request>>(json);
        }

        public async Task Add(Request request)
        {
            await client.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8,
                mediaType: "application/json")
                );
        }
    }
}
