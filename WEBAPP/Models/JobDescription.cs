using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBAPP.Models
{
    public class JobDescription
    {
        public int Id { get; set; }  //[ID] 
        public int CompanyID { get; set; }//[CompanyID]
        public string Title { get; set; }//[Title]
        public string Year { get; set; } //[Year]
        public string jdYear { get; set; }
        [AllowHtml]
        public string jdDescription { get; set; } //[Description]
        public string CreatedBy { get; set; }//[CreatedBy]
        public DateTime CreatedOn { get; set; }//[CreatedOn]
        public DateTime UpdatedOn { get; set; }//[UpdatedOn]
        public string UpdatedBy { get; set; }//[UpdatedBy]
        public bool IsDeleted { get; set; }//[IsDeleted]
        public bool IsActive { get; set; }//[IsActive]

        public string Type { get; set; }//[IsActive]
    }
}