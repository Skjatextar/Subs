using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Subs.App_Data.DataAccessLayer;
using Subs.Models;
using Subs.Models.Entity;

namespace Subs.Models.ViewModel
{
    public class SubFileViewModel
    {
        //public IEnumerable<Entity.Comment> CommentData { get; set; }
        //public IEnumerable<Entity.Request> RequestData { get; set; }
        //public IEnumerable<Entity.SubFile> SubFileData { get; set; }

        // Eigindi fyrir textaskrar ------------------------------------------------------
        public int SubFileId { get; set; }
        public string sTitle { get; set; }
        // Notandi sem sendir inn skra
        public string sFileUserName { get; set; }
        // Tungumal thydingar
        public string sSubLanguage { get; set; }
        // Gerd textaskrar - kvikmynd/thattur
        public string sSubType { get; set; }
        // Flokkur textaskrar - t.d. spennumynd/drama
        public string sGenre { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dSubDate { get; set; }
        // Slod ad mynd fyrir skrana
        public string sPicture { get; set; }
        // Lysing a thydingu
        public string sSubDescription { get; set; }
        // Slod ad textaskra
        //public byte[] sFilePath { get; set; }
        // Talning a hve oft hefur verid likad vid gaedi textaskrar
        public int? iUpVote { get; set; }
        // -------------------------------------------------------------------------------

        // Skraarnafn
        [DisplayName("Velja skrá")]
        public HttpPostedFileBase sFilePath { get; set; }


        public virtual ICollection<Comment> Comment { get; set; }
    }
}