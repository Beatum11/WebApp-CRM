using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web_Service.Controllers
{
    public class LogOutController : Controller
    {
        #region Basic set-up

        private readonly SignInManager<IdentityUser> SignInManager;

        public LogOutController(SignInManager<IdentityUser> signInManager)
        {
            SignInManager = signInManager;
        }

        #endregion



        public IActionResult Index()
        {
            return View();
        }


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoggingOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Main", new {area = ""});
        }
    }
}
