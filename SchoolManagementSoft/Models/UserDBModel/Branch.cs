using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSoft.Models.UserDBModel
{
    public class Branch
    {
        [Key]
        public int BrID { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
    }
}