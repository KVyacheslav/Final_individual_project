using WebSkillProfi.Models;

namespace WebSkillProfi.Interfaces
{
    public interface IProjectData
    {
        Task Add(Project project);
        Task Delete(int? id);
        Task Update(Project project);
        Task<IEnumerable<Project>> Projects();
        Task<Project> GetProjectById(int? id);
    }
}
