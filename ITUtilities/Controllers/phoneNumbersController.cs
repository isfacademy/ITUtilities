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
    public class phoneNumbersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: phoneNumbers
        [AllowAnonymous]
        public ActionResult Index()
        {
            var phoneNumbers = db.PhoneNumbers.Include(p => p.Branch);
            return View(phoneNumbers.OrderBy(s => s.Branch.OrderId).ThenBy(x => x.Order));
        }

        // GET: phoneNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(phoneNumber);
        }

        // GET: phoneNumbers/Create
        public ActionResult Create()
        {
            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m => m.OrderId), "Id", "Name");
            return View();
        }

        // POST: phoneNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Number1,Number2,Number3,Number4,Number5,ExternalNumber,isfBranchId")] phoneNumber phoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.PhoneNumbers.Add(phoneNumber);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m => m.OrderId), "Id", "Name", phoneNumber.isfBranchId);
            return View(phoneNumber);
        }

        // GET: phoneNumbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }
            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m => m.OrderId), "Id", "Name", phoneNumber.isfBranchId);
            return View(phoneNumber);
        }

        // POST: phoneNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Number1,Number2,Number3,Number4,Number5,ExternalNumber,isfBranchId")] phoneNumber phoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phoneNumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m => m.OrderId), "Id", "Name", phoneNumber.isfBranchId);
            return View(phoneNumber);
        }

        // GET: phoneNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            if (phoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(phoneNumber);
        }

        // POST: phoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            phoneNumber phoneNumber = db.PhoneNumbers.Find(id);
            db.PhoneNumbers.Remove(phoneNumber);
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
