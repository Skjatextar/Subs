using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Subs.Models;
using Subs.Models.Entity;
using Subs.Models.Interface;
using Subs.Models.Repository;
using Subs.Models.ViewModel;

namespace Subs.Controllers
{
	public class SubFileController : Controller
	{
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

		public ActionResult Upload()
		{
			var model = new SubFileViewModel();
			return View(model);
		}

		// Senda inn skra - tekur inn ViewModel
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

			// Setja skra i gagnagrunn
			SubFile_m_repository.InsertSubFile(SubFile);
			// Vista breytingar i gagnagrunni
			SubFile_m_repository.SaveChanges();

			return Content("Skrá hefur verið hlaðið upp - Takk fyrir");
		}

		
	}
}