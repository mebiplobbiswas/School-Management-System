using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagementSoft.Models.CommonInformation
{
    public class DataModelDV
    {
        public DateTime ADate { get; set; }
        public string StudentUniqueeID { get; set; }
        public string ClassName { get; set; }
        public string StdSectionName { get; set; }
        public string GroupName { get; set; }
        public decimal AFee { get; set; }
        public decimal MFee { get; set; }
        public string Note { get; set; }
        public DateTime SysDate { get; set; }
        public string CreateBy { get; set; }

    }
}