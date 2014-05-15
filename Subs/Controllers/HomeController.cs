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

        /*-------------------------------------------------------------------*/

        // Skoda upplysingar um skra - sott med ID
        [HttpGet]
        public ActionResult FileInfo(int? id)
        {   
            //// Saekja skra eftir ID
            //var file = SubFile_m_repository.GetSubFilesById(id);
            //// Setja umbedna skra inn i ViewModel
            //    SubFileViewModel model = new SubFileViewModel
            //    {
            //        SubFileId = file.SubFileId,
            //        sTitle = file.sTitle,
            //        sFileUserName = file.sFileUserName,
            //        sSubLanguage = file.sSubLanguage,
            //        sSubType = file.sSubType,
            //        sGenre = file.sGenre,
            //        //dSubDate = file.dSubDate,
            //        sPicture = file.sPicture,
            //        sSubDescription = file.sSubDescription,
            //        iUpVote = file.iUpVote
            //    };
            
            //return View(model);
            int realid = id.Value;
            var repo = SubFile_m_repository;
            var model = repo.GetSubFilesById(realid);
            if (id.HasValue)
            {
                return View(model);
            }
            return View("Index");
        }

        // Saekja skra
        [HttpGet]
        public FileContentResult FileDownload(int? id)
        {
            // Tekur inn byteArray
            byte[] fileData;
            // Skraarnafn
            string fileName;

            // Saekja skra eftir ID
            SubFile fileRecord = SubFile_m_repository.GetSubFilesByCategory().Find(id);

            fileData = (byte[])fileRecord.sFilePath.ToArray();
            fileName = fileRecord.sTitle;

            return File(fileData, "text", fileName);
        }
        /*------------------------------------------------------------*/

        public ActionResult RequestSearch()
        {
            ViewBag.Message = "Beiðni-Leit";
            var ListModel = Request_m_repository.GetRequests();

            var CategoryModel = Request_m_repository.GetRequestsByCategory();

            var result = from s in CategoryModel
                         select s.sTitle;

            return View(CategoryModel);

        }
        [HttpGet]
        public ActionResult RequestInfo(int? id)   
        {
            ViewBag.Message = "Skráarupplýsingar/Niðurhal";
            int realid = id.Value;
            var ListModel = Request_m_repository.GetRequests();
            var CategoryModel = Request_m_repository.GetRequestsByCategory();

            var result = (from requ in CategoryModel
                          where requ.RequestId == id
                          select requ).SingleOrDefault();

            if (id.HasValue)
            {
                return View(result);
            }
            return View();
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