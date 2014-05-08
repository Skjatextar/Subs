using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Subs.App_Data.DataAccessLayer;
using Subs.Models.Interface;

namespace Subs.Models.Repository
{
    public class SubFileRepository : ISubFileRepository
    {
        private SubDataContext _context;

        public IQueryable<Models.Entity.SubFile> GetSubFiles()
        {
            return _context.SubFiles;
        }
    }
}