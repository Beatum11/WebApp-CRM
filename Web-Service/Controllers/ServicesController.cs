using Microsoft.AspNetCore.Mvc;
using Web_Service.Models;

namespace Web_Service.Controllers
{
    public class ServicesController : Controller
    {
        #region Basic Set-Up

        private ContentDbContext context;
        public ServicesController(ContentDbContext Context)
        {
            context = Context;
        }

        public IActionResult Index()
        {
            return View(context?.Services?.ToList());
        }

        #endregion

        #region Adding a Service 
        public IActionResult AddServicePanel()
        {
            Service service = new Service();
            return View(service);
        }

        public IActionResult AddService(Service service)
        {
            context?.Services?.Add(service);
            context?.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Deleting a Service
        public IActionResult DeleteService(int id)
        {
            var serv = context?.Services?.Where(p => p.Id == id).FirstOrDefault();
            if (serv != null)
            {
                context?.Services?.Remove(serv);
                context?.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion
    }
}
