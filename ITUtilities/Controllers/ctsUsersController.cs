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
    public class ctsUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ctsUsers
        public ActionResult Index(string sortOrder)
        {
            var ctsUsers = db.CtsUsers.Include(c => c.Branch);
            return View(ctsUsers.OrderBy(s => s.Branch.OrderId));
        }


        // GET: ctsUsers/Create
        public ActionResult Create()
        {
            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m=>m.OrderId), "Id", "Name");
            return View();
        }

        // POST: ctsUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Username,Password,isfBranchId")] ctsUser ctsUser)
        {
            if (ModelState.IsValid)
            {
                db.CtsUsers.Add(ctsUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m => m.OrderId), "Id", "Name", ctsUser.isfBranchId);
            return View(ctsUser);
        }

        // GET: ctsUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctsUser ctsUser = db.CtsUsers.Find(id);
            if (ctsUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m => m.OrderId), "Id", "Name", ctsUser.isfBranchId);
            return View(ctsUser);
        }

        // POST: ctsUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Username,Password,isfBranchId")] ctsUser ctsUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ctsUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m => m.OrderId), "Id", "Name", ctsUser.isfBranchId);
            return View(ctsUser);
        }

        // GET: ctsUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctsUser ctsUser = db.CtsUsers.Find(id);
            if (ctsUser == null)
            {
                return HttpNotFound();
            }
            return View(ctsUser);
        }

        // POST: ctsUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ctsUser ctsUser = db.CtsUsers.Find(id);
            db.CtsUsers.Remove(ctsUser);
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
