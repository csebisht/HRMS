using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPP.Models
{
    public class CompanyExtraContacts
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int CompanyId { get; set; }
    }

    public class ExtraCallNotes
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int CompanyId { get; set; }
        public DateTime ActivityDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}