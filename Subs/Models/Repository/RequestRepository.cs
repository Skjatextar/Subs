using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Subs.App_Data.DataAccessLayer;
using Subs.Models.Interface;

namespace Subs.Models.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private SubDataContext _context;

        public IQueryable<Models.Entity.Request> GetRequests()
        {
            return _context.Requests;
        }
    }
}