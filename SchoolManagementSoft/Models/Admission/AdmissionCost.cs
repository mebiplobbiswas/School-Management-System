using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSoft.Models.Admission
{
    public class AdmissionCost
    {
        [Key]
        public int AdmId{ get; set; }
        public string StudentID { get; set; }
        public decimal AdmissionFee { get; set; }
        public decimal InformationServicefee { get; set; }
        public decimal Libraryfee { get; set; }
        public decimal Entertainmentfee { get; set; }
        public decimal Sportsfee { get; set; }
        public decimal Othersfee { get; set; }
    }
}

