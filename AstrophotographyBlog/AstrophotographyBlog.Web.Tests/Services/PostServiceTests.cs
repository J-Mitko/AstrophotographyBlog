using AstrophotographyBlog.Data;
using AstrophotographyBlog.Data.Models;
using AstrophotographyBlog.Data.Repositories.Contracts;
using AstrophotographyBlog.Services.Data;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AstrophotographyBlog.Web.Tests.Services
{
    [TestFixture]
    class PostServiceTests
    {
        [Test]
        public void GetAllShould_ReturnAllPostFromPostRepository()
        {
            var postList = new List<Post>();
            IQueryable<Post> queryPosts = postList.AsQueryable();

            var mockPostRepository = new Mock<IPostRepository>();
            mockPostRepository.Setup(x => x.All).Returns(queryPosts);
            var mockUserRepository = new Mock<IUserRepository>();
            var mockSaveContext = new Mock<ISaveContext>();

            var sut = new PostService(mockUserRepository.Object, mockPostRepository.Object, mockSaveContext.Object);

            var results = sut.GetAll();

            Assert.AreEqual(postList, results);
        }

        [Test]
        public void GetByIdShould_ReturnCorrectPost()
        {
            var id = Guid.NewGuid();
            var post = new Post();
            post.Id = id;

            var mockPostRepository = new Mock<IPostRepository>();
            mockPostRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(post);

            var mockUserRepository = new Mock<IUserRepository>();
            var mockSaveContext = new Mock<ISaveContext>();

            var sut = new PostService(mockUserRepository.Object, mockPostRepository.Object, mockSaveContext.Object);

            var result = sut.GetById(id);

            Assert.AreEqual(post.Id, result.Id);
        }
    }
}
