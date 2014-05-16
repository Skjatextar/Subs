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
using Subs.Tests.Mocks;

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
        public void TestIfFilesAreInAlphabeticalOrder()
        {
            //Athugum hvort skrarnar birtist i stafrofsrod a forsidu
            // Arrange
            List<SubFile> subfiles = new List<SubFile>();
            for (int i = 1; i <= 15; i++) 
            {
                subfiles.Add(new SubFile
                {
                    SubFileId = i,
                    sTitle = "Subfile " + i.ToString(),
                    sFileUserName = "EinnFlottur"
                });
            }

            var mockRepo = new MockSubFileRepository(subfiles);
            var controller = new HomeController(mockRepo); 
            
            // Act
            var result = controller.Index();    

            // Assert
            var viewResult = (ViewResult)result;
            

            List<SubFile> model = (viewResult.Model as IEnumerable<SubFile>).ToList();

            var expectedList = model.OrderBy(x => x.sTitle); 
            Assert.IsTrue(expectedList.SequenceEqual(model));
            

        }

        /*[TestMethod]
        public void GoToFileInfo()
        {
            //Athugum hvort við getum opnað link á skránna
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }*/

    
    }
}
