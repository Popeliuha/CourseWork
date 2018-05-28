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
    public class TicketsController : Controller
    {
        private SecondDBEntities db = new SecondDBEntities();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Clients).Include(t => t.TimeTable).Include(t => t.Workers);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tickets tickets = db.Tickets.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            return View(tickets);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.BuyerId = new SelectList(db.Clients, "ClientId", "ClientName");
            ViewBag.PassageId = new SelectList(db.TimeTable, "PassageId", "TimeTableName");
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketId,WorkerId,BuyerId,PassageId,SoldCHeck,TimeOfSell,Reservation")] Tickets tickets)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(tickets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuyerId = new SelectList(db.Clients, "ClientId", "ClientName", tickets.BuyerId);
            ViewBag.PassageId = new SelectList(db.TimeTable, "PassageId", "TimeTableName", tickets.PassageId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", tickets.WorkerId);
            return View(tickets);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tickets tickets = db.Tickets.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuyerId = new SelectList(db.Clients, "ClientId", "ClientName", tickets.BuyerId);
            ViewBag.PassageId = new SelectList(db.TimeTable, "PassageId", "TimeTableName", tickets.PassageId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", tickets.WorkerId);
            return View(tickets);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketId,WorkerId,BuyerId,PassageId,SoldCHeck,TimeOfSell,Reservation")] Tickets tickets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tickets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuyerId = new SelectList(db.Clients, "ClientId", "ClientName", tickets.BuyerId);
            ViewBag.PassageId = new SelectList(db.TimeTable, "PassageId", "TimeTableName", tickets.PassageId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", tickets.WorkerId);
            return View(tickets);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tickets tickets = db.Tickets.Find(id);
            if (tickets == null)
            {
                return HttpNotFound();
            }
            return View(tickets);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tickets tickets = db.Tickets.Find(id);
            db.Tickets.Remove(tickets);
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
