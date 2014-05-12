using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subs.Models;
using Subs.Models.Interface;
using Subs.Models.Repository;

namespace Subs.Controllers
{
    public class SubFileController : Controller
    {
        // Tennging i gagnagrunn - Tekin ut thegar repos. koma inn
        //private SubDataContext db = new SubDataContext();

        // Tengingar i gagnagrunn ---------------------------------------
        // Thetta er tenging vid Interface klasann sem tengist
        //   svo vid Repository sem tengist svo vid gagnagrunn 
        private ISubFileRepository m_repository = null;

        // Smidur fyrir tengingar i Repositories
        public SubFileController()
        {
            m_repository = new SubFileRepository();
        }
        // --------------------------------------------------------------

        // Thetta er tilbuid fyrir mock-database ------------------------
        // Notad vid einingaprofanir
        //public HomeController(IClientRepository rep)
        //{
        //    m_repository = rep;
        //}
        // --------------------------------------------------------------

        // Her fyrir nedan koma Viewin ----------------------------------

        //public Action uplaod()
        //{
        //    var _uplaod = new SubFileRepository();
        //    return View(_uplaod);
        //}

        public ActionResult Index()
        {
            SubFileRepository repo = new SubFileRepository();
            var model = repo.GetSubFiles();
            return View(model);

        }
        //public SubFileRepository GetSubFileById(int id)
        //{
        //    var result = (from subfile in Subs
        //                  where subfile.iSubFileId == id
        //                select subfile).SingleOrDefault();

        //   return result;
        //}
        [HttpGet]
        public ActionResult FileInfo(int? id)
        {
            ViewBag.Message = "Skráarupplýsingar/Niðurhal";

            int realid = id.Value;
            SubFileRepository repo = new SubFileRepository();
            var model = repo.GetSubFiles();
            return View(model);
        }

        public ActionResult FileUpload()
        {
            ViewBag.Message = "Senda inn skrá";
            return View();
        }
	}
}