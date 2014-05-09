using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Subs.App_Data.DataAccessLayer;
using Subs.Models.Interface;
using Subs.Models.Repository;
using Subs.Models.ViewModel;

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

        public ActionResult Search()
        {
            ViewBag.Message = "Beiðni-Leit";
            return View();
        }


        public ActionResult FileForm()
        {
            ViewBag.Message = "Senda inn skrá";
            return View();
        }

        public ActionResult NewForm()
        {
            ViewBag.Message = "Ný beiðni";

            return View();
        }

        public ActionResult ViewForm()
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

        // Ekki breyta thessu !!!!!!!!!!!!!!!!!!!!!!!!!!!! DatabasePrufa
        [Authorize]
        public ActionResult Info(/*SettingsViewModel model*/)
        {
            //SettingsViewModel model = new SettingsViewModel();

            //var name = model.sUsername;

            //return View(name);

            //return View(model);

            return View(Client_m_repository.GetClients());
        }
    }
}