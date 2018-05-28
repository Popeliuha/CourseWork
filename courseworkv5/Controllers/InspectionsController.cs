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
    public class InspectionsController : Controller
    {
        private SecondDBEntities db = new SecondDBEntities();

        // GET: Inspections
        public ActionResult Index()
        {
            var inspection = db.Inspection.Include(i => i.Trains);
            return View(inspection.ToList());
        }

        // GET: Inspections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspection inspection = db.Inspection.Find(id);
            if (inspection == null)
            {
                return HttpNotFound();
            }
            return View(inspection);
        }

        // GET: Inspections/Create
        public ActionResult Create()
        {
            ViewBag.TrainId = new SelectList(db.Trains, "TrainId", "TrainNumber");
            return View();
        }

        // POST: Inspections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InspectionId,TrainId,Inspection1,DateOfInspection")] Inspection inspection)
        {
            if (ModelState.IsValid)
            {
                db.Inspection.Add(inspection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrainId = new SelectList(db.Trains, "TrainId", "TrainNumber", inspection.TrainId);
            return View(inspection);
        }

        // GET: Inspections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspection inspection = db.Inspection.Find(id);
            if (inspection == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrainId = new SelectList(db.Trains, "TrainId", "TrainNumber", inspection.TrainId);
            return View(inspection);
        }

        // POST: Inspections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InspectionId,TrainId,Inspection1,DateOfInspection")] Inspection inspection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrainId = new SelectList(db.Trains, "TrainId", "TrainNumber", inspection.TrainId);
            return View(inspection);
        }

        // GET: Inspections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inspection inspection = db.Inspection.Find(id);
            if (inspection == null)
            {
                return HttpNotFound();
            }
            return View(inspection);
        }

        // POST: Inspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inspection inspection = db.Inspection.Find(id);
            db.Inspection.Remove(inspection);
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
