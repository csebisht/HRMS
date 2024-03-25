using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WEBAPP.Models
{
    public class Data
    {
        public class ImportExcel
        {
            [Required(ErrorMessage = "Please select file")]
            [FileExt(Allow = ".xls,.xlsx", ErrorMessage = "Only excel file")]
            public HttpPostedFileBase file { get; set; }
        }
    }
}