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
    public class HubStationsController : Controller
    {
        private SecondDBEntities db = new SecondDBEntities();

        // GET: HubStations
        public ActionResult Index()
        {
            var hubStations = db.HubStations.Include(h => h.Routs);
            return View(hubStations.ToList());
        }

        // GET: HubStations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HubStations hubStations = db.HubStations.Find(id);
            if (hubStations == null)
            {
                return HttpNotFound();
            }
            return View(hubStations);
        }

        // GET: HubStations/Create
        public ActionResult Create()
        {
            ViewBag.RouteId = new SelectList(db.Routs, "RouteId", "RouteName");
            return View();
        }

        // POST: HubStations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HubStationsId,StationName,RouteId")] HubStations hubStations)
        {
            if (ModelState.IsValid)
            {
                db.HubStations.Add(hubStations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RouteId = new SelectList(db.Routs, "RouteId", "RouteName", hubStations.RouteId);
            return View(hubStations);
        }

        // GET: HubStations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HubStations hubStations = db.HubStations.Find(id);
            if (hubStations == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.Routs, "RouteId", "RouteName", hubStations.RouteId);
            return View(hubStations);
        }

        // POST: HubStations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HubStationsId,StationName,RouteId")] HubStations hubStations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hubStations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.Routs, "RouteId", "RouteName", hubStations.RouteId);
            return View(hubStations);
        }

        // GET: HubStations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HubStations hubStations = db.HubStations.Find(id);
            if (hubStations == null)
            {
                return HttpNotFound();
            }
            return View(hubStations);
        }

        // POST: HubStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HubStations hubStations = db.HubStations.Find(id);
            db.HubStations.Remove(hubStations);
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
