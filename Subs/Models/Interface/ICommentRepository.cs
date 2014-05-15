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
        // Saekja lista af umsognum
        IQueryable<Comment> GetComments();
        // Saekja bunka af stokum umsognum
        DbSet<Comment> GetCommentsByCategory();
        // Saekja eina umsogn eftir ID
        Comment GetCommentById(int? id);
        // Setja umsagnir a gagnagrunn
        void InsertComment(Comment comment);
        // Vista breytingar i gagnagrunn
        void SaveChanges();
    }
}
