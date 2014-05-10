using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Subs.App_Data.DataAccessLayer;
using System.ComponentModel.DataAnnotations;

namespace Subs.Models.ViewModel
{
    public class SettingsViewModel
    {
        // Tennging i gagnagrunn - breytist thegar repos. koma inn
        //private SubDataContext db = new SubDataContext();

        //public IEnumerable<Entity.Client> ClientData { get; set; }
        //public IEnumerable<Entity.Comment> CommentData { get; set; }
        //public IEnumerable<Entity.Request> RequestData { get; set; }
        //public IEnumerable<Entity.SubFile> SubFileData { get; set; }

        // Eigindi fyrir notanda ---------------------------------------------------------
        public string sUsername { get; set; }
        public string sPass { get; set; }
        public string sEmail { get; set; }
        // Notandi faer tign med ordum en her er thad taknad med tolum fra t.d. 1-5
        public int? iRanking { get; set; }
        // Synir bara dagsetningu - tekur ut klukkuna
        public DateTime? dSignupDate { get; set; }
        // Notandi getur valid um themu numerud fra t.d. 1-3
        public int? iTheme { get; set; }
        // -------------------------------------------------------------------------------
    }
}