using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Subs.Controllers;

namespace Subs.Tests.Controllers
{
    [TestClass]
    public class RequestControllerTest
    {
        [TestMethod]
        public void RequestSearch()

        {
            // Arrange
            RequestController controller = new RequestController();

            //  Act
            ViewResult result = controller.RequestSearch() as ViewResult;

            //  Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RequestInfo()
        {
            // Arrange
            RequestController controller = new RequestController();

            //  Act
            ViewResult result = controller.RequestInfo() as ViewResult;

            //  Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RequestSubmit()
        {
            // Arrange
            RequestController controller = new RequestController();

            //  Act
            ViewResult result = controller.RequestSubmit() as ViewResult;

            //  Assert
            Assert.IsNotNull(result);
        }
    }
}
