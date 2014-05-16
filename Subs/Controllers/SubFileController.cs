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
                ViewBag.Message = "Enginn skrá var valinn";
				return View(model);
			}
                SubFile SubFile = new SubFile();
            if(SubFile.sFilePath == null)
            {   /* Þetta virkjar til að passa að enginn ýti á senda nema að vekja skrá fyrst*/
                ViewBag.Message = "Enginn skrá var valinn";
                return View(model); 
            }
                byte[] uploadFile = new byte[model.sFilePath.InputStream.Length];
                model.sFilePath.InputStream.Read(uploadFile, 0, uploadFile.Length);

                SubFile.sTitle = model.sFilePath.FileName;
                SubFile.sFilePath = uploadFile;
                SubFile.sSubType = model.sSubType;
                SubFile.sSubType = model.sSubType;
                SubFile.sSubDescription = model.sSubDescription;
             SubFile.sGenre = model.sGenre;
          
                // Setja skra i gagnagrunn
            
                SubFile_m_repository.InsertSubFile(SubFile);
                // Vista breytingar i gagnagrunni
                SubFile_m_repository.SaveChanges();

					//return RedirectToAction("SubFileInfo", new { id = SubFile.SubFileId });

                ViewBag.Message = "Skrá hefur verið hlaðið upp - Takk fyrir";
                    
             
                return View("Upload");
            }
		// Skoda upplysingar um skra - sott med ID
		[HttpGet]
		public ActionResult FileInfo(int? id)
		{
			// Saekja skra eftir ID
			var file = SubFile_m_repository.GetSubFilesById(id);
			// Setja umbedna skra inn i ViewModel
			//if (id.HasValue)
			//{
				SubFileViewModel model = new SubFileViewModel
				{
					SubFileId = file.SubFileId,
					sTitle = file.sTitle,
					sFileUserName = file.sFileUserName,
					sSubLanguage = file.sSubLanguage,
					sSubType = file.sSubType,
					sGenre = file.sGenre,
					//dSubDate = file.dSubDate,
					sPicture = file.sPicture,
					sSubDescription = file.sSubDescription,
					iUpVote = file.iUpVote
				};
				return View(model);
			//}
			//return View("Index"); // skoða þetta betur hvað ef 
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
	}
}