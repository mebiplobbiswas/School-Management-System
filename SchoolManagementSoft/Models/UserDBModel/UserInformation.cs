using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagementSoft.Models.UserDBModel
{
    public class UserInformation
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string MobileNo { get; set; }
        public string PostCode { get; set; }
        public string PresentAddress { get; set; }
        public string Education { get; set; }
        public DateTime? DoB { get; set; }
        public string NID { get; set; }
    }
}