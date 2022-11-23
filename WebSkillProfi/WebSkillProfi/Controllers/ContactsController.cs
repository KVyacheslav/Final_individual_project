using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using WebSkillProfi.Data;
using WebSkillProfi.Interfaces;
using WebSkillProfi.Models;

namespace WebSkillProfi.Controllers
{
    public class ContactsController : Controller
    {
        private IContactData _data;

        public ContactsController(IContactData data)
        {
            _data = data;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _data.Contacts());
        }
    }
}
