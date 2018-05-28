using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using courseworkv5;

namespace courseworkv5.Controllers
{
    public class AdministratorsController : Controller
    {
        private SecondDBEntities db = new SecondDBEntities();

        // GET: Administrators
        public ActionResult Index()
        {
            var administrators = db.Administrators.Include(a => a.Workers);
            return View(administrators.ToList());
        }

        // GET: Administrators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrators administrators = db.Administrators.Find(id);
            if (administrators == null)
            {
                return HttpNotFound();
            }
            return View(administrators);
        }

        // GET: Administrators/Create
        public ActionResult Create()
        {
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName");
            return View();
        }

        // POST: Administrators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdministratorId,WorkerId")] Administrators administrators)
        {
            if (ModelState.IsValid)
            {
                db.Administrators.Add(administrators);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", administrators.WorkerId);
            return View(administrators);
        }

        // GET: Administrators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrators administrators = db.Administrators.Find(id);
            if (administrators == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", administrators.WorkerId);
            return View(administrators);
        }

        // POST: Administrators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdministratorId,WorkerId")] Administrators administrators)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrators).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", administrators.WorkerId);
            return View(administrators);
        }

        // GET: Administrators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrators administrators = db.Administrators.Find(id);
            if (administrators == null)
            {
                return HttpNotFound();
            }
            return View(administrators);
        }

        // POST: Administrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrators administrators = db.Administrators.Find(id);
            db.Administrators.Remove(administrators);
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
