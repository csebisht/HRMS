using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPP.Models
{
    public class CompanyContact
    {
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string Designation { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }= String.Empty;
        public string PhoneNumber { get; set; }=String.Empty;
        public string Description { get; set; }
        public string Department { get; set; }
        public int CompanyID { get; set; }
        public bool IsDeleted { get; set; }
        public String DOB { get; set; }
        public string Anniversary { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string ColorCode { get; set; } = String.Empty;

    }
}