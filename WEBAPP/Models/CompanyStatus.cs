using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPP.Models
{
    public class CompanyStatus
    {
        public int Id { get; set; }  //[ID] 
        public int CompanyID { get; set; }//[CompanyID]
        public string CompanyYear { get; set; }

        public string CompanyDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}