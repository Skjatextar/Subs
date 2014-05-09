using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Subs.App_Data.DataAccessLayer;
using Subs.Models.Interface;

namespace Subs.Controllers
{
    public class HomeController : Controller
    {
        // Tennging i gagnagrunn - breytist thegar repos. koma inn
        private SubDataContext db = new SubDataContext();

        //private IClientRepository c_repository = null;

        //public HomeController()
        //{
            
        //}

        //public HomeController(IClientRepository rep)
        //{
            
        //}

        public ActionResult Index()
        {
            return View(db.Clients.ToList());
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
        public ActionResult Info()
        {
            return View(db.Clients.ToList());
        }
    }
}