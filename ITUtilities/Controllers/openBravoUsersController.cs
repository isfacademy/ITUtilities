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
    public class openBravoUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: openBravoUsers
        public ActionResult Index(string IsForAdmin)
        {
            var openBravoUsers = db.openBravoUsers.Include(o => o.Branch);

            if (IsForAdmin== "IsForAdmin")
            {
                openBravoUsers  = openBravoUsers.Where(b => b.Branch.IsforAdmin == true).OrderBy(s => s.Branch.Name);

                // to check in view , when press the create button only show application Name
                ViewBag.IsForAdmin = true;
            }
            else
            {
                openBravoUsers = openBravoUsers.Where(b => b.Branch.IsforAdmin == false).OrderBy(s => s.Branch.OrderId);
                ViewBag.IsForAdmin = false;

            }


            return View(openBravoUsers);
        }

        



        // GET: openBravoUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            openBravoUser openBravoUser = db.openBravoUsers.Find(id);
            if (openBravoUser == null)
            {
                return HttpNotFound();
            }
            return View(openBravoUser);
        }

        // GET: openBravoUsers/Create
        public ActionResult Create(string IsForAdmin)
        {
            bool isfor = false;
            if (IsForAdmin == "IsForAdmin")
            {
                isfor = true;
                ViewBag.IsForAdmin = true;
            }
            else
            {
                ViewBag.IsForAdmin = false;
            }
            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true && m.IsforAdmin == isfor).OrderBy(m => m.OrderId), "Id", "Name");
            return View();
        }

        // POST: openBravoUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Username,Password,isfBranchId")] openBravoUser openBravoUser , string IsForAdmin)
        {
            if (ModelState.IsValid)
            {
                db.openBravoUsers.Add(openBravoUser);
                db.SaveChanges();
                return RedirectToAction("Create", new { IsForAdmin = IsForAdmin });
            }

            // if an error displayed
            bool isfor = false;
            if (IsForAdmin == "IsForAdmin")
            {
                isfor = true;
            }
           
            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true && m.IsforAdmin == isfor).OrderBy(m => m.OrderId), "Id", "Name");

            return View(openBravoUser);
        }

        // GET: openBravoUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            openBravoUser openBravoUser = db.openBravoUsers.Find(id);
            if (openBravoUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m => m.OrderId), "Id", "Name", openBravoUser.isfBranchId);
            return View(openBravoUser);
        }

        // POST: openBravoUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Username,Password,isfBranchId")] openBravoUser openBravoUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(openBravoUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.isfBranchId = new SelectList(db.IsfBranches.Where(m => m.Visible == true).OrderBy(m => m.OrderId), "Id", "Name", openBravoUser.isfBranchId);
            return View(openBravoUser);
        }

        // GET: openBravoUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            openBravoUser openBravoUser = db.openBravoUsers.Find(id);
            if (openBravoUser == null)
            {
                return HttpNotFound();
            }
            return View(openBravoUser);
        }

        // POST: openBravoUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            openBravoUser openBravoUser = db.openBravoUsers.Find(id);
            db.openBravoUsers.Remove(openBravoUser);
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
