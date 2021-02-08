using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITUtilities.Models;

namespace ITUtilities.Controllers
{
    [Authorize(Roles = "Superadmin")]
    public class ipRecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ipRecords
        public ActionResult Index()
        {
            var ipRecords = db.IpRecords.Include(i => i.Branch);
            return View(ipRecords.ToList());
        }

        // GET: ipRecords/Create
        public ActionResult Create()
        {
            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m => m.OrderId), "Id", "Name");
            return View();
        }

        // POST: ipRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Username,Password,IP,isfBranchId")] ipRecord ipRecord)
        {
            if (ModelState.IsValid)
            {
                db.IpRecords.Add(ipRecord);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m => m.OrderId), "Id", "Name", ipRecord.isfBranchId);
            return View(ipRecord);
        }

        // GET: ipRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ipRecord ipRecord = db.IpRecords.Find(id);
            if (ipRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m => m.OrderId), "Id", "Name", ipRecord.isfBranchId);
            return View(ipRecord);
        }

        // POST: ipRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Username,Password,IP,isfBranchId")] ipRecord ipRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ipRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m => m.OrderId), "Id", "Name", ipRecord.isfBranchId);
            return View(ipRecord);
        }

        // GET: ipRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ipRecord ipRecord = db.IpRecords.Find(id);
            if (ipRecord == null)
            {
                return HttpNotFound();
            }
            return View(ipRecord);
        }

        // POST: ipRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ipRecord ipRecord = db.IpRecords.Find(id);
            db.IpRecords.Remove(ipRecord);
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
