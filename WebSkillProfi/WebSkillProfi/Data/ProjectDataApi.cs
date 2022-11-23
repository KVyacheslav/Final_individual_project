using Newtonsoft.Json;
using WebSkillProfi.Models;
using System.Text;
using WebSkillProfi.Interfaces;

namespace WebSkillProfi.Data
{
    public class ProjectDataApi : IProjectData
    {
        private HttpClient client { get; set; }
        private string url { get; set; }

        public ProjectDataApi()
        {
            client = new HttpClient();
            url = "https://localhost:7268/api/Projects";
        }

        public async Task Add(Project project)
        {
            await client.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8,
                mediaType: "application/json")
                );
        }

        public async Task Delete(int? id)
        {
            var deleteUrl = url + $"/{id}";
            await client.DeleteAsync(deleteUrl);
        }

        public async Task Update(Project project)
        {
            var putUrl = url + $"/{project.Id}";
            await client.PutAsync(
                requestUri: putUrl,
                content: new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8,
                mediaType: "application/json")
                );
        }

        public async Task<IEnumerable<Project>> Projects()
        {
            string json = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<IEnumerable<Project>>(json);
        }

        public async Task<Project> GetProjectById(int? id)
        {
            string json = await client.GetStringAsync(url + $"/{id}");

            return JsonConvert.DeserializeObject<Project>(json);
        }
    }
}
