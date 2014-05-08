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
        public int      iSubFileId { get; set; }
        [Required]  // Ekki nullable
        public string   sTitle { get; set; }
        // Tungumal thydingar
        public string   sSubLanguage { get; set; }
        // Gerd textaskrar - kvikmynd/thattur
        public string   sSubType { get; set; }
        // Flokkur textaskrar - t.d. spennumynd/drama
        public string   sGenre { get; set; }
        // Synir bara dagsetningu - tekur ut klukkuna
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? dSubDate { get; set; }
        // Slod ad mynd fyrir skrana
        public string   sPicture { get; set; }
        // Lysing a thydingu
        public string   sSubDescription { get; set; }
        // Slod ad textaskra
        public string   sFilePath { get; set; }
        // Talning a hve oft hefur verid likad vid gaedi textaskrar
        public int?      iUpVote { get; set; }
        // -------------------------------------------------------------------------------

        // Adkomylyklar ------------------------------------------------------------------
        // (one-to-one) - tenging i notanda
        public string   sUsername { get; set; }
        // (one-to-one) - tenging i notanda
        public int      iRequestId { get; set; }
        // (one-to-many) - listi af umsognum
        public virtual ICollection<Comment> vComments { get; set; }
        // -------------------------------------------------------------------------------
    }
}