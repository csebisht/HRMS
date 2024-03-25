using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPP.Models
{
    public class CallNote
    {
        public int Id { get; set; }
        public int CallId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ActivityDate { get; set; }

        public int CallContactId { get; set; }
        public string t_ActivityDate { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }
        public int CompanyID { get; set; }
        public bool IsFollowUp { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool RemindMe { get; set; }
        public int Type { get; set; }
        public bool Status { get; set; } // 0- Pending 1- Done
    }

    public class PreviousNotes
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        
        public List<String> PreviousNote { get; set; }

    }
}