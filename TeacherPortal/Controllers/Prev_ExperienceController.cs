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
    public class Prev_ExperienceController : Controller
    {
        private TeacherDatabase db = new TeacherDatabase();

        // GET: Prev_Experience
        public ActionResult Index()
        {
            var prev_Experience = db.Prev_Experience.Include(p => p.Teacher);
            return View(prev_Experience.ToList());
        }

        // GET: Prev_Experience/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prev_Experience prev_Experience = db.Prev_Experience.Find(id);
            if (prev_Experience == null)
            {
                return HttpNotFound();
            }
            return View(prev_Experience);
        }

        // GET: Prev_Experience/Create
        public ActionResult Create()
        {
            ViewBag.TID = new SelectList(db.Teachers, "Id", "Name");
            return View();
        }

        // POST: Prev_Experience/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employer,TID,Role,Start_Date,End_Date")] Prev_Experience prev_Experience)
        {
            if (ModelState.IsValid)
            {
                db.Prev_Experience.Add(prev_Experience);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TID = new SelectList(db.Teachers, "Id", "Name", prev_Experience.TID);
            return View(prev_Experience);
        }

        // GET: Prev_Experience/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prev_Experience prev_Experience = db.Prev_Experience.Find(id);
            if (prev_Experience == null)
            {
                return HttpNotFound();
            }
            ViewBag.TID = new SelectList(db.Teachers, "Id", "Name", prev_Experience.TID);
            return View(prev_Experience);
        }

        // POST: Prev_Experience/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employer,TID,Role,Start_Date,End_Date")] Prev_Experience prev_Experience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prev_Experience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TID = new SelectList(db.Teachers, "Id", "Name", prev_Experience.TID);
            return View(prev_Experience);
        }

        // GET: Prev_Experience/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prev_Experience prev_Experience = db.Prev_Experience.Find(id);
            if (prev_Experience == null)
            {
                return HttpNotFound();
            }
            return View(prev_Experience);
        }

        // POST: Prev_Experience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Prev_Experience prev_Experience = db.Prev_Experience.Find(id);
            db.Prev_Experience.Remove(prev_Experience);
            db.SaveChanges();
            return RedirectToAction("Index");
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
