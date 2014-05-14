using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subs.Models;
using Subs.Models.Interface;
using Subs.Models.Repository;
using Subs.Models.Entity;

namespace Subs.Controllers
{
	public class SubFileController : Controller
	{
		// Tennging i gagnagrunn - Tekin ut thegar repos. koma inn
		//private SubDataContext db = new SubDataContext();

		// Tengingar i gagnagrunn ---------------------------------------
		// Thetta er tenging vid Interface klasann sem tengist
		//   svo vid Repository sem tengist svo vid gagnagrunn 
		private ISubFileRepository SubFile_m_repository = null;

		// Smidur fyrir tengingar i Repositories
		public SubFileController()
		{
			SubFile_m_repository = new SubFileRepository();
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

        //public ActionResult Index()
        //{
        //    var model = SubFile_m_repository.GetSubFilesByCategory();
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Index(SubFileRepository model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    SubFile subs = new SubFile();

        //    byte[] uploadFile = new byte[model.File.InputStream.Length];
        //    model.File.InputStream.Read(uploadFile, 0, uploadFile.Length);

        //    subs.sTitle = model.File.FileName;
        //    subs.sFilePath = uploadFile;

        //    subs.FileUploadDBModels.Add(fileUploadModel);
        //    subs.SaveChanges();

        //    return Content("File Uploaded.");
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

    }
}