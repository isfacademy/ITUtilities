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
    [Authorize(Roles = "Superadmin,Moderator")]
    public class isfPersonsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: isfPersons
        public ActionResult Index()
        {
            var isfPeople = db.isfPeople.Include(i => i.Branch).OrderByDescending(m => m.Rank.Order).ThenBy(s => s.MilitaryNumber);
            return View(isfPeople.ToList());
        }

        // GET: isfPersons/Create
        public ActionResult Create()
        {
            isfPerson person = new isfPerson();
            ViewBag.BranchId = new SelectList(db.IsfBranches.Where(m => m.isPseudo != true).OrderBy(s => s.OrderId), "Id", "Name");
            ViewBag.RankId = new SelectList(db.Ranks, "Id", "Name");
            return View(person);
        }

        // POST: isfPersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MilitaryNumber,RankId,Active,BranchId")] isfPerson isfPerson)
        {
            if (ModelState.IsValid)
            {
                db.isfPeople.Add(isfPerson);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.BranchId = new SelectList(db.IsfBranches.Where(m => m.isPseudo != true).OrderBy(s => s.OrderId), "Id", "Name", isfPerson.BranchId);
            ViewBag.RankId = new SelectList(db.Ranks, "Id", "Name", isfPerson.RankId);
            return View(isfPerson);
        }

        // GET: isfPersons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            isfPerson isfPerson = db.isfPeople.Find(id);
            if (isfPerson == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.IsfBranches.Where(m => m.isPseudo != true).OrderBy(s => s.OrderId), "Id", "Name", isfPerson.BranchId);
            ViewBag.RankId = new SelectList(db.Ranks, "Id", "Name", isfPerson.RankId);
            return View(isfPerson);
        }

        // POST: isfPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MilitaryNumber,RankId,Active,BranchId")] isfPerson isfPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(isfPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.IsfBranches.Where(m => m.isPseudo != true).OrderBy(s => s.OrderId), "Id", "Name", isfPerson.BranchId);
            ViewBag.RankId = new SelectList(db.Ranks, "Id", "Name", isfPerson.RankId);
            return View(isfPerson);
        }

        // GET: isfPersons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            isfPerson isfPerson = db.isfPeople.Find(id);
            if (isfPerson == null)
            {
                return HttpNotFound();
            }
            return View(isfPerson);
        }

        // POST: isfPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            isfPerson isfPerson = db.isfPeople.Find(id);
            db.isfPeople.Remove(isfPerson);
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
