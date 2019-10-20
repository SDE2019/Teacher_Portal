using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeacherPortal.Models;

namespace TeacherPortal.Controllers
{
    [Authorize]
    public class QualificationsController : Controller
    {
        private TeacherDatabase db = new TeacherDatabase();

        // GET: Qualifications
        public ActionResult Index()
        {
            var qualifications = db.Qualifications.Where(q => q.Teacher.Id == User.Identity.Name );
            return View(qualifications.ToList());
        }

        // GET: Qualifications/Details/5
        public ActionResult Details()
        {
            string id = User.Identity.Name;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var qualification = db.Qualifications.Where(q => q.TID == id).ToList();
            if (qualification.Count() == 0)
            {
                return RedirectToAction("Create");
            }
            return View(qualification);
        }

        // GET: Qualifications/Create
        public ActionResult Create()
        { 
            return View();
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UG_PG_PHD,University_School,YOP,Specification")] Qualification qualification)
        {
            qualification.TID = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Qualifications.Add(qualification);
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(qualification);
        }

        // GET: Qualifications/Edit/5
        public ActionResult Edit()
        {
            string id = User.Identity.Name;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var qualification = db.Qualifications.Where(q => q.TID == id).ToList();
            if (qualification == null)
            {
                return HttpNotFound();
            }
            
            return View(qualification);
        }

        // POST: Qualifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UG_PG_PHD,University_School,YOP,Specification")] Qualification qualification)
        {
            qualification.TID = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Entry(qualification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            ViewBag.TID = new SelectList(db.Teachers, "Id", "Name", qualification.TID);
            return View(qualification);
        }

        // GET: Qualifications/Delete/5
        public ActionResult Delete()
        {
            string id = User.Identity.Name;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var qualification = db.Qualifications.Where(q => q.TID == id).ToList();
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Qualification qualification = db.Qualifications.Find(id);
            db.Qualifications.Remove(qualification);
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
