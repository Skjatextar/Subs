using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subs.Models.Entity;

namespace Subs.Models.Interface
{
    public interface ICommentRepository
    {
        IQueryable<Comment> GetComments();
        DbSet<Comment> GetCommentsByCategory();
    }
}
