using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPP.Models
{
    public class CompanyAddress
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string SubLocation { get; set; }
        public int CompanyID { get; set; }
        public bool IsActive { get; set; }
        public string ContactNumber { get; set; }
      
   
    }
}