using Microsoft.AspNetCore.Mvc;

namespace Web_Service.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
