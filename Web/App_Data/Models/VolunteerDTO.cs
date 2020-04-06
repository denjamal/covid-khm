using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.App_Data.Models
{
    public class VolunteerDTO
    {
        public string PersoneName { get; set; }
        public string Phone { get; set; }
        public string HomeAddress { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
    }
}