using SchoolManagementSoft.Models;
using SchoolManagementSoft.Models.Admission;
using SchoolManagementSoft.Models.CommonInformation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSoft.Controllers.AdminissionFloder
{
    public class AdminissionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        DateTime cdt = DateTime.Now.Date;
        // GET: Adminission
        public ActionResult AdminisionFrom()
        {
            ViewBag.LoadAllClass = LoadComboBox.LoadAllClass();
            return View();
        }

 
        public JsonResult List()
        {

            var admissionFromData = db.admissionFroms.ToList();
            return Json(admissionFromData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(AdmissionFrom model)
        {

            var admissionFromData = db.admissionFroms.Add(model);
            db.SaveChanges();
            return Json(admissionFromData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyId(int id)
        {
            
            var admissionFromData = db.admissionFroms.Where(s => s.AID == id).FirstOrDefault();
            return Json(admissionFromData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(AdmissionFrom model)
        {
            //var admissionFromData = db.Entry(model).State = EntityState.Modified;
            var admissionFromData = db.admissionFroms.Where(s => s.AID == model.AID).SingleOrDefault();
            admissionFromData.Name = model.Name;
            admissionFromData.BloodGroup = model.BloodGroup;

            var custinfodata = db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return Json(custinfodata, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Delete(int id)
        {
            AdmissionFrom admissionFromData = db.admissionFroms.Where(c => c.AID == id).FirstOrDefault();
            db.admissionFroms.Remove(admissionFromData);
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}