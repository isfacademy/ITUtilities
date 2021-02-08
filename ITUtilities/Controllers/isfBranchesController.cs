using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITUtilities.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ITUtilities.Controllers
{
    [Authorize(Roles = "Superadmin")]
    public class isfBranchesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: isfBranches
        public ActionResult Index()
        {
            var isfBranches = db.IsfBranches.OrderBy(m => m.OrderId).Include(i => i.Parent);
            return View(isfBranches.ToList());
        }
        [AllowAnonymous]
        public ActionResult Tree()
        {
            var isfBranches = db.IsfBranches.Where(x => x.Id != 16).OrderBy(m => m.OrderId).Include(i => i.Parent);
            return View(isfBranches.ToList());
        }

        // GET: isfBranches/Create
        public ActionResult Create()
        {
            isfBranch branch = new isfBranch();
            branch.OrderId = 0;
            ViewBag.ParentId = new SelectList(db.IsfBranches, "Id", "Name");
            return View(branch);
        }

        // POST: isfBranches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,OrderId,isPseudo,ParentId")] isfBranch isfBranch)
        {
            if (ModelState.IsValid)
            {
                db.IsfBranches.Add(isfBranch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentId = new SelectList(db.IsfBranches, "Id", "Name", isfBranch.ParentId);
            return View(isfBranch);
        }

        // GET: isfBranches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            isfBranch isfBranch = db.IsfBranches.Find(id);
            if (isfBranch == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.IsfBranches, "Id", "Name", isfBranch.ParentId);
            return View(isfBranch);
        }

        // POST: isfBranches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,OrderId,isPseudo,ParentId")] isfBranch isfBranch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(isfBranch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(db.IsfBranches, "Id", "Name", isfBranch.ParentId);
            return View(isfBranch);
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
