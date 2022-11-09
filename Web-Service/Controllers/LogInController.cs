using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_Service.Models;

namespace Web_Service.Controllers
{
    public class LogInController : Controller
    {
        #region Basic set-up

        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly UserManager<IdentityUser> UserManager;

        public LogInController(SignInManager<IdentityUser> signInManager, 
                               UserManager<IdentityUser> userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }

        #endregion

        public IActionResult Index()
        {
            LogInUser logInUser = new LogInUser();
            return View(logInUser);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoggingIn(LogInUser logInUser)
        {
            if (ModelState.IsValid)
            {
                var identityRes = await SignInManager.PasswordSignInAsync(logInUser.UserName,
                                                                          logInUser.Password,
                                                                          logInUser.RememberMe,
                                                                          false);

                if (identityRes.Succeeded)
                    return RedirectToAction("Index", "Main", new { area = "" });
                else
                    ModelState.AddModelError("", "Invalid");

            }

            return RedirectToAction("Index");
        }
    }
}
