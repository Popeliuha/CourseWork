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
    public class TrainsController : Controller
    {
        private SecondDBEntities db = new SecondDBEntities();

        // GET: Trains
        public ActionResult Index()
        {
            var trains = db.Trains.Include(t => t.Brigades);
            return View(trains.ToList());
        }

        // GET: Trains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trains trains = db.Trains.Find(id);
            if (trains == null)
            {
                return HttpNotFound();
            }
            return View(trains);
        }

        // GET: Trains/Create
        public ActionResult Create()
        {
            ViewBag.BrigadeId = new SelectList(db.Brigades, "BrigadeId", "BrigadeName");
            return View();
        }

        // POST: Trains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainId,TrainNumber,TrainType,BrigadeId,TrainAge")] Trains trains)
        {
            if (ModelState.IsValid)
            {
                db.Trains.Add(trains);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrigadeId = new SelectList(db.Brigades, "BrigadeId", "BrigadeName", trains.BrigadeId);
            return View(trains);
        }

        // GET: Trains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trains trains = db.Trains.Find(id);
            if (trains == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrigadeId = new SelectList(db.Brigades, "BrigadeId", "BrigadeName", trains.BrigadeId);
            return View(trains);
        }

        // POST: Trains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainId,TrainNumber,TrainType,BrigadeId,TrainAge")] Trains trains)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trains).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrigadeId = new SelectList(db.Brigades, "BrigadeId", "BrigadeName", trains.BrigadeId);
            return View(trains);
        }

        // GET: Trains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trains trains = db.Trains.Find(id);
            if (trains == null)
            {
                return HttpNotFound();
            }
            return View(trains);
        }

        // POST: Trains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trains trains = db.Trains.Find(id);
            db.Trains.Remove(trains);
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
