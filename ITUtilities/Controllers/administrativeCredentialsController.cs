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
    public class administrativeCredentialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: administrativeCredentials
        public ActionResult Index()
        {
            return View(db.administrativeCredentials.ToList());
        }

        // GET: administrativeCredentials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            administrativeCredential administrativeCredential = db.administrativeCredentials.Find(id);
            if (administrativeCredential == null)
            {
                return HttpNotFound();
            }
            return View(administrativeCredential);
        }

        // GET: administrativeCredentials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: administrativeCredentials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,IP,URL,Name,Username,Password,PhoneNumber,Email,Notes")] administrativeCredential administrativeCredential)
        {
            if (ModelState.IsValid)
            {
                db.administrativeCredentials.Add(administrativeCredential);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrativeCredential);
        }

        // GET: administrativeCredentials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            administrativeCredential administrativeCredential = db.administrativeCredentials.Find(id);
            if (administrativeCredential == null)
            {
                return HttpNotFound();
            }
            return View(administrativeCredential);
        }

        // POST: administrativeCredentials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,IP,URL,Name,Username,Password,PhoneNumber,Email,Notes")] administrativeCredential administrativeCredential)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrativeCredential).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrativeCredential);
        }

        // GET: administrativeCredentials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            administrativeCredential administrativeCredential = db.administrativeCredentials.Find(id);
            if (administrativeCredential == null)
            {
                return HttpNotFound();
            }
            return View(administrativeCredential);
        }

        // POST: administrativeCredentials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            administrativeCredential administrativeCredential = db.administrativeCredentials.Find(id);
            db.administrativeCredentials.Remove(administrativeCredential);
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
