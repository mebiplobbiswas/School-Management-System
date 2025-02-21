using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSoft.Models.CommonDataForAll
{
    public class ClassSection
    {
        [Key]
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public string Description { get; set; }
    }
}