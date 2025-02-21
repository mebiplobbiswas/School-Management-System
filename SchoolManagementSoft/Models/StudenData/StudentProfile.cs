using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSoft.Models.StudenData
{
    public class StudentProfile
    {
        [Key]
        public int StdID { get; set; }
		public DateTime EntryDate { get; set; }
		public string StudentName { get; set; }
        public DateTime DateofBirth { get; set; }
		public int ClassID { get; set; }
		public string Roll { get; set; }
		public int GroupID { get; set; }
		public int SectionID { get; set; }
		public string Gender { get; set; }
		public string Image { get; set; }
		public string StdUniqueId { get; set; }
		public string  Group { get; set; }
		public string GuardianName { get; set; }
		public string Guardiannumber { get; set; }
		public string Email { get; set; }
		public string StudentMbNum { get; set; }
		public string PresentAddress { get; set; }
		public string AddressPermanent { get; set; }
		public string Remarks { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}
