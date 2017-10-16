using AstrophotographyBlog.Services.Data.Contracts;
using AstrophotographyBlog.Web.Models;
using AstrophotographyBlog.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AstrophotographyBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }

        [OutputCache(CacheProfile = "ShortCache")]
        public ActionResult Index()
        {
            var posts = postService.GetAll().
                Select(x => new PostViewModel()
                {
                    ID = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    ImageTarget = x.ImageTarget,
                    ImageInfo = x.ImageInfo,
                    Location = x.Location,
                    Time = x.Time,
                    DisplayName = x.Author.UserName
                })
                .ToList();

            var viewModel = new HomeViewModel()
            {
                Posts = posts
            };

            return this.View(viewModel);
        }

        [OutputCache(CacheProfile = "LongCache")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
