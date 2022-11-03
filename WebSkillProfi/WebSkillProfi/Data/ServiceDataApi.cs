using Newtonsoft.Json;
using WebSkillProfi.Models;
using System.Text;
using WebSkillProfi.Interfaces;

namespace WebSkillProfi.Data
{
    public class ServiceDataApi : IServiceData
    {
        private HttpClient client { get; set; }
        private string url { get; set; }

        public ServiceDataApi()
        {
            client = new HttpClient();
            url = "https://localhost:7268/api/Services";
        }

        public async Task Add(Service service)
        {
            await client.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(service), Encoding.UTF8,
                mediaType: "application/json")
                );
        }

        public async Task Delete(int? id)
        {
            var deleteUrl = url + $"/{id}";
            await client.DeleteAsync(deleteUrl);
        }

        public async Task Update(Service service)
        {
            var putUrl = url + $"/{service.Id}";
            await client.PutAsync(
                requestUri: putUrl,
                content: new StringContent(JsonConvert.SerializeObject(service), Encoding.UTF8,
                mediaType: "application/json")
                );
        }

        public async Task<IEnumerable<Service>> Services()
        {
            string json = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<IEnumerable<Service>>(json);
        }

        public async Task<Service> GetServiceById(int? id)
        {
            string json = await client.GetStringAsync(url + $"/{id}");

            return JsonConvert.DeserializeObject<Service>(json);
        }
    }
}
