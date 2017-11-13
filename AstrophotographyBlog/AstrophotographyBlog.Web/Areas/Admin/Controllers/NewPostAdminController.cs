using AstrophotographyBlog.Services.Data.Contracts;
using AstrophotographyBlog.Web.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace AstrophotographyBlog.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NewPostAdminController : Controller
    {
        private readonly IPostService postService;

        public NewPostAdminController(IPostService postService)
        {
            this.postService = postService;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var model = new IndexPostViewModel()
            {
                ID = Guid.NewGuid(),
                DisplayUserName = this.User.Identity.GetUserId()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IndexPostViewModel model)
        {
            string authorId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.postService.CreatePost(model.Title, model.ImageTarget, model.ImageUrl, model.ImageInfo, model.Location, model.Time, authorId);

            return this.RedirectToRoute("default", null);
        }
    }
}