using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Subs.Models.Entity
{
    public class Client
    {
        // Eigindi fyrir notanda ---------------------------------------------------------
        [Key]       // Frumlykill
        public string   sUsername { get; set; }
        [Required]  // Ekki nullable
        public string   sPass { get; set; }
        [Required]  // Ekki nullable
        public string   sEmail { get; set; }
        // Notandi faer tign med ordum en her er thad taknad med tolum fra t.d. 1-5
        public int?      iRanking { get; set; }
        // Synir bara dagsetningu - tekur ut klukkuna
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? dSignupDate { get; set; }
        // Notandi getur valid um themu numerud fra t.d. 1-3
        public int?      iTheme { get; set; }
        // -------------------------------------------------------------------------------

        // Adkomulyklar ------------------------------------------------------------------
        // (one-to-many) - listi af beidnum
        public virtual ICollection<Request> vRequests { get; set; }
        // (one-to-many) - listi af skram
        public virtual ICollection<SubFile> vSubFiles { get; set; }
        // (one-to-many) - listi af umsognum
        public virtual ICollection<Comment> vComments { get; set; }
        // -------------------------------------------------------------------------------
    }
}