using AstrophotographyBlog.Data.Models;
using AstrophotographyBlog.Services.Data.Contracts;
using AstrophotographyBlog.Web.Controllers;
using AstrophotographyBlog.Web.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AstrophotographyBlog.Web.Tests.Controllers
{
    [TestFixture]
    class PostControllerTest
    {
        //[Test]
        //public void IndexShould_ReturnCorrentModelView()
        //{
        //    var postList = new List<Post>()
        //    {
        //        new Post()
        //    };

        //    var mockPostService = new Mock<IPostService>();
        //    var mockUserService = new Mock<IUserService>();
        //    mockPostService.Setup(x => x.GetAll()).Returns(postList);

        //    var sut = new PostController(mockPostService.Object, mockUserService.Object);
        //    var result = sut.Index() as ViewResult;
        //    var model = result.Model as PostViewModel;

        //    //Assert.AreEqual(postList.Count, result.Model.);

        //}

        [Test]
        public void DetailsShould_ReturnCorrectModelView()
        {
            var mockPost = new Post()
            {
                Id = Guid.NewGuid(),
                Title = "testTitle",
                ImageUrl = "testUrl",
                ImageTarget = "testTarget",
                ImageInfo = "testInfo",
                Location = "TestLocation",
                Time = DateTime.Now,
                AuthorId = "authorId",
                Author = new Data.Models.Users.User()
                {
                    UserName = "testUser",
                    Id = "testUserId"
                }
            };

            var mockPostService = new Mock<IPostService>();
            var mockUserService = new Mock<IUserService>();
            mockPostService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(mockPost);


            var sut = new PostController(mockPostService.Object, mockUserService.Object);
            var result = sut.Details(Guid.NewGuid()) as ViewResult;
            var model = result.Model as PostViewModel;

            Assert.AreEqual(mockPost.Title, model.Title);

        }

        [Test]
        public void DetailsShould_ReturnHttpNotFound_WhenNoMathingPostWereFound()
        {
            var mockPostService = new Mock<IPostService>();
            var mockUserService = new Mock<IUserService>();
            mockPostService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns((Post)null);


            var sut = new PostController(mockPostService.Object, mockUserService.Object);

            Assert.IsInstanceOf<HttpNotFoundResult>(sut.Details(Guid.NewGuid()));
        }
    }
}
