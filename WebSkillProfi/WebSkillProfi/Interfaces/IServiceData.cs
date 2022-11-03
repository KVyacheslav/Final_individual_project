using WebSkillProfi.Models;

namespace WebSkillProfi.Interfaces
{
    public interface IServiceData
    {
        Task Add(Service service);
        Task Delete(int? id);
        Task Update(Service service);
        Task<IEnumerable<Service>> Services();
        Task<Service> GetServiceById(int? id);
    }
}
