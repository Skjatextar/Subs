using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Subs.App_Data.DataAccessLayer;
using Subs.Models.Interface;

namespace Subs.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _repo;

        public ClientController(IClientRepository repo)
        {
            _repo = repo;
        }
	}
}