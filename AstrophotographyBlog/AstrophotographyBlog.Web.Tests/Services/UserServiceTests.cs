using AstrophotographyBlog.Data;
using AstrophotographyBlog.Data.Repositories.Contracts;
using AstrophotographyBlog.Services.Data;
using Moq;
using NUnit.Framework;
using System;

namespace AstrophotographyBlog.Web.Tests.Services
{
    [TestFixture]
    class UserServiceTests
    {
        [Test]
        public void GetAllShould_ReturnAllUsers()
        {
            // Arrange
            var mockPostRepository = new Mock<IPostRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            var mockSaveContext = new Mock<ISaveContext>();

            mockUserRepository.Setup(x => x.All);

            var sut = new UserService(mockUserRepository.Object, mockPostRepository.Object, mockSaveContext.Object);

            // Act
            var result = sut.GetAll();

            // Assert
            mockUserRepository.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetByIdShould_ReturnCorrectUser()
        {
            // Arrange
            var Id = Guid.NewGuid();

            var mockPostRepository = new Mock<IPostRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.Get(Id));

            var mockSaveContext = new Mock<ISaveContext>();

            var sut = new UserService(mockUserRepository.Object, mockPostRepository.Object, mockSaveContext.Object);
            var result = sut.GetById(Id);

            // Assert
            mockUserRepository.Verify(x => x.Get(Id), Times.Once);
        }
    }
}
