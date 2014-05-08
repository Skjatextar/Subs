using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Subs.App_Data.DataAccessLayer;

namespace Subs.Models.ViewModel
{
    public class RequestSearchModel
    {
        // Tennging i gagnagrunn - breytist thegar repos. koma inn
        private SubDataContext db = new SubDataContext();

        public IEnumerable<Subs.Models.Entity.Client>  ClientData { get; set; }
        public IEnumerable<Subs.Models.Entity.Comment> CommentData { get; set; }
        public IEnumerable<Subs.Models.Entity.Request> RequestData { get; set; }
        public IEnumerable<Subs.Models.Entity.SubFile> SubFileData { get; set; }
    }
}