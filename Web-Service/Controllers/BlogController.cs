using Microsoft.AspNetCore.Mvc;
using Web_Service.Models;

namespace Web_Service.Controllers
{
    public class BlogController : Controller
    {

        #region Basic Set-Up

        private ContentDbContext context;

        public BlogController(ContentDbContext Context)
        {
            context = Context;
        }

        public IActionResult Index()
        {
            return View(context?.BlogPosts?.ToList());
        }

        #endregion

        #region Showing a post
        public IActionResult ShowPost(int id)
        {
            var post = context?.BlogPosts?.Where(context => context.Id == id).FirstOrDefault();
            return View(post);
        }

        #endregion

        #region Adding a post

        public IActionResult AddPostPanel()
        {
            var post = new BlogPost();
            return View(post);
        }

        public IActionResult AddPost(BlogPost post)
        {
            context?.BlogPosts?.Add(post);
            context?.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region Deleting a post

        public IActionResult DeletePost(int id)
        {
            var post = context?.BlogPosts?.Where(p => p.Id == id).FirstOrDefault();
            if (post != null)
            {
                context?.BlogPosts?.Remove(post);
                context?.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion
    }
}
