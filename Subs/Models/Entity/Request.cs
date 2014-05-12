using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Subs.Models.Entity
{
    public class Request
    {
        // Eigindi fyrir beidnir ---------------------------------------------------------
        [Key]       // Frumlykill
        public int RequestId { get; set; }
        [Required]  // Ekki nullable
        public string sRequesterUsername { get; set; }
        [Required]  // Ekki nullable
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? dRequestDate { get; set; }
        // Slod ad mynd fyrir skrana
        public string sPicture { get; set; }
        // Lysing/texti fyrir beidni
        public string sRequestDescription { get; set; }
        // -------------------------------------------------------------------------------

        // Adkomulyklar ------------------------------------------------------------------
        // (one-to-one) - tenging i textaskra
        //public virtual  SubFile SubFile { get; set; }
        public virtual ICollection<SubFile> SubFiles { get; set; }
        // (one-to-many) - listi af umsognum
        public virtual ICollection<Comment> Comments { get; set; }
        // (one-to-one) - tenging i notanda
        public virtual ApplicationUser UserName { get; set; }
        // -------------------------------------------------------------------------------
    }
}