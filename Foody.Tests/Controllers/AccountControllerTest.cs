using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Foody.Controllers;

namespace Foody.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
