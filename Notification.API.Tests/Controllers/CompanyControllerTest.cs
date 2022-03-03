using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.API;
using Notification.API.Controllers;
using System.Web.Mvc;

namespace Notification.API.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CompanyController controller = new CompanyController();

            //// Act
            //ViewResult result = controller.Index() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
