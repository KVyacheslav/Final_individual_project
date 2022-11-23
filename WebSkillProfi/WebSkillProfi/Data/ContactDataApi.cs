using Newtonsoft.Json;
using WebSkillProfi.Models;
using System.Text;
using WebSkillProfi.Interfaces;

namespace WebSkillProfi.Data
{
    public class ContactDataApi : IContactData
    {
        private HttpClient client { get; set; }
        private string url { get; set; }

        public ContactDataApi()
        {
            client = new HttpClient();
            url = "https://localhost:7268/api/Contacts";
        }

        public async Task Add(Contact contact)
        {
            await client.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8,
                        mediaType: "application/json")
                );
        }

        public async Task Delete(int? id)
        {
            var deleteUrl = url + $"/{id}";
            await client.DeleteAsync(deleteUrl);
        }

        public async Task Update(Contact contact)
        {
            var putUrl = url + $"/{contact.Id}";
            await client.PutAsync(
                requestUri: putUrl,
                content: new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8,
                        mediaType: "application/json")
                );
        }

        public async Task<IEnumerable<Contact>> Contacts()
        {
            string json = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);
        }

        public async Task<Contact> GetContactById(int? id)
        {
            string json = await client.GetStringAsync(url + $"/{id}");

            return JsonConvert.DeserializeObject<Contact>(json);
        }
    }
}
