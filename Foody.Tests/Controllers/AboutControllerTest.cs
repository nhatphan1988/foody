using System.Web.Mvc;
using Foody.Controllers;
using NUnit.Framework;


namespace Foody.Tests.Controllers
{
    [TestFixture]
    public class AboutControllerTest
    {
        [Test]
        public void About() 
        {

            // Arrange
            AboutController controller = new AboutController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("", result.ViewName);
        }
    }
}
