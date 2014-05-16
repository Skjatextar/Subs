using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Subs.Controllers;

namespace Subs.Tests.Controllers
{
    [TestClass]
    public class SubFileControllerTest
    {
        [TestMethod]
        public void Upload()
        {
            // Arrange
            SubFileController controller = new SubFileController();

            //  Act
            ViewResult result = controller.Upload() as ViewResult;

            //  Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FileInfo()
        {
            // Arrange
            SubFileController controller = new SubFileController();

            //  Act
            ViewResult result = controller.FileInfo() as ViewResult;

            //  Assert
            Assert.IsNotNull(result);
        }

        
    }
}
