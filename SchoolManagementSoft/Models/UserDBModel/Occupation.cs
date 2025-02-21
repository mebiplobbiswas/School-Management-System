using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSoft.Models
{
    public class Occupation
    {
        [Key]
        public int OPID { get; set; }
        public string OccupationName { get; set; }
    }
}