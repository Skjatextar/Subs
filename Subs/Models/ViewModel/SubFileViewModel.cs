using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Subs.App_Data.DataAccessLayer;
using Subs.Models;

namespace Subs.Models.ViewModel
{
    public class SubFileViewModel
    {
        // Tennging i gagnagrunn - breytist thegar repos. koma inn
        //private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Entity.Client>  ClientData { get; set; }
        public IEnumerable<Entity.Comment> CommentData { get; set; }
        public IEnumerable<Entity.Request> RequestData { get; set; }
        public IEnumerable<Entity.SubFile> SubFileData { get; set; }
    

    }

}