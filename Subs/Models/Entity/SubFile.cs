using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace Subs.Models.Entity
{
    public class SubFile
    {
        // Eigindi fyrir textaskrar ------------------------------------------------------
        [Key]       // Frumlykill
        public int SubFileId { get; set; }
        [Required]  // Ekki nullable
        public string sTitle { get; set; }
        // Notandi sem sendir inn skra
        public string sFileUserName { get; set; }
        // Tungumal thydingar
        public string sSubLanguage { get; set; }
        // Gerd textaskrar - kvikmynd/thattur
        public string sSubType { get; set; }
        // Flokkur textaskrar - t.d. spennumynd/drama
        public string sGenre { get; set; }
        // Synir bara dagsetningu - tekur ut klukkuna
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? dSubDate { get; set; }
        // Slod ad mynd fyrir skrana
        public string sPicture { get; set; }
        // Lysing a thydingu
        public string sSubDescription { get; set; }
        // Slod ad textaskra
        public byte[] sFilePath { get; set; }
        // Talning a hve oft hefur verid likad vid gaedi textaskrar
        public int? iUpVote { get; set; }
        // -------------------------------------------------------------------------------

        // Adkomylyklar ------------------------------------------------------------------
        // (one-to-one) - tenging i notanda
        //[Required] // SubFile verdur ekki til ef ekki er til User
        //public virtual ApplicationUser ApplicationUser { get; set; }
        // (one-to-one) - tenging i notanda
        //[ForeignKey("RequestId")]
        //public virtual  Request    Request { get; set; }
        //public int RequestId { get; set; }
        //[ForeignKey("RequestId")]
        //public virtual Request Request { get; set; }
        //public int RequestId { get; set; }
        // (one-to-many) - SubFile a lista af Commentum
        public virtual ICollection<Comment> Comment { get; set; }
        // -------------------------------------------------------------------------------
    }
}