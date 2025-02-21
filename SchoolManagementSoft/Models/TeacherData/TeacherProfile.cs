using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSoft.Models.TeacherData
{
    public class TeacherProfile
    {
		[Key]
        public int TPID { get; set; }
        public string Name { get; set; }
		public int DesignationID { get; set; }
		public int EducationID { get; set; }
        public DateTime DOF { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string BloodGroup { get; set; }
        public string PersentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime GovernmentJoiningDate { get; set; }
        public DateTime Presentjoiningdate { get; set; }
    }
}

