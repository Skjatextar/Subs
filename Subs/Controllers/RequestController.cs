using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subs.Models;
using Subs.Models.Interface;
using Subs.Models.Repository;
using Subs.Models.Entity;
using Subs.Models.ViewModel;

namespace Subs.Controllers
{
	public class RequestController : Controller
	{
		// Tennging i gagnagrunn - Tekin ut thegar repos. koma inn
		//private SubDataContext db = new SubDataContext();

		// Tengingar i gagnagrunn ---------------------------------------
		// Thetta er tenging vid Interface klasann sem tengist
		//   svo vid Repository sem tengist svo vid gagnagrunn 
		private IRequestRepository Request_m_repository = null;
		private ISubFileRepository SubFile_m_repository = null;

		// Smidur fyrir tengingar i Repositories
		public RequestController()
		{
			Request_m_repository = new RequestRepository();
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

		public ActionResult RequestSearch()
		{
			ViewBag.Message = "Beiðni-Leit";
			var vCategoryModel = Request_m_repository.GetRequestsByCategory();
			return View(vCategoryModel);

		}
		[HttpGet]
		public ActionResult RequestInfo(int? iId)
		{
			ViewBag.Message = "Skráarupplýsingar/Niðurhal";
			int iRealid = iId.Value;
			var vListModel = Request_m_repository.GetRequests();
			var vCategoryModel = Request_m_repository.GetRequestsByCategory();

			var vResult = (from Request in vCategoryModel
						  where Request.RequestId == iId
						  select Request).SingleOrDefault();
			if (iId.HasValue)
			{
				return View(vResult);
			}
			return View();
		}

		[HttpGet]
		public ActionResult RequestSubmit()
		{
			var vModel = new RequestViewModel();
			return View(vModel);
		}

		[HttpPost]
		public ActionResult RequestSubmit(RequestViewModel model, Request request)
		{
			if (ModelState.IsValid)
			{
				if (request != null)
				{
					Request_m_repository.InsertRequest(request);
					Request_m_repository.SaveChanges();
					
					return RedirectToAction("RequestInfo", new { id = request.RequestId });
				}
		    }

			return View();
		}
	}
}