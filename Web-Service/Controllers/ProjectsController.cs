using Microsoft.AspNetCore.Mvc;
using Web_Service.Models;

namespace Web_Service.Controllers
{
    public class ProjectsController : Controller
    {
        #region Basic Set-Up

        private ContentDbContext context;
        public ProjectsController(ContentDbContext Context)
        {
            context = Context;
        }
        
        public IActionResult Index()
        {
            return View(context?.Projects?.ToList());
        }

        #endregion

        #region Displaing a single project
        public IActionResult ShowProject(int id)
        {
            var proj = context?.Projects?.Where(p => p.Id == id).FirstOrDefault();
            return View(proj);
        }
        #endregion

        #region Adding a project
        public IActionResult AddProjectPanel()
        {
            Project proj = new Project();
            return View(proj);
        }

        public IActionResult AddProject(Project proj)
        {
            context?.Projects?.Add(proj);
            context?.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Deleting a project

        public IActionResult DeleteProject(int id)
        {
            var proj = context?.Projects?.Where(p => p.Id == id).FirstOrDefault();
            if (proj != null)
            {
              context?.Projects?.Remove(proj);
              context?.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion
    }
}
