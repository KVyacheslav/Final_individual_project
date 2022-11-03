using WebSkillProfi.Enums;
using WebSkillProfi.Models;

namespace WebSkillProfi.Interfaces
{
    public interface IRequestData
    {
        Task<IEnumerable<Request>> Requests();
        Task<Request> GetRequestById(int? id);
        Task ChangeStatusRequest(Request request);
        Task Add(Request request);
    }
}
