using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSoft.Models.Admission
{
    public class AdmissionFrom
    {
		[Key]
		public int AID { get; set; }
		public string Name { get; set; }
		public int ClassID { get; set; }
		public string Nationality { get; set; }
		public string Religion { get; set; }
		public string Address { get; set; }
		public string DateofBirth { get; set; }
		public string Gender { get; set; }
		public string BloodGroup { get; set; }
	}
}


