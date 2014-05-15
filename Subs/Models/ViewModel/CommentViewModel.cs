using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Subs.App_Data.DataAccessLayer;
using Subs.Models.Entity;

namespace Subs.Models.ViewModel
{
    public class CommentViewModel
    {
        //public IEnumerable<Entity.Comment> CommentData { get; set; }
        //public IEnumerable<Entity.Request> RequestData { get; set; }
        //public IEnumerable<Entity.SubFile> SubFileData { get; set; }


        // Eigindi fyrir umsagnir --------------------------------------------------------
        public int CommentId { get; set; }
        public string sCommenterUsername { get; set; }
        public string sCommentText { get; set; }
        // Synir bara dagsetningu - tekur ut klukkuna
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
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