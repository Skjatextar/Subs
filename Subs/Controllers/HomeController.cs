using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Subs.App_Data.DataAccessLayer;
using Subs.Models.Interface;
using Subs.Models.Repository;

namespace Subs.Controllers
{
    public class HomeController : Controller
    {
        // Tennging i gagnagrunn - Tekin ut thegar repos. koma inn
        //private SubDataContext db = new SubDataContext();

        // Thetta eru tengingar vid Interface klasana sem tengjast
        //   svo vid Repository sem tengjast svo vid gagnagrunn 
        private IClientRepository Client_m_repository = null;
        private ICommentRepository Comment_m_repository = null;
        private IRequestRepository Request_m_repository = null;
        private ISubFileRepository SubFile_m_repository = null;

        // Smidur fyrir tengingar i Repositories
        public HomeController()
        {
            Client_m_repository = new ClientRepository();
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
            return View(Client_m_repository.GetClients());

            //return View(db.Clients.ToList());
        }

        public ActionResult RequestSearch()
        {
            ViewBag.Message = "Beiðni-Leit";
            return View();
        }

        public ActionResult FileInfo()
        {
            ViewBag.Message = "Skráarupplýsingar/Niðurhal";
            return View();
        }

        public ActionResult FileForm()
        {
            ViewBag.Message = "Skoða beiðni";
            return View();
        }

        public ActionResult FileUpload()
        {
            ViewBag.Message = "Senda inn skrá";
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

        public ActionResult Profile()
        {
            ViewBag.Message = "Persónustillingar";

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
        public ActionResult Info()
        {
            return View(Client_m_repository.GetClients());
        }



    }
}