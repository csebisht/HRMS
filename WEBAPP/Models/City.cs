using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPP.Models
{
    public class CityMaster


    {
        public int Id { get; set; }
        public string City { get; set; }

        public int StateId { get; set; }

    }

    public class Sublocation {

        public int Id { get; set; }
        public int CityId { get; set; }

        public string SubLocation { get; set; }

    }


}