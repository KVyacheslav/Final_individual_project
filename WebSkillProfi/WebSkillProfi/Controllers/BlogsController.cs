using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using WebSkillProfi.Data;
using WebSkillProfi.Interfaces;
using WebSkillProfi.Models;

namespace WebSkillProfi.Controllers
{
    public class BlogsController : Controller
    {
        private IBlogData _data;

        public BlogsController(IBlogData data)
        {
            _data = data;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _data.Blogs());
        }
    }
}
