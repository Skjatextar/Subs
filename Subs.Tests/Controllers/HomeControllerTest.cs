using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Subs;
using Subs.Controllers;
using Subs.App_Data.DataAccessLayer;
using Subs.Models.Repository;
using Subs.Models.Interface;
using Subs.Models.Entity;


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
        public void TestIndexWithMoreThan10Translations()
        {
            //Athugum hvort það birtist í raun 10 vinsælustu textaskrárnar.
            // Arrange
            List<SubFile> subfiles = new List<SubFile>();
            for (int i = 1; i <= 15; i++) 
            {
                subfiles.Add(new SubFile
                {
                    SubFileId = i,
                    sTitle = "Subfile " + i.ToString(),
                    dSubDate = DateTime.Now.AddDays(i),
                    sFileUserName = "EinnFlottur"
                });
            }
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
