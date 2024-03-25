using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPP.Models
{
    public class LoginHistory
    {
        public string Email { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedOn { get; set; }
   
    }
}