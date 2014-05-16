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

        // Saekja lista af skram
        public IQueryable<SubFile> GetSubFiles()
        {
            return _context.SubFiles;
        }
        // Saekja bunka af stokum skram
        public DbSet<SubFile> GetSubFilesByCategory()
        {
            return _context.SubFiles;
        }

        // Saekja eina skra eftir ID
        public SubFile GetSubFilesById(int? iId)
        {
            //check for null in id

            var file = (from s in _context.SubFiles
                        where s.SubFileId == iId
                        select s).SingleOrDefault();

            return file;
        }

        // Setja skrar a gagnagrunn
        public void InsertSubFile(SubFile subFile)
        {
            _context.SubFiles.Add(subFile);
        }

        // Vista breytingar i gagnagrunn
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}