using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using Subs.App_Data.DataAccessLayer;
using Subs.Models.Entity;
using Subs.Models.Interface;

namespace Subs.Models.Repository
{
    public class SubFileRepository : ISubFileRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IQueryable<SubFile> GetSubFiles()
        {
            return _context.SubFiles;
        }

        public DbSet<SubFile> GetSubFilesByCategory()
        {
            return _context.SubFiles;
        }


    }

}