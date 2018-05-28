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
    public class BrigadesController : Controller
    {
        private SecondDBEntities db = new SecondDBEntities();

        // GET: Brigades
        public ActionResult Index()
        {
            var brigades = db.Brigades.Include(b => b.Departments);
            return View(brigades.ToList());
        }

        // GET: Brigades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brigades brigades = db.Brigades.Find(id);
            if (brigades == null)
            {
                return HttpNotFound();
            }
            return View(brigades);
        }

        // GET: Brigades/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Brigades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrigadeId,DepartmentId,BrigadeName")] Brigades brigades)
        {
            if (ModelState.IsValid)
            {
                db.Brigades.Add(brigades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", brigades.DepartmentId);
            return View(brigades);
        }

        // GET: Brigades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brigades brigades = db.Brigades.Find(id);
            if (brigades == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", brigades.DepartmentId);
            return View(brigades);
        }

        // POST: Brigades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrigadeId,DepartmentId,BrigadeName")] Brigades brigades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brigades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", brigades.DepartmentId);
            return View(brigades);
        }

        // GET: Brigades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brigades brigades = db.Brigades.Find(id);
            if (brigades == null)
            {
                return HttpNotFound();
            }
            return View(brigades);
        }

        // POST: Brigades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brigades brigades = db.Brigades.Find(id);
            db.Brigades.Remove(brigades);
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
