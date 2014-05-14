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