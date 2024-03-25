using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBAPP.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

    }
    public class Stream
    {
        public List<Course> CourseDrp { get; set; }
        public int Id { get; set; }
        public string CourseId { get; set; }
        public string StreamName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public string CourseName { get; set; }
    }
}