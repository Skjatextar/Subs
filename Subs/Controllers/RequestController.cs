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

		// Smidur fyrir tengingar i Repositories
		public RequestController()
		{
			Request_m_repository = new RequestRepository();
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
	}
}