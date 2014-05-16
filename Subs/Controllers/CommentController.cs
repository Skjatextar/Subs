using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subs.Models.Entity;
using Subs.Models.Interface;
using Subs.Models.Repository;
using Subs.Models.ViewModel;

namespace Subs.Controllers
{
    public class CommentController : Controller 
    {
        // Tennging i gagnagrunn - Tekin ut thegar repos. koma inn
        //private SubDataContext db = new SubDataContext();

        // Tengingar i gagnagrunn ---------------------------------------
        // Thetta er tenging vid Interface klasann sem tengist
        //   svo vid Repository sem tengist svo vid gagnagrunn 
        private ICommentRepository Comment_m_repository = null;

        // Smidur fyrir tengingar i Repositories
        public CommentController()
        {
            Comment_m_repository = new CommentRepository();
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

        // Skoda umsogn - sott med ID
        [HttpGet]
        public ActionResult CommentInfo(int? id)
        {
            // Saekja skra eftir ID
            var comment = Comment_m_repository.GetCommentById(id);
           
            // Setja umbedna skra inn i ViewModel
            CommentViewModel model = new CommentViewModel
            {
                CommentId = comment.CommentId,
                //sCommenterUsername = comment.ApplicationUser.UserName,
                sCommentText = comment.sCommentText,
                //dCommentDate = comment.dCommentDate,
            };

            return View(model);
        }

        
    }
}