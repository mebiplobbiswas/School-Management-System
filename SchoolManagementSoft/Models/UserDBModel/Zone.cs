using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSoft.Models.UserDBModel
{
    public class Zone
    {
        [Key]
        public int ZonID { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneName { get; set; }
        public string Comments { get; set; }
    }
}