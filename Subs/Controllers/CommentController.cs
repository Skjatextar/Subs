using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using StudentApplication.Models;
using Subs.Models.Interface;

namespace Subs.Controllers
{
    public class CommentController : Controller 
    {
        private readonly ICommentRepository _repo;

        public CommentController(ICommentRepository repo)
        {
            _repo = repo;
        }
    }
}