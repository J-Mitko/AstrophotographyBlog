using System;
using AstrophotographyBlog.Web.Areas.Admin.Controllers;
using NUnit.Framework;
using System.Web.Mvc;

namespace AstrophotographyBlog.Web.Tests.Controllers.AdminControllers
{
    [TestFixture]
    public class AdminControllerTest
    {
        [Test]
        public void IndexActionShould_ReturnViewWithoutName()
        {
            // Arrange
            var controller = new AdminController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void IndexActionShould_CallViewWithoutModel()
        {
            // Arrange
            var controller = new AdminController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(null, result.Model);
        }

        [Test]
        public void IndexActionShould_ReturnNotNullViewResult()
        {
            // Arrange
            var controller = new AdminController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
