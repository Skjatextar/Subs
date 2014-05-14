using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Subs.App_Data.DataAccessLayer;
using Subs.Models;

namespace Subs.Models.ViewModel
{
    public class SubFileViewModel
    {
        public IEnumerable<Entity.Comment> CommentData { get; set; }
        public IEnumerable<Entity.Request> RequestData { get; set; }
        public IEnumerable<Entity.SubFile> SubFileData { get; set; }
    
        [DisplayName("Velja skrá")]
        public HttpPostedFileBase sFilePath { get; set; }
    }

}