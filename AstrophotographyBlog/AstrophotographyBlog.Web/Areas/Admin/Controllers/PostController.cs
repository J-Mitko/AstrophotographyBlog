using AstrophotographyBlog.Services.Data.Contracts;
using AstrophotographyBlog.Web.Areas.Admin.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AstrophotographyBlog.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
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
    }
}