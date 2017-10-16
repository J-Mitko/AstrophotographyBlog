using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AstrophotographyBlog.Web;
using Microsoft.AspNet.Identity;
using AstrophotographyBlog.Web.Controllers;
using NUnit.Framework;
using AstrophotographyBlog.Services.Data.Contracts;
using Moq;
using AstrophotographyBlog.Data.Models;
using AstrophotographyBlog.Web.Models;

namespace AstrophotographyBlog.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void IndexShouldReturn_ListOfPosts()
        {
            //// Arrange
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

            var mockPostList = new List<Post>() { mockPost };

            var mockPostService = new Mock<IPostService>();
            mockPostService.Setup(x => x.GetAll()).Returns(mockPostList);
            HomeController sut = new HomeController(mockPostService.Object);

            //// Act
            var result = sut.Index() as ViewResult;
            var model = result.Model as HomeViewModel;
            //// Assert
            Assert.AreEqual(model.Posts.Count, mockPostList.Count);
        }

        [Test]
        public void About()
        {
            // Arrange
            var mockPostService = new Mock<IPostService>();
            HomeController controller = new HomeController(mockPostService.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
    }
}
