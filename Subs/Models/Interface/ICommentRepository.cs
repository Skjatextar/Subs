using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subs.Models.Entity;

namespace Subs.Models.Interface
{
    public interface ICommentRepository
    {
        IQueryable<Comment> GetComments();
    }
}
