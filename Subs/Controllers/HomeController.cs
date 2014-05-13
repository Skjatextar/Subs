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

        public ActionResult Index()
        {
            SubFileRepository repo = new SubFileRepository();
            var model = repo.GetSubFiles();
            return View(model);

        }


       
        [HttpGet]
        public ActionResult FileInfo(int? id)
        {  ViewBag.Message = "Skráarupplýsingar/Niðurhal";

            SubFileRepository repo = new SubFileRepository();  
  
            int realid = id.Value;
            var model = repo;
            if (id.HasValue)
            {
                return View(model);
            }
            return View("Notfound"); 
        }

        public ActionResult FileUpload()
        {
            ViewBag.Message = "Senda inn skrá";
            return View();
        }

        [HttpGet]
        public ActionResult info()
        {
            var model = SubFile_m_repository.GetSubFiles();
          
            return View(model);
 
        }
        public ActionResult RequestSearch()
        {
            ViewBag.Message = "Beiðni-Leit";

            return View(Request_m_repository.GetRequests());

            //return View();
        }

        

        public ActionResult FileForm()
        {
            ViewBag.Message = "Skoða beiðni";
            return View();
        }



        public ActionResult RequestUpload()
        {
            ViewBag.Message = "Leggja inn beiðni m/skrá";
            return View();
        }

        public ActionResult RequestSubmit()
        {
            ViewBag.Message = "Ný beiðni";
           

            return View();
        }


        //public ActionResult Profile()
        //{
        //    ViewBag.Message = "Persónustillingar";

        //    return View();
        //}



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

        public ActionResult Login()
        {
            ViewBag.Message = "Innskrá";

            return View();
        }


        public ActionResult Register()
        {
            ViewBag.Message = "Nýskrá";

            return View();
        }

        // Ekki breyta thessu !!!!!!!!!!!!!!!!!!!!!!!!!!!! DatabasePrufa
       /* [Authorize]
        public ActionResult Info()
        {
            var model = SubFile_m_repository.GetSubFiles();
            //return View(Client_m_repository.GetClients());
            return View(model);
        }

        */




        /*ekki gera neitt við þetta */
        public ViewResult Info()
        {
            throw new NotImplementedException();
        }
    }
}