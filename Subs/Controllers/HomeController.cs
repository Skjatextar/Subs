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
        {             var ListModel = SubFile_m_repository.GetSubFiles();

             var CategoryModel = SubFile_m_repository.GetSubFilesByCategory();

 

             //var result = from s in CategoryModel
             //             select s.sTitle;



 

             return View(CategoryModel);

        }


        [HttpGet]
        public ActionResult FileInfo(int? id)
        {
            ViewBag.Message = "Skráarupplýsingar/Niðurhal";
            int realid = id.Value;
            var ListModel = SubFile_m_repository.GetSubFiles();
            var CategoryModel = SubFile_m_repository.GetSubFilesByCategory();

            //var result = (from subfile in CategoryModel
            //              where subfile.SubFileId == id
            //              select subfile).SingleOrDefault();

            //if (id.HasValue)
            //{
            //    return View(result);
            //}
            return View();
        }
    /*-------------------------------------------------------------------*/
        public ActionResult FileUpload()
        {
            ViewBag.Message = "Senda inn skrá";
            return View();
        }   
        //[HttpPost]
        //public ActionResult FileUpload(MyViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    FileUploadDBModel fileUploadModel = new FileUploadDBModel();

        //    byte[] uploadFile = new byte[model.File.InputStream.Length];
        //    model.File.InputStream.Read(uploadFile, 0, uploadFile.Length);

        //    fileUploadModel.FileName = model.File.FileName;
        //    fileUploadModel.File = uploadFile;

        //    db.FileUploadDBModels.Add(fileUploadModel);
        //    db.SaveChanges();

        //    return Content("File Uploaded.");   skoða þetta á morgun með gumma !!!!!!!!!!!!!!!!!!!!!!
        //}

        //public ActionResult Download()
        //{
        //    return View(db.FileUploadDBModels.ToList());
        //}

        //public FileContentResult FileDownload(int? id)
        //{
        //    byte[] fileData;
        //    string fileName;

        //    FileUploadDBModel fileRecord = db.FileUploadDBModels.Find(id);

        //    fileData = (byte[])fileRecord.File.ToArray();
        //    fileName = fileRecord.FileName;

        //    return File(fileData, "text", fileName);
        //}

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                string path = @"D:~\..\ProjectName\App_Data\Files";

                if (photo.ContentLength > 10240)
                {
                    ModelState.AddModelError("photo", "The size of the file should not exceed 10 KB");
                    return View();
                }

                var supportedTypes = new[] { "jpg", "jpeg", "png" };

                var fileExt = System.IO.Path.GetExtension(photo.FileName).Substring(1);

                if (!supportedTypes.Contains(fileExt))
                {
                    ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
                    return View();
                }

                photo.SaveAs(path + photo.FileName);
            }

            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------*/
        [HttpGet]
        public ActionResult info()
        {
            var model = SubFile_m_repository.GetSubFiles();
          
            return View(model);
 
        }
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
            //             select s.dSubDate;

            return View(CategoryModel);
        }
    }
}