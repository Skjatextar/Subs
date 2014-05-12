using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? dCommentDate { get; set; }
        // -------------------------------------------------------------------------------
    }
}