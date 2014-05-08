using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subs.Models;
using Subs.Models.Interface;
using Subs.Models.Interface;

namespace Subs.Controllers
{
    public class SubFileController : Controller
    {
        //
        // GET: /SubFile/

        private readonly ISubFileRepository _repo;

        public SubFileController(ISubFileRepository repo)
        {
            _repo = repo;
        }
	}
}