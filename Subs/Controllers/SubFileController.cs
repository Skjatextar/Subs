using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subs.Models;
using Subs.Models.Entity;
using Subs.Models.Interface;
using Subs.Models.Repository;
using Subs.Models.ViewModel;

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

        //public ActionResult Index()
        //{
        //    var model = SubFile_m_repository.GetSubFilesByCategory();
        //    return View(model);
        //}

		public ActionResult Upload()
		{
			var model = new SubFileViewModel();
			return View(model);
		}

		[HttpPost]
		public ActionResult Upload(SubFileViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			SubFile SubFile = new SubFile();

			byte[] uploadFile = new byte[model.sFilePath.InputStream.Length];
			model.sFilePath.InputStream.Read(uploadFile, 0, uploadFile.Length);

			SubFile.sTitle = model.sFilePath.FileName;
			SubFile.sFilePath = uploadFile;

			SubFile_m_repository.InsertSubFile(SubFile);
			SubFile_m_repository.SaveChanges();

			return Content("File Uploaded.");
		}

		public ActionResult Info()
		{
		    var model = new SubFileViewModel();

			return View(model);
		}

		public FileContentResult FileDownload(int? id)
		{
			byte[] fileData;
			string fileName;

			SubFile fileRecord = SubFile_m_repository.GetSubFilesByCategory().Find(id);

			fileData = (byte[])fileRecord.sFilePath.ToArray();
			fileName = fileRecord.sTitle;

			return File(fileData, "text", fileName);
		}
    }
}