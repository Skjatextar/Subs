using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Subs;
using Subs.App_Data.DataAccessLayer;
using Subs.Models.Interface;
using Subs.Models.Repository;
using Subs.Models.Entity;
using Subs.Models.ViewModel;
using Subs.Migrations;
using System.IO;



namespace Subs.Controllers
{
    public class HomeController : Controller
    {
        // Tennging i gagnagrunn - Tekin ut thegar repos. koma inn
        //private SubDataContext db = new SubDataContext();

        // Thetta eru tengingar vid Interface klasana sem tengjast
        //   svo vid Repository sem tengjast svo vid gagnagrunn 
        //private IClientRepository Client_m_repository = null;
        private ICommentRepository Comment_m_repository = null;
        private IRequestRepository Request_m_repository = null;
        private ISubFileRepository SubFile_m_repository = null;

        // Smidur fyrir tengingar i Repositories
        public HomeController()
        {
            //Client_m_repository  = new ClientRepository();
            Comment_m_repository = new CommentRepository();
            Request_m_repository = new RequestRepository();
            SubFile_m_repository = new SubFileRepository();
        }

        // Thetta er tilbuid fyrir mock-database ------------------------
        // Notad vid einingaprofanir
        //public HomeController(IClientRepository rep)
        //{
        //    m_repository = rep;
        //}
        // --------------------------------------------------------------

        public ActionResult Index() /*Search  leitar í DB */
        {            
             var ListModel = SubFile_m_repository.GetSubFiles();
             var CategoryModel = SubFile_m_repository.GetSubFilesByCategory();


             var result = from s in CategoryModel
                          select s.sTitle;


             return View(CategoryModel);

        }
        public ActionResult FileForm()
        {
            ViewBag.Message = "Skoða beiðni";
            return View();
        }





        public ActionResult About()
        {
            ViewBag.Message = "Um okkur";

            return View();
        }

        public ActionResult Instructions()
        {
            ViewBag.Message = "Leiðbeiningar";

            return View();
        }

        public ActionResult MostPopular() /* Sýnir vinsælast á indexsíðu */
        {
            var ListModel = SubFile_m_repository.GetSubFiles();
            var CategoryModel = SubFile_m_repository.GetSubFilesByCategory();

            //var result = from s in CategoryModel
            //             select s.iUpVote;

            return View(CategoryModel);
        }
        public ActionResult Newest() /* Sýnir nýjast á indexsíðu */
        {  
            var ListModel = SubFile_m_repository.GetSubFiles();
            var CategoryModel = SubFile_m_repository.GetSubFilesByCategory();

            //var result = from s in CategoryModel
              //           select s.dSubDate;

            return View(CategoryModel);
        }

    }
}