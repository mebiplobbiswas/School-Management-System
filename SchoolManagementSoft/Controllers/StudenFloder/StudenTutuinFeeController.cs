using AutoMapper;
using Microsoft.AspNet.Identity;
using SchoolManagementSoft.Models;
using SchoolManagementSoft.Models.CommonInformation;
using SchoolManagementSoft.Models.DBMODEL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSoft.Controllers.StudenFloder
{
    public class StudenTutuinFeeController : Controller
    {
        private ApplicationDbContext db1 = new ApplicationDbContext();
        private SchoolMDBEntities db = new SchoolMDBEntities();
        DateTime cdt = DateTime.Now.Date;
        // GET: StudenTutuinFee
        public ActionResult StudenTutuinFee()
        {
            ViewBag.StdID = LoadComboBox.LoadAllStdID();
            ViewBag.FtypeName = LoadComboBox.LoadAllFType();

            var stdTudinlist = db.VTutuionCollectionLists.Where(s => s.PDate == cdt).ToList();
            return View(stdTudinlist);
        }
        
        public ActionResult StudenTutuinFee2()
        {
            ViewBag.StdID = LoadComboBox.LoadAllStdID();
            ViewBag.FtypeName = LoadComboBox.LoadAllFType();

            var stdTudinlist = db.VTutuionCollectionLists.Where(s => s.PDate == cdt).ToList();
            return View(stdTudinlist);
        }

        public JsonResult Add(StdTution model)
        {
            var UID = User.Identity.GetUserId();
            var branch = db1.Users.Where(s => s.Id == UID).Select(s => s.BranchCode).FirstOrDefault();

            model.Pmonth = model.PDate.Value.Month.ToString("MMM");
            model.ReceivedBy = HttpContext.User.Identity.Name;
            model.SysTime = DateTime.Now;
            //Mapper.CreateMap<DataModelDV, StdAdmission>();
            //var stdadd = Mapper.Map<DataModelDV, StdAdmission>(model);
            var stddata = db.StdTutions.Add(model);
            db.SaveChanges();

            return Json(stddata, JsonRequestBehavior.AllowGet);

            //#region  Log 
            //ActivityLogInfo.SaveUserLog(ref db, new ActivityLogInfo(model.SlNo.ToString(), "Deposit Received", ScreenName.Save, branch, HttpContext.User.Identity.Name, DateTime.Now, "" + model.Cr + "Tk. Credit to" + model.CustAccNo + "", smsstatus));
            //#endregion
            //  return Json(new { MemberData }, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Delete(int id)
        //{
        //    StdTution unit = db.StdTutions.Where(c => c.SlNo == id).FirstOrDefault();
        //    db.StdTutions.Remove(unit);
        //    db.SaveChanges();
        //    // return Json(brand, JsonRequestBehavior.AllowGet);
        //    return View();
        //}

        public ActionResult Delete(int id)
        {
            if (id ==0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var  unit = db.StdTutions.Where(c => c.SlNo == id).FirstOrDefault();
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StdTution leaveReg = db.StdTutions.Where(c => c.SlNo == id).FirstOrDefault();
            db.StdTutions.Remove(leaveReg);
            db.SaveChanges();
            return RedirectToAction("StudenTutuinFee");
        }


    }
}