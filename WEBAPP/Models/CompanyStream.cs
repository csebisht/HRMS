using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPP.Models
{
    public class CompanyStream
    {
        public int Id { get; set; }  //[ID] 
        public int CompanyId { get; set; }//[CompanyID]
        public string CoursesId { get; set; }
        public string StreamId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string t_JsonString { get; set; }

        public string StreamName { get; set; }
        public string PayPackageID { get; set; }
        public string CourseName { get; set; }
    }

    public class EventHistory
    {

        public int ContactId { get; set; }
        public int Id { get; set; }  //[ID] 
        public int CompanyID { get; set; }//[CompanyID]
        public string Description { get; set; }
        public Nullable<DateTime> EventDate { get; set; }
        public string t_EventDate { get; set; }
        public bool Status { get; set; }
        public string Visitor { get; set; }
        public int EventTypeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

    }

    public class EventMaster
    {
        public int EventId { get; set; }
        public string EventType { get; set; }
    }
}