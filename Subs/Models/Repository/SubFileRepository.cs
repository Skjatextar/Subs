using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Subs.App_Data.DataAccessLayer;
using Subs.Models.Entity;
using Subs.Models.Interface;

namespace Subs.Models.Repository
{
    public class SubFileRepository : ISubFileRepository
    {
        private SubDataContext _context = new SubDataContext();

        public IQueryable<SubFile> GetSubFiles()
        {
            return _context.SubFiles;
        }
    }
}