using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSoft.Models.CommonDataForAll
{
    public class Education
    {
        [Key]
        public int EducationID { get; set; }
        public string EducationName { get; set; }
    }
}