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

        // Saekja eina beidni eftir ID
        public Request GetRequestById(int? id)
        {
            //check for null in id

            var file = (from s in _context.Requests
                        where s.RequestId == id
                        select s).SingleOrDefault();

            return file;
        }

        // Setja beidnir a gagnagrunn
        public void InsertRequest(Request request)
        {
            _context.Requests.Add(request);
        }

        // Vista breytingar i gagnagrunn
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}