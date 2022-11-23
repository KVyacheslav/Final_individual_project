using WebSkillProfi.Models;

namespace WebSkillProfi.Interfaces
{
    public interface IBlogData
    {
        Task Add(Blog blog);
        Task Delete(int? id);
        Task Update(Blog blog);
        Task<IEnumerable<Blog>> Blogs();
        Task<Blog> GetBlogById(int? id);
    }
}
