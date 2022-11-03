using Microsoft.AspNetCore.Mvc;

namespace WebSkillProfi.Component
{
    public class LogoutViewViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
