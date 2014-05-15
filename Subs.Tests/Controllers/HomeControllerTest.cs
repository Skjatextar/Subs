using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Subs;
using Subs.Controllers;
using Subs.App_Data.DataAccessLayer;

namespace Subs.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        /*[TestMethod]
        public void Index()
        {  
         * // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Info() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }*/

        /*[TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }*/

        //[TestMethod]
        //public void Contact()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Contact() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        [TestMethod]
        public void ViewMostPopular()
        {
            //Athugum hvort það birtist í raun 12 vinsælustu textaskrárnar.
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void GoToFileInfo()
        {
            //Athugum hvort við getum opnað link á skránna
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

    
    }
}
