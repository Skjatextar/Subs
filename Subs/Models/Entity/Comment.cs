using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace Subs.Models.Entity
{
    public class Comment
    {
        // Eigindi fyrir umsagnir --------------------------------------------------------
        [Key]       // Frumlykill
        public int CommentId { get; set; }
        [Required]  // Ekki nullable
        public string sCommenterUsername { get; set; }
        [Required]  // Ekki nullable
        public string sCommentText { get; set; }
        // Synir bara dagsetningu - tekur ut klukkuna
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? dCommentDate { get; set; }
        // -------------------------------------------------------------------------------

        // Adkomulyklar ------------------------------------------------------------------
        // (many-to-one) - Request a lista af Commentum
        [Required]
        public virtual Request Request { get; set; }
        // (many-to-one) - SubFile alista af Commentum
        [Required]
        public virtual SubFile SubFile { get; set; }
        // (many-to-one) - ApplicationUser a lista af Commentum
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}