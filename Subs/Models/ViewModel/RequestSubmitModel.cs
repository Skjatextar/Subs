using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Subs.App_Data.DataAccessLayer;

namespace Subs.Models.ViewModel
{
    public class RequestSubmitModel
    {

        public string RequestTitel { get; set; }
       // public bool RequestLanguage { get; set; }
       // public bool RequstType { get; set; }
        public string RequestDescription { get; set; }
    }
}