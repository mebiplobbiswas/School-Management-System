using Microsoft.AspNet.Identity;
using SchoolManagementSoft.Models.UserDBModel;
using SchoolManagementSoft.Models.CommonDataForAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagementSoft.Models.DBMODEL;

namespace SchoolManagementSoft.Models.CommonInformation
{
    public static class LoadComboBox
    {
        // private static BankSoftEntities db = new BankSoftEntities();
        private static ApplicationDbContext db = new ApplicationDbContext();
        private static SchoolMDBEntities db1 = new SchoolMDBEntities();



        #region Class Info
        public static SelectList LoadAllClass()
        {
            var data = new List<Class>();


            data = db.Classes.ToList();

            Dictionary<string, string> items = new Dictionary<string, string>();

            items.Add("", "Select Class Name");
            data.ForEach(x =>
            {
                items.Add(x.ClassID.ToString(), x.ClassID + "-" + x.ClassName);
            });

            return new SelectList(items, "key", "Value");
        }
        #endregion
        public static SelectList LoadAllZone()
        {
            var data = new List<Zone>();


            data = db.Zones.ToList();

            Dictionary<string, string> items = new Dictionary<string, string>();

            items.Add("", "Select Zone Name");
            data.ForEach(x =>
            {
                items.Add(x.ZoneCode, x.ZoneCode + "-" + x.ZoneName);
            });

            return new SelectList(items, "key", "Value");
        } 
       
        
        public static SelectList LoadAllSection()
        {
            var data = new List<StdSection>();


            data = db1.StdSections.ToList();

            Dictionary<string, string> items = new Dictionary<string, string>();

            items.Add("", "Select Section");
            data.ForEach(x =>
            {
                items.Add(x.SectionName, x.SectionID + "-" + x.SectionName);
            });

            return new SelectList(items, "key", "Value");
        }
        
        public static SelectList LoadAllStdID()
        {
            var data = new List<StdProfile>();

            data = db1.StdProfiles.ToList();

            Dictionary<string, string> items = new Dictionary<string, string>();

            items.Add("", "Select Student ID");
            data.ForEach(x =>
            {
                items.Add(x.StudentUniqueeID, x.StudentUniqueeID + "-" + x.StudentName);
            });

            return new SelectList(items, "key", "Value");
        } 
         public static SelectList LoadAllFType()
        {
            var data = new List<StdTType>();

            data = db1.StdTTypes.ToList();

            Dictionary<string, string> items = new Dictionary<string, string>();

            items.Add("", "Select Fees Type");
            data.ForEach(x =>
            {
                items.Add(x.FType, x.ID+"-"+x.Description);
            });

            return new SelectList(items, "key", "Value");
        } 
        
        public static SelectList LoadAllGropID()
        {
            var data = new List<StdGroup>();


            data = db1.StdGroups.ToList();

            Dictionary<string, string> items = new Dictionary<string, string>();

            items.Add("", "Select Group");
            data.ForEach(x =>
            {
                items.Add(x.GroupName, x.GroupName + "-" + x.Description);
            });

            return new SelectList(items, "key", "Value");
        }
         public static SelectList LoadAllClaName()
        {
            var data = new List<StdClass>();


            data = db1.StdClasses.ToList();

            Dictionary<string, string> items = new Dictionary<string, string>();

            items.Add("", "Select Class");
            data.ForEach(x =>
            {
                items.Add(x.ClassName, x.ClassName + "-" + x.ClassID);
            });

            return new SelectList(items, "key", "Value");
        }
        
        public static SelectList LoadAllFatherOccupation()
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("", "Select Group");          
            items.Add("Gov. Service", "Gov. Service");          
            items.Add("Private Service", "Private Serivice");          
            items.Add("Other", "Other");  
            return new SelectList(items, "key", "Value");
        }
        
        public static SelectList LoadAllBloodGroup()
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("", "Select Blood Group");
            items.Add("A+", "A+");
            items.Add("A-", "A-");
            items.Add("B+", "B+");
            items.Add("B-", "B-");
            items.Add("O+", "O+"); 
            items.Add("O-", "O-"); 
            items.Add("AB+", "AB+"); 
            items.Add("AB-", "AB-");            
            return new SelectList(items, "key", "Value");
        }
        public static SelectList LoadAllGender()
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("", "Select Gender");
            items.Add("Male", "Male");
            items.Add("Female", "Female");
            items.Add("Other", "Other");
            return new SelectList(items, "key", "Value");
        }
        
        public static SelectList LoadAllDesignation()
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("", "Select Designation");
            items.Add("Head Master", "Head Master");
            items.Add("Assistant Teacher", "Assistant Teacher");
            items.Add("Other", "Other");
            return new SelectList(items, "key", "Value");
        }
        public static SelectList LoadAllStatus()
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("", "Select Status");
            items.Add("Active", "Active");
            items.Add("Inactive", "Inactive");           
            return new SelectList(items, "key", "Value");
        }

        public static SelectList LoadAllEducation()
        {
            var data = new List<TeacherEducation>();
            data = db1.TeacherEducations.ToList();
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("", "Select Education");
            data.ForEach(x =>
            {
                items.Add(x.EducationName, x.EducationName);
            });
            return new SelectList(items, "key", "Value");
        }
        public static SelectList LoadAllMotherOccupation()
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("", "Select Group");          
            items.Add("Housewife", "Housewife");          
            items.Add("Gov. Service", "Gov. Service");          
            items.Add("Private Service", "Private Serivice");          
            items.Add("Other", "Other");  
            return new SelectList(items, "key", "Value");
        }
        
      

        public static SelectList LoadAllBranch()
        {
            var data = new List<Branch>();

            if (HttpContext.Current.User.IsInRole("SuperAdmin"))
            {
                data = db.Branches.ToList();
            }
            else
            {
                var UID = HttpContext.Current.User.Identity.GetUserId();
                var branch = db.Users.Where(s => s.Id == UID).Select(s => s.BranchCode).FirstOrDefault();

               // data = db.Branches.Where(s => s.BranchCode == branch).ToList();
                data = db.Branches.ToList();
            }

            //  data = db.Branches.ToList();

            Dictionary<string, string> items = new Dictionary<string, string>();

            items.Add("", "Select Campus");
            items.Add("All", "All");
            data.ForEach(x =>
            {
                items.Add(x.BranchCode, x.BranchCode + "-" + x.BranchName);
            });

            return new SelectList(items, "key", "Value");
        }

    }
}