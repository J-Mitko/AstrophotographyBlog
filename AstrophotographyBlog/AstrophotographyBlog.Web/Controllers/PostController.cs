using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AstrophotographyBlog.Data.Models;
using AstrophotographyBlog.Services.Data.Contracts;
using Microsoft.AspNet.Identity;
using AstrophotographyBlog.Web.Models;

namespace AstrophotographyBlog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly IUserService userService;

        public PostController(IPostService postService, IUserService userService)
        {
            this.postService = postService;
            this.userService = userService;
        }
        // GET: Posts
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View(this.postService.GetAll().ToList());
        //}

        // GET: Posts/Details/5
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            var getPost = this.postService.GetById(id);
            if (getPost == null)
            {
                return HttpNotFound();
            }

            var model = new PostViewModel()
            {
                ID = getPost.Id,
                Title = getPost.Title,
                ImageUrl = getPost.ImageUrl,
                ImageTarget = getPost.ImageTarget,
                ImageInfo = getPost.ImageInfo,
                Location = getPost.Location,
                Time = getPost.Time,
                DisplayName = getPost.Author.UserName

            };

            return View(model);
        }

        // GET: Posts/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Posts/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(PostViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        this.postService.CreatePost(model.Title, model.ImageTarget, model.ImageUrl, model.ImageInfo,
        //            model.Location, model.Time, this.User.Identity.GetUserId());
        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}

        // GET: Posts/Edit/5
        // public ActionResult Edit(Guid id)
        // {
        //     if (id == null)
        //     {
        //         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //     }
        //     Post post = this.postService.GetById(id);
        //     if (post == null)
        //     {
        //         return HttpNotFound();
        //     }
        //     return View(post);
        // }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Edit([Bind(Include = "Id,Title,ImageTarget,ImageUrl,ImageInfo,Location,Time,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] Post post)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         db.Entry(post).State = EntityState.Modified;
        //         db.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return View(post);
        // }

        // GET: Posts/Delete/5
        // public ActionResult Delete(Guid? id)
        // {
        //     if (id == null)
        //     {
        //         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //     }
        //     Post post = db.Posts.Find(id);
        //     if (post == null)
        //     {
        //         return HttpNotFound();
        //     }
        //     return View(post);
        // }
           
        // // POST: Posts/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public ActionResult DeleteConfirmed(Guid id)
        // {
        //     Post post = db.Posts.Find(id);
        //     db.Posts.Remove(post);
        //     db.SaveChanges();
        //     return RedirectToAction("Index");
        // }
           
        // protected override void Dispose(bool disposing)
        // {
        //     if (disposing)
        //     {
        //         db.Dispose();
        //     }
        //     base.Dispose(disposing);
        // }
    }
}
