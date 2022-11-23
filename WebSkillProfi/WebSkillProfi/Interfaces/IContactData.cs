using WebSkillProfi.Models;

namespace WebSkillProfi.Interfaces
{
    public interface IContactData
    {
        Task Add(Contact contact);
        Task Delete(int? id);
        Task Update(Contact contact);
        Task<IEnumerable<Contact>> Contacts();
        Task<Contact> GetContactById(int? id);
    }
}
