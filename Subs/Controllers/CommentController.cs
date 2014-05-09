using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using StudentApplication.Models;
using Subs.Models.Interface;
using Subs.Models.Repository;

namespace Subs.Controllers
{
    public class CommentController : Controller 
    {
        // Tennging i gagnagrunn - Tekin ut thegar repos. koma inn
        //private SubDataContext db = new SubDataContext();

        // Tengingar i gagnagrunn ---------------------------------------
        // Thetta er tenging vid Interface klasann sem tengist
        //   svo vid Repository sem tengist svo vid gagnagrunn 
        private ICommentRepository m_repository = null;

        // Smidur fyrir tengingar i Repositories
        public CommentController()
        {
            m_repository = new CommentRepository();
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


    }
}