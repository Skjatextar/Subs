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
        IQueryable<SubFile> GetSubFiles();
        DbSet<SubFile> GetSubFilesByCategory();
       

    }
}
