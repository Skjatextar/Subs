using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Subs.Models.Entity;

namespace Subs.Models.Interface
{
    public interface ISubFileRepository
    {
        // Saekja lista af skram
        IQueryable<SubFile> GetSubFiles();
        // Saekja bunka af stokum skram
        DbSet<SubFile> GetSubFilesByCategory();
        // Saekja eina skra eftir ID
        SubFile GetSubFilesById(int? id);
        // Setja skrar a gagnagrunn
        void InsertSubFile(SubFile subFile);
        // Vista breytingar i gagnagrunn
        void SaveChanges();
    }
}
