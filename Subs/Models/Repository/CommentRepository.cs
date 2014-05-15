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
    public class CommentRepository : ICommentRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public IQueryable<Comment> GetComments()
        {
            return _context.Comments;
        }

        public DbSet<Comment> GetCommentsByCategory()
        {
            return _context.Comments;
        }

        // Saekja eina umsogn eftir ID
        public Comment GetCommentById(int? id)
        {
            //check for null in id

            var comment = (from s in _context.Comments
                        where s.CommentId == id
                        select s).SingleOrDefault();

            return comment;
        }

        // Setja umsagnir a gagnagrunn
        public void InsertComment(Comment comment)
        {
            _context.Comments.Add(comment);
        }

        // Vista breytingar i gagnagrunn
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}