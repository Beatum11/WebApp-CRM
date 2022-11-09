using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_Service.Models;

namespace Web_Service.Controllers
{
    public class RegisterController : Controller
    {
        #region Basic set-up

        private readonly UserManager<IdentityUser> UserManager;
        private readonly SignInManager<IdentityUser> SignInManager;

        
        public RegisterController(UserManager<IdentityUser> userManager, 
                                  SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        #endregion

        public IActionResult Index()
        {
            UserData userData = new UserData();
            return View(userData);
        }


        [HttpPost]
        public async Task<IActionResult> Registration(UserData userData)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = userData.UserName,
                    Email = userData.Email
                };

                var result = await UserManager.CreateAsync(user, userData.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Main", new { area = "" });
                }
                else
                    ModelState.AddModelError("Password", "User couldn't be created.");
            }

            return RedirectToAction("Index");

        }

        
    }
}
