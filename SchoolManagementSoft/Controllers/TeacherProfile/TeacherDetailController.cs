using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SchoolManagementSoft.Models;
using SchoolManagementSoft.Models.CommonInformation;
using SchoolManagementSoft.Models.DBMODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSoft.Controllers.TeacherProfile
{
    public class TeacherDetailController : Controller
    {
        private ApplicationDbContext db1 = new ApplicationDbContext();
        private SchoolMDBEntities db = new SchoolMDBEntities();
        DateTime cdt = DateTime.Now.Date;
        // GET: TeacherDetail
        public ActionResult TeacherDetail()
        {
            ViewBag.BloodGroup = LoadComboBox.LoadAllBloodGroup();
            ViewBag.Gender = LoadComboBox.LoadAllGender();
            ViewBag.Education = LoadComboBox.LoadAllEducation();
            ViewBag.Designation = LoadComboBox.LoadAllDesignation();
            ViewBag.Status = LoadComboBox.LoadAllStatus();
            var teacherdata = db.TeacherProes.ToList();
            return View(teacherdata);          
        }
        
        public ActionResult TeacherDetailAll()
        {
            ViewBag.BloodGroup = LoadComboBox.LoadAllBloodGroup();
            ViewBag.Gender = LoadComboBox.LoadAllGender();
            ViewBag.Education = LoadComboBox.LoadAllEducation();
            ViewBag.Designation = LoadComboBox.LoadAllDesignation();
            ViewBag.Status = LoadComboBox.LoadAllStatus();
            var teacherdata = db.TeacherProes.ToList();
            return View(teacherdata);          
        }


        public JsonResult Add(string json, HttpPostedFileBase file)
        {
            byte[] fileData = null;
            bool flag = false;

            var UID = User.Identity.GetUserId();
            var branch = db1.Users.Where(s => s.Id == UID).Select(s => s.BranchCode).FirstOrDefault();

            string[] g = new string[5];
           // var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "dd-MMM-yyyy" };
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" };

            var rootObject = JsonConvert.DeserializeObject<RootObject>(json, dateTimeConverter);

            var total = db.TeacherProes.Count();
            if (total==0)
            {
                var sl = 1;
                rootObject.teacherdata.TeacherID = sl.ToString().PadLeft(4,'0');
            }
            else
            {
                var totalT = total + 1;
                rootObject.teacherdata.TeacherID = totalT.ToString().PadLeft(4, '0');               
            }

            rootObject.teacherdata.CreateBy = HttpContext.User.Identity.Name;
            rootObject.teacherdata.SysTime = DateTime.Now;
            //Mapper.CreateMap<DataModelDV, StdAdmission>();
            //var stdadd = Mapper.Map<DataModelDV, StdAdmission>(model);
            var stddata = db.TeacherProes.Add(rootObject.teacherdata);
            db.SaveChanges();


            if (file != null)
            {
                var fileType = Request.Files[0].ContentType;

                if (fileType == "image/jpeg" || fileType == "image/png")
                {
                    using (var binaryReader = new BinaryReader(file.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                    }
                    flag = true;

                }
                else
                {
                    ViewBag.errors = "Uploaded file type is unsupported. Only JPEG/PNG file format is Allowed";
                    //InitRequiredData();
                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }

            if (flag)
            {
                TeacherPicture pic = new TeacherPicture();
                pic.TeacherID = rootObject.teacherdata.TeacherID;
                pic.FileName = rootObject.teacherdata.Name;
                pic.Picture = fileData;
                db.TeacherPictures.Add(pic);
                db.SaveChanges();
            }
            return Json(stddata, JsonRequestBehavior.AllowGet);

            //#region  Log 
            //ActivityLogInfo.SaveUserLog(ref db, new ActivityLogInfo(model.SlNo.ToString(), "Deposit Received", ScreenName.Save, branch, HttpContext.User.Identity.Name, DateTime.Now, "" + model.Cr + "Tk. Credit to" + model.CustAccNo + "", smsstatus));
            //#endregion
            //  return Json(new { MemberData }, JsonRequestBehavior.AllowGet);
        }
    }

    public class RootObject
    {
        public TeacherPro teacherdata { get; set; }

    }
}