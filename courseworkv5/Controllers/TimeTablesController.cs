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
    public class TimeTablesController : Controller
    {
        private SecondDBEntities db = new SecondDBEntities();

        // GET: TimeTables
        public ActionResult Index()
        {
            var timeTable = db.TimeTable.Include(t => t.Routs).Include(t => t.Trains);
            return View(timeTable.ToList());
        }

        // GET: TimeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTable.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // GET: TimeTables/Create
        public ActionResult Create()
        {
            ViewBag.RouteId = new SelectList(db.Routs, "RouteId", "RouteName");
            ViewBag.TrainNumber = new SelectList(db.Trains, "TrainId", "TrainNumber");
            return View();
        }

        // POST: TimeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PassageId,TimeTableName,TrainNumber,RouteId,DepartureTime,ArrivalTime,Canceled,Detained,TicketPrice")] TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                db.TimeTable.Add(timeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RouteId = new SelectList(db.Routs, "RouteId", "RouteName", timeTable.RouteId);
            ViewBag.TrainNumber = new SelectList(db.Trains, "TrainId", "TrainNumber", timeTable.TrainNumber);
            return View(timeTable);
        }

        // GET: TimeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTable.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.Routs, "RouteId", "RouteName", timeTable.RouteId);
            ViewBag.TrainNumber = new SelectList(db.Trains, "TrainId", "TrainNumber", timeTable.TrainNumber);
            return View(timeTable);
        }

        // POST: TimeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PassageId,TimeTableName,TrainNumber,RouteId,DepartureTime,ArrivalTime,Canceled,Detained,TicketPrice")] TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.Routs, "RouteId", "RouteName", timeTable.RouteId);
            ViewBag.TrainNumber = new SelectList(db.Trains, "TrainId", "TrainNumber", timeTable.TrainNumber);
            return View(timeTable);
        }

        // GET: TimeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTable.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // POST: TimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeTable timeTable = db.TimeTable.Find(id);
            db.TimeTable.Remove(timeTable);
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
