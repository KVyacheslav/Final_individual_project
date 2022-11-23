using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSkillProfi.DataContext;
using WebApiSkillProfi.Models;

namespace WebApiSkillProfi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private ApplicationDbContext _db;

        public ContactsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/<ContactsController>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _db.Contacts.Where(c => !string.IsNullOrWhiteSpace(c.Url));
        }

        // GET: api/<ContactsController>/5
        [HttpGet("{id}")]
        public async Task<Contact> Get(int id)
        {
            return await _db.Contacts.FindAsync(id) ?? Contact.CreateNullContact();
        }

        // POST: api/<ContactsController>
        [HttpPost]
        public async Task Post([FromBody] Contact contact)
        {
            await _db.Contacts.AddAsync(contact);
            await _db.SaveChangesAsync();
        }

        // PUT: api/<ContactsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Contact contact)
        {
            _db.Contacts.Update(contact);
            await _db.SaveChangesAsync();
        }

        // DELETE: api/<ContactsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _db.Contacts.Remove(await Get(id));
            await _db.SaveChangesAsync();
        }
    }
}
