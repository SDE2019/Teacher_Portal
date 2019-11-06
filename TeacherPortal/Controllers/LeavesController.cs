using Microsoft.AspNet.Identity;
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
    public class LeavesController : Controller
    {
        private TeacherDatabase db = new TeacherDatabase();

        // GET: Leaves
        public ActionResult Index()
        {
            LeaveAndDesg LD = new LeaveAndDesg();
            List<Leave> L = db.Leaves.Where(l => l.Id == System.Web.HttpContext.Current.User.Identity.Name).ToList();
            LD.leaves = L;
            Teacher T = db.Teachers.Where(l => l.Id == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault();
            LD.desg = T.Designation.Name;
            return View(LD);
        }
        // GET: Leaves/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leave leave = db.Leaves.Find(Convert.ToInt64(id));
            if (leave == null)
            {
                return HttpNotFound();
            }
            return View(leave);
        }

        // GET: Leaves/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leaves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LeaveID,LeaveDescription,TempContact,StartDate,EndDate,LeaveType,LeaveCount,ApprovalStatus")] Leave leave)
        {
            if (ModelState.IsValid)
            {
                db.Leaves.Add(leave);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leave);
        }

        // GET: Leaves/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leave leave = db.Leaves.Find(id);
            if (leave == null)
            {
                return HttpNotFound();
            }
            return View(leave);
        }

        // POST: Leaves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LeaveID,LeaveDescription,TempContact,StartDate,EndDate,LeaveType,LeaveCount,ApprovalStatus")] Leave leave)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leave).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leave);
        }

        // GET: Leaves/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leave leave = db.Leaves.Find(id);
            if (leave == null)
            {
                return HttpNotFound();
            }
            return View(leave);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Leave leave = db.Leaves.Find(id);
            db.Leaves.Remove(leave);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ApplyLeave()
        {
            return View();
        }

        // POST: Leaves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyLeave([Bind(Include = "Id,LeaveID,LeaveDescription,TempContact,StartDate,EndDate,LeaveType,LeaveCount,ApprovalStatus")] Leave leave)
        {
            if (ModelState.IsValid)
            {
                leave.Id = System.Web.HttpContext.Current.User.Identity.Name;
                leave.ApprovalStatus = "Pending";
                db.Leaves.Add(leave);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leave);
        }
        public ActionResult ApproveLeave()
        {
            {
                //Retrieve only HOD Tuple
                List<Teacher> T = db.Teachers.Where(l => l.Id == System.Web.HttpContext.Current.User.Identity.Name).ToList();
                var userTuple = T.FirstOrDefault();

                //Retrieve all tuples belonging to HOD's dept
                List<Teacher> T_All = db.Teachers.Where(l => l.Dept_Id == userTuple.Dept_Id).ToList();

                //Retrieve Leaves
                List<Leave> L = new List<Leave>();
                foreach (Teacher t in T_All)
                {
                    L.AddRange(db.Leaves.Where(l => l.Id == t.Id).ToList());
                } 
                return View(L);
            }           
        }


        public ActionResult ApproveDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leave leave = db.Leaves.Find(Convert.ToInt64(id));
            if (leave == null)
            {
                return HttpNotFound();
            }
            return View(leave);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "approve")]
        public ActionResult Approve(Leave l)
        {
            l.ApprovalStatus = "Approved";
            return RedirectToAction("ApproveLeave");
        }
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "reject")]
        public ActionResult Reject(Leave l)
        {
            l.ApprovalStatus = "Rejected";
            return RedirectToAction("ApproveLeave");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        [NonAction]
        public int getdays(DateTime? start, DateTime? end)
        {
            return (end - start).Value.Days;
        }
        [NonAction]
        public int getholidays(DateTime? start, DateTime? end)
        {
            return 0;
        }
        [NonAction]
        public LeaveCount updateLeave(DateTime start, DateTime end, string type)
        {
            LeaveCount lc = db.LeaveCounts.Find(System.Web.HttpContext.Current.User.Identity.Name);
            int days = getdays(start, end);
            int holidays = getholidays(start, end);
            switch(type)
            {
                case "CL":
                    if (lc.CL < days)
                        lc.LWP += days;
                    else
                    {
                        lc.CL -= days;
                        lc.CL = 0;
                    }
                    break;
                case "EL":
                    if (lc.EL > (days - holidays))
                        lc.EL -= (days - holidays);
                    else
                    {
                        lc.LWP = (days - holidays) - lc.EL;
                        lc.EL = 0;
                    }
                    break;
                case "ML":
                    if(lc.ML < days)
                        lc.ML -= days;
                    else
                    {
                        lc.LWP = days - lc.ML;
                        lc.ML = 0;
                    }

                    break;
                case "RH":
                    lc.RH -= days;
                    break;
                case "Commuted":
                    lc.Commuted -= days;
                    break;
            }
            return lc;
        }


    }
}
