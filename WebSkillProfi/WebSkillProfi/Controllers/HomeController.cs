using Microsoft.AspNetCore.Mvc;
using WebSkillProfi.Interfaces;
using WebSkillProfi.Models;
using Newtonsoft.Json.Linq;
using static System.IO.File;

namespace WebSkillProfi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRequestData _requestData;

        public HomeController(IRequestData requestData,ILogger<HomeController> logger)
        {
            _requestData = requestData;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Request request)
        {
            if (ModelState.IsValid)
            {
                _requestData.Add(request);
            }

            return View();
        }
    }
}