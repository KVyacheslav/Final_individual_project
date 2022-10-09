using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using WebApiSkillProfi.AuthApp;
using WebApiSkillProfi.Enums;
using System.Collections.Generic;

namespace WebApiSkillProfi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // POST api/<AccountController>
        [HttpPost]
        public string Login(UserLogin model)
        {
            var user = _userManager.FindByNameAsync(model.UserName).Result;

            if (user is null)
                return "False";

            return _signInManager.CheckPasswordSignInAsync(user, model.Password, false).Result.Succeeded.ToString();

        }

        [HttpPost("{userName}")]
        public async Task<string> GetRole(string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;

            if (user is null)
                return "null";

            try
            {
                var roles = await _userManager.GetRolesAsync(user);

                return roles[0];
            }
            catch
            {
                return "User";
            }
        }

        [HttpGet("users")]
        public IEnumerable<string> GetUsers()
        {
            var names = new List<string>();
            var users = _userManager.Users;
            foreach (var user in users)
            {
                names.Add(user.UserName);
            }

            return names;
        }
    }
}
