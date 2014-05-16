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
			var vModel = new SubFileViewModel();
			return View(vModel);
		}

		// Senda inn skra - tekur inn ViewModel
		[HttpPost]
		public ActionResult Upload(SubFileViewModel vModel)
		{
			SubFile SubFile = new SubFile();
			int iMaxContentLength = 1024 * 1024 * 1; //1 MB
			string[] AllowedFileExtensions = new string[] { ".srt", ".SRT" };
			
			if (!ModelState.IsValid) {
				ViewBag.Message = "Enginn skrá var valinn";
				return View(vModel); 
			}
			/* passar að skráin sé ekki tóm*/
			if (vModel.sFilePath == null)
			{   
				ViewBag.Message = "Engin skrá var valin";
				return View(vModel); 
			}
			/* passar skráar endingu sé .srt eða .SRT*/
			else if (!AllowedFileExtensions.Contains(vModel.sFilePath.FileName.Substring(vModel.sFilePath.FileName.LastIndexOf('.'))))
			{
				ViewBag.Message = "Skráin þarf að vera af gerðinni: " + string.Join(", ", AllowedFileExtensions);
				return View(vModel); ;
			}
			/* passar að skráin sé ekki of stór ekki viss með hversu stór hún þarf að vera setti 1mb*/
			else if (vModel.sFilePath.ContentLength > iMaxContentLength)
			{
				ViewBag.Message = "Skráin má ekki vera stærri en  : " + (iMaxContentLength / 1024).ToString() + "MB";
				return View(vModel); 
			}
			/* sendir gögn í grunn*/
			byte[] bUploadFile = new byte[vModel.sFilePath.InputStream.Length];
			vModel.sFilePath.InputStream.Read(bUploadFile, 0, bUploadFile.Length);

			SubFile.sTitle = vModel.sFilePath.FileName;
			SubFile.sFilePath = bUploadFile;
			 SubFile.sSubType = vModel.sSubType;
			 SubFile.sSubLanguage = vModel.sSubLanguage;
			 SubFile.sSubDescription = vModel.sSubDescription;
			 SubFile.sGenre = vModel.sGenre;
			 SubFile.sFileUserName = vModel.sFileUserName;
		  
			// Setja skrár i gagnagrunn
			SubFile_m_repository.InsertSubFile(SubFile);
			 // Vista breytingar i gagnagrunni
			SubFile_m_repository.SaveChanges();

			ViewBag.Message = "Skrá hefur verið hlaðið upp - Takk fyrir";
					
			return RedirectToAction("Index", "Home");
			//return Redirect("Upload");
		}
		// Skoda upplysingar um skra - sott med ID
		[HttpGet]
		public ActionResult FileInfo(int? id)
		{   //ekki hægt að fara eftir kóðareglum með int? id sem er strongly typed
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
		}

		// Saekja skra
		[HttpGet]
		public FileContentResult FileDownload(int? id)
		{
			// Tekur inn byteArray
			byte[] bFileData;
			// Skraarnafn
			string sFileName;

			// Saekja skra eftir ID
			SubFile fileRecord = SubFile_m_repository.GetSubFilesByCategory().Find(id);

			bFileData = (byte[])fileRecord.sFilePath.ToArray();
			sFileName = fileRecord.sTitle;

			return File(bFileData, "text", sFileName);
		}
	}
}