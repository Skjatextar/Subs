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
    }
}