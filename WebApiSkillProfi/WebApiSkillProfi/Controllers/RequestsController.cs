using Microsoft.AspNetCore.Mvc;
using WebApiSkillProfi.DataContext;
using WebApiSkillProfi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSkillProfi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private ApplicationDbContext _db;

        public RequestsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/<RequestController>
        [HttpGet]
        public IEnumerable<Request> Get()
        {
            return _db.Requests;
        }

        // GET api/<RequestController>/5
        [HttpGet("{id}")]
        public async Task<Request> Get(int id)
        {
            return await _db.Requests.FindAsync(id) ?? Model.Request.CreateNullRequest();
        }

        // POST api/<RequestController>
        [HttpPost]
        public async Task Post([FromBody] Request request)
        {
            await _db.Requests.AddAsync(request);
            await _db.SaveChangesAsync();
        }

        // PUT api/<RequestController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Request request)
        {
            _db.Requests.Update(request);
            await _db.SaveChangesAsync();
        }

        // DELETE api/<RequestController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _db.Requests.Remove(await Get(id));
            await _db.SaveChangesAsync();
        }
    }
}
