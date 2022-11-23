using Newtonsoft.Json;
using WebSkillProfi.Models;
using System.Text;
using WebSkillProfi.Interfaces;

namespace WebSkillProfi.Data
{
    public class BlogDataApi : IBlogData
    {
        private HttpClient client { get; set; }
        private string url { get; set; }

        public BlogDataApi()
        {
            client = new HttpClient();
            url = "https://localhost:7268/api/Blogs";
        }

        public async Task Add(Blog blog)
        {
            await client.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8,
                mediaType: "application/json")
                );
        }

        public async Task Delete(int? id)
        {
            var deleteUrl = url + $"/{id}";
            await client.DeleteAsync(deleteUrl);
        }

        public async Task Update(Blog blog)
        {
            var putUrl = url + $"/{blog.Id}";
            await client.PutAsync(
                requestUri: putUrl,
                content: new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8,
                mediaType: "application/json")
                );
        }

        public async Task<IEnumerable<Blog>> Blogs()
        {
            string json = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<IEnumerable<Blog>>(json).OrderByDescending(v => v.Id);
        }

        public async Task<Blog> GetBlogById(int? id)
        {
            string json = await client.GetStringAsync(url + $"/{id}");

            return JsonConvert.DeserializeObject<Blog>(json);
        }
    }
}
