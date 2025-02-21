using AutoMapper;
using Microsoft.AspNet.Identity;
using SchoolManagementSoft.Models;
using SchoolManagementSoft.Models.CommonInformation;
using SchoolManagementSoft.Models.DBMODEL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSoft.Controllers.StudenFloder
{
    public class NewClassAdmissionController : Controller
    {
        private ApplicationDbContext db1 = new ApplicationDbContext();
        private SchoolMDBEntities db = new SchoolMDBEntities();
        DateTime cdt = DateTime.Now.Date;
        // GET: NewClassAdmission
        public ActionResult NewClassAdmission()
        {
            ViewBag.StdID = LoadComboBox.LoadAllStdID();
            ViewBag.sectionID = LoadComboBox.LoadAllSection();
            ViewBag.GroupId = LoadComboBox.LoadAllGropID();            
            ViewBag.ClName = LoadComboBox.LoadAllClaName();
            return View();
        }

        public JsonResult Add(DataModelDV model)
        {
            var UID = User.Identity.GetUserId();
            var branch = db1.Users.Where(s => s.Id == UID).Select(s => s.BranchCode).FirstOrDefault();           
            var admissioncheck = db.StdAdmissions.Where(s => s.StudentUniqueeID == model.StudentUniqueeID && s.ADate.Value.Year==model.ADate.Year).FirstOrDefault();


            if (admissioncheck==null)
            {
                model.SysDate = DateTime.Now;
                model.CreateBy = HttpContext.User.Identity.Name;
                Mapper.CreateMap<DataModelDV, StdAdmission>();
                var stdadd = Mapper.Map<DataModelDV, StdAdmission>(model);
                var stddata = db.StdAdmissions.Add(stdadd);
                db.SaveChanges();

                var stdcheck = db.StdProfiles.Where(s => s.StudentUniqueeID == model.StudentUniqueeID).FirstOrDefault();
                stdcheck.ClassName = model.ClassName;
                stdcheck.StdSectionName = model.StdSectionName;
                stdcheck.Fee = model.MFee;
                stdcheck.GroupName = model.GroupName;
                stdcheck.Updatedate = DateTime.Now;
                db.Entry(stdcheck).State = EntityState.Modified;
                db.SaveChanges();
                return Json(stddata, JsonRequestBehavior.AllowGet);
            }
            else
            {
               // var message = "All Ready this student Admitted !";
                return Json(1, JsonRequestBehavior.AllowGet);
            }
           

            //#region  Log 
            //ActivityLogInfo.SaveUserLog(ref db, new ActivityLogInfo(model.SlNo.ToString(), "Deposit Received", ScreenName.Save, branch, HttpContext.User.Identity.Name, DateTime.Now, "" + model.Cr + "Tk. Credit to" + model.CustAccNo + "", smsstatus));
            //#endregion

           
            //  return Json(new { MemberData }, JsonRequestBehavior.AllowGet);
        }

    }
}