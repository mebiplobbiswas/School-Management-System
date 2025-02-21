using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSoft.Models.UserDBModel
{
    public class Religion
    {
        [Key]
        public int RID { get; set; }
        public string ReligionName { get; set; }
    }
}