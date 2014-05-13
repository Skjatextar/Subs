using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Subs.App_Data.DataAccessLayer;
using Subs.Models.Entity;
using Subs.Models.Interface;

namespace Subs.Models.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IQueryable<Request> GetRequests()
        {
            return _context.Requests;
        }

        public DbSet<Request> GetRequestsByCategory()
        {
            return _context.Requests;
        }
    }
}