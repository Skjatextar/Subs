using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subs.Models.Interface;

namespace Subs.Controllers
{
    public class RequestController : Controller
    {
        //
        // GET: /Request/
        
        private readonly IRequestRepository _repo;

        public RequestController(IRequestRepository repo)
        {
            _repo = repo;
        }
	}
}