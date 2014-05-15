using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Subs.App_Data.DataAccessLayer;
using Subs.Models.Entity;

namespace Subs.Models.ViewModel
{
    public class RequestViewModel
    {
        //public IEnumerable<Entity.Comment> CommentData { get; set; }
        //public IEnumerable<Entity.Request> RequestData { get; set; }
        //public IEnumerable<Entity.SubFile> SubFileData { get; set; }

        // Eigindi fyrir beidnir ---------------------------------------------------------
        public int RequestId { get; set; }
        public string sRequesterUsername { get; set; }
        public string sTitle { get; set; }
        // Tungumal sem a ad thyda i
        public string sLanguageTo { get; set; }
        // Tungumal sem a ad thyda fra
        public string sLanguageFrom { get; set; }
        // Gerd textaskrar - kvikmynd/thattur
        public string sSubType { get; set; }
        // Talning a hve oft hefur verid likad vid beidni (thrystingur a thydingu)
        public int? iUpVote { get; set; }
        // Synir bara dagsetningu - tekur ut klukkuna
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? dRequestDate { get; set; }
        // Slod ad mynd fyrir skrana
        public string sPicture { get; set; }
        // Lysing/texti fyrir beidni
        public string sRequestDescription { get; set; }
        // -------------------------------------------------------------------------------


        // Eigindi fyrir textaskrar ------------------------------------------------------
        public int SubFileId { get; set; }
        //public string sTitle { get; set; }
        // Notandi sem sendir inn skra
        public string sFileUserName { get; set; }
        // Tungumal thydingar
        public string sSubLanguage { get; set; }
        // Gerd textaskrar - kvikmynd/thattur
        //public string sSubType { get; set; }
        // Flokkur textaskrar - t.d. spennumynd/drama
        public string sGenre { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dSubDate { get; set; }
        // Slod ad mynd fyrir skrana
        //public string sPicture { get; set; }
        // Lysing a thydingu
        public string sSubDescription { get; set; }
        // Slod ad textaskra
        //public byte[] sFilePath { get; set; }
        // Talning a hve oft hefur verid likad vid gaedi textaskrar
        //public int? iUpVote { get; set; }
        // -------------------------------------------------------------------------------

        // Skraarnafn
        [DisplayName("Velja skrá")]
        public HttpPostedFileBase sFilePath { get; set; }


        //public Request Request { get; set; }
        //public SubFile SubFile { get; set; }

        // Adkomulyklar ------------------------------------------------------------------
        // (one-to-one) - tenging i textaskra
        //[Required] // Request verdur ekki til ef ekki er til SubFile
        //public virtual SubFile SubFile { get; set; }
        // (one-to-many) - Request a lista af Commentum
        //public virtual ICollection<Comment> Comment { get; set; }
        // (one-to-one) - tenging i notanda
        //[Required] // Request verdur ekki til ef ekki er til User
        //public virtual ApplicationUser ApplicationUser { get; set; }
        // -------------------------------------------------------------------------------
    }
}