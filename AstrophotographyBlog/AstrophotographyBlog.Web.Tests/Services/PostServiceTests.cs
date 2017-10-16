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

        [Test]
        public void CreatePostShould_AddNewPostToPostRepository()
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
            var mockPostRepository = new Mock<IPostRepository>();
            mockPostRepository.Setup(x => x.Add(It.IsAny<Post>()));
            var mockUserRepository = new Mock<IUserRepository>();
            var mockSaveContext = new Mock<ISaveContext>();

            var sut = new PostService(mockUserRepository.Object, mockPostRepository.Object, mockSaveContext.Object);

            sut.CreatePost(mockPost.Title, mockPost.ImageTarget, mockPost.ImageUrl, mockPost.ImageInfo, mockPost.Location, mockPost.Time, mockPost.AuthorId);
            mockPostRepository.Verify(x => x.Add(It.IsAny<Post>()), Times.Once);
        }

        [Test]
        public void CreatePostShould_CallCommitMethod()
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
            var mockPostRepository = new Mock<IPostRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            var mockSaveContext = new Mock<ISaveContext>();
            mockSaveContext.Setup(x => x.Commit());

            var sut = new PostService(mockUserRepository.Object, mockPostRepository.Object, mockSaveContext.Object);

            sut.CreatePost(mockPost.Title, mockPost.ImageTarget, mockPost.ImageUrl, mockPost.ImageInfo, mockPost.Location, mockPost.Time, mockPost.AuthorId);
            mockSaveContext.Verify(x => x.Commit(), Times.Once);
        }
    }
}
