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
    public class ScriptsController : Controller
    {
        private TeacherDatabase db = new TeacherDatabase();

        // GET: Scripts
        public ActionResult Index()
        {
            var scripts = db.Scripts.Include(s => s.Subject).Include(s => s.Teacher);
            return View(scripts.ToList());
        }

        // GET: Scripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Script script = db.Scripts.Find(id);
            if (script == null)
            {
                return HttpNotFound();
            }
            return View(script);
        }

        // GET: Scripts/Create
        public ActionResult Create()
        {
            ViewBag.Subj_Id = new SelectList(db.Subjects, "Id", "Name");
            ViewBag.TID = new SelectList(db.Teachers, "Id", "Name");
            return View();
        }

        // POST: Scripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Subj_Id,Year,TID,No_Of_Scripts")] Script script)
        {
            if (ModelState.IsValid)
            {
                db.Scripts.Add(script);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Subj_Id = new SelectList(db.Subjects, "Id", "Name", script.Subj_Id);
            ViewBag.TID = new SelectList(db.Teachers, "Id", "Name", script.TID);
            return View(script);
        }

        // GET: Scripts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Script script = db.Scripts.Find(id);
            if (script == null)
            {
                return HttpNotFound();
            }
            ViewBag.Subj_Id = new SelectList(db.Subjects, "Id", "Name", script.Subj_Id);
            ViewBag.TID = new SelectList(db.Teachers, "Id", "Name", script.TID);
            return View(script);
        }

        // POST: Scripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Subj_Id,Year,TID,No_Of_Scripts")] Script script)
        {
            if (ModelState.IsValid)
            {
                db.Entry(script).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Subj_Id = new SelectList(db.Subjects, "Id", "Name", script.Subj_Id);
            ViewBag.TID = new SelectList(db.Teachers, "Id", "Name", script.TID);
            return View(script);
        }

        // GET: Scripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Script script = db.Scripts.Find(id);
            if (script == null)
            {
                return HttpNotFound();
            }
            return View(script);
        }

        // POST: Scripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Script script = db.Scripts.Find(id);
            db.Scripts.Remove(script);
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
