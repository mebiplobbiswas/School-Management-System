﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSoft.Models.CommonDataForAll
{
    public class Designation
    {
        [Key]
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public string Description { get; set; }
    }
}