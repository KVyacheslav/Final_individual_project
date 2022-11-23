using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using WebSkillProfi.Data;
using WebSkillProfi.Interfaces;
using WebSkillProfi.Models;

namespace WebSkillProfi.Controllers
{
    public class ProjectsController : Controller
    {
        private IProjectData _data;

        public ProjectsController(IProjectData data)
        {
            _data = data;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _data.Projects());
        }
    }
}
