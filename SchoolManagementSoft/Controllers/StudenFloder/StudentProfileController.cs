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

namespace SchoolManagementSoft.Controllers.StudenFloder
{
    public class StudentProfileController : Controller
    {
        private ApplicationDbContext db1 = new ApplicationDbContext();
        private SchoolMDBEntities db = new SchoolMDBEntities();
        DateTime cdt = DateTime.Now.Date;
        // GET: StudentProfile
        public ActionResult StudentProfile()
        {
            ViewBag.BranchCode = LoadComboBox.LoadAllBranch();
            ViewBag.sectionID = LoadComboBox.LoadAllSection();
            ViewBag.GroupId = LoadComboBox.LoadAllGropID();
            ViewBag.FatherOcc = LoadComboBox.LoadAllFatherOccupation();
            ViewBag.MotherOcc = LoadComboBox.LoadAllMotherOccupation();
            ViewBag.ClName = LoadComboBox.LoadAllClaName();
            return View();
        }

        public JsonResult GetMemberInfo(string id)
        {
            //  var memberData = db.CustInfoes.Find(id);
            var memberData = db.StdProfiles.Where(s => s.StudentUniqueeID == id).FirstOrDefault();

            return Json(memberData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetImage(string custid)
        {
            var memberImage = db.CustPictures.Where(s => s.StudentUniqueeID == custid).FirstOrDefault();
            if (memberImage != null)
            {
                return File(memberImage.Picture, "image/jgp");

            }
            else
            {
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Content/img/stdphoto.jpg";
                byte[] filedata = System.IO.File.ReadAllBytes(filepath);

                return File(filedata, "stdphoto/jpg");
            }
        }
        public ActionResult Save(string json, HttpPostedFileBase file)
        {
            byte[] fileData = null;
            bool flag = false;
            var uid = User.Identity.GetUserId();
            var branchCode = db1.Users.Where(s => s.Id == uid).Select(s => s.BranchCode).FirstOrDefault();

            string[] g = new string[5];
            //var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" };
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" };

            var rootObject = JsonConvert.DeserializeObject<RootObject>(json, dateTimeConverter);

            var slno = new int();

            if (db.StdProfiles.Any())
            {
                slno = db.StdProfiles.Max(s => s.SlNo);
            }
            else
            {
                slno = 0;
            }

            var checkCust = db.StdProfiles.Where(s => s.SlNo == slno).FirstOrDefault();

            var checkCustId = "";
            if (checkCust == null)
            {
                checkCustId = "0";
            }
            else
            {
                checkCustId = checkCust.StudentUniqueeID;
            }

            rootObject.stdProfile.SlNo =slno + 1;          
            rootObject.stdProfile.BranchCode = branchCode.Replace(" ", string.Empty);
            rootObject.stdProfile.SysDate = DateTime.Now;
            rootObject.stdProfile.CreateBy = "hfhgh";
            rootObject.stdProfile.StudentUniqueeID = branchCode.Replace(" ", string.Empty) + rootObject.stdProfile.SlNo.ToString().PadLeft(6,'0');
            db.StdProfiles.Add(rootObject.stdProfile);

            //#region  Log 
            //ActivityLogInfo.SaveUserLog(ref db, new ActivityLogInfo(rootObject.custinfo.SlNo.ToString(), "MemberInfo", ScreenName.Save, rootObject.custinfo.BranchCode, HttpContext.User.Identity.Name, DateTime.Now, "" + rootObject.custinfo.CustIDNO + "Add New Member. NID No. :" + rootObject.custinfo.NID + "", 0));
            //#endregion

            db.SaveChanges();
            var id = rootObject.stdProfile.StudentUniqueeID;
          //  var id = branchCode.Replace(" ", string.Empty) + "-" + rootObject.stdProfile.SlNo.ToString();

            //if (checkCustId.Length == 7)
            //{
            //    //id = branchCode.Replace(" ", string.Empty) + "-00" + rootObject.custinfo.SlNo.ToString();
            //    id = branchCode.Replace(" ", string.Empty) + "-" + rootObject.stdProfile.SlNo.ToString().PadLeft(3, '0');
            //}
            //else if (checkCustId.Length == 9)
            //{
            //    // id = branchCode.Replace(" ", string.Empty) + "-" + rootObject.custinfo.SlNo.ToString();
            //    id = branchCode.Replace(" ", string.Empty) + "-" + rootObject.stdProfile.SlNo.ToString().PadLeft(5, '0');
            //}
            //else
            //{
            //    id = branchCode.Replace(" ", string.Empty) + "-" + rootObject.stdProfile.SlNo.ToString().PadLeft(4, '0');
            //    //For New Branch
            //    //   id = branchCode.Replace(" ", string.Empty) + "-" + rootObject.custinfo.SlNo.ToString().PadLeft(5, '0');
            //}

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
                CustPicture pic = new CustPicture();
                pic.StudentUniqueeID = id;
                pic.FileName = rootObject.stdProfile.StudentName;
                pic.Picture = fileData;
                db.CustPictures.Add(pic);
                db.SaveChanges();
            }
            return Json(id, JsonRequestBehavior.AllowGet);
        }
    }

    public class RootObject
    {
        public StdProfile stdProfile { get; set; }

    }
}