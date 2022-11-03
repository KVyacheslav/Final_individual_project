using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using WebSkillProfi.Data;
using WebSkillProfi.Interfaces;
using WebSkillProfi.Models;

namespace WebSkillProfi.Controllers
{
    public class ServicesController : Controller
    {
        private IServiceData _data;

        public ServicesController(IServiceData data)
        {
            _data = data;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _data.Services());
        }
    }
}
