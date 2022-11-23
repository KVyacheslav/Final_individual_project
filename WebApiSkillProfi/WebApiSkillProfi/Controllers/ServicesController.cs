using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSkillProfi.DataContext;
using WebApiSkillProfi.Models;

namespace WebApiSkillProfi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private ApplicationDbContext _db;

        public ServicesController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/<ServicesController>
        [HttpGet]
        public IEnumerable<Service> Get()
        {
            return _db.Services;
        }

        // GET: api/<ServicesController>/5
        [HttpGet("{id}")]
        public async Task<Service> Get(int id)
        {
            return await _db.Services.FindAsync(id) ?? Service.CreateNullRequest();
        }

        // POST: api/<ServicesController>/5
        [HttpPost]
        public async Task Post([FromBody] Service service)
        {
            await _db.Services.AddAsync(service);
            await _db.SaveChangesAsync();
        }

        // PUT: api/<ServicesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Service service)
        {
            _db.Services.Update(service);
            await _db.SaveChangesAsync();
        }

        // DELETE: api/<ServicesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _db.Services.Remove(await Get(id));
            await _db.SaveChangesAsync();
        }
    }
}
