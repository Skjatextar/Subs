using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subs.Models.Interface;
using Subs.Models.Repository;
using Subs.Models.Entity;

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
              
        public ActionResult RequestSubmit()
        {
            return View(new Request());
        }
        public ActionResult Create(FormCollection formData)
        {
           var ListModel = Request_m_repository.GetRequests();
              Request s = new Request();
            s.RequestId = ( from Request in ListModel
					        select Request.RequestId ).Max( ) + 1;
            UpdateModel(s);

            return RedirectToAction("Index");
        }
       
	}
}