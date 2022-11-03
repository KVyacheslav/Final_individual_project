using WebSkillProfi.AuthApp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using WebSkillProfi.Models;

namespace WebSkillProfi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            Site.LoadValuesFromJson();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new UserLogin());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.UserName,
                    model.Password,
                    false,
                    false);

                if (loginResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            //else
            //{
            //    var errors = ModelState.Values.SelectMany(v => v.Errors);
            //    foreach (var error in errors)
            //    {
            //        ModelState.AddModelError("", error.ErrorMessage);
            //    }
            //}

            ModelState.AddModelError("", "Пользователь не найден");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserRegistration());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.UserName };
                var createResult = await _userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    if (model.Role == Enums.RoleType.Admin)
                    {
                        if (!_roleManager.RoleExistsAsync("Admin").Result)
                            await _roleManager.CreateAsync(new IdentityRole("Admin"));
                        await _userManager.AddToRoleAsync(_userManager.FindByNameAsync(model.UserName).Result, "Admin");
                    }
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var identityError in createResult.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }
            }

            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
