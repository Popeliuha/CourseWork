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
    public class TakenBackTicketsController : Controller
    {
        private SecondDBEntities db = new SecondDBEntities();

        // GET: TakenBackTickets
        public ActionResult Index()
        {
            var takenBackTickets = db.TakenBackTickets.Include(t => t.Tickets);
            return View(takenBackTickets.ToList());
        }

        // GET: TakenBackTickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TakenBackTickets takenBackTickets = db.TakenBackTickets.Find(id);
            if (takenBackTickets == null)
            {
                return HttpNotFound();
            }
            return View(takenBackTickets);
        }

        // GET: TakenBackTickets/Create
        public ActionResult Create()
        {
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "SoldCHeck");
            return View();
        }

        // POST: TakenBackTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TakenBackTicketsId,TicketId,TakenBack,DateWhenTakenBack")] TakenBackTickets takenBackTickets)
        {
            if (ModelState.IsValid)
            {
                db.TakenBackTickets.Add(takenBackTickets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "SoldCHeck", takenBackTickets.TicketId);
            return View(takenBackTickets);
        }

        // GET: TakenBackTickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TakenBackTickets takenBackTickets = db.TakenBackTickets.Find(id);
            if (takenBackTickets == null)
            {
                return HttpNotFound();
            }
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "SoldCHeck", takenBackTickets.TicketId);
            return View(takenBackTickets);
        }

        // POST: TakenBackTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TakenBackTicketsId,TicketId,TakenBack,DateWhenTakenBack")] TakenBackTickets takenBackTickets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(takenBackTickets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "SoldCHeck", takenBackTickets.TicketId);
            return View(takenBackTickets);
        }

        // GET: TakenBackTickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TakenBackTickets takenBackTickets = db.TakenBackTickets.Find(id);
            if (takenBackTickets == null)
            {
                return HttpNotFound();
            }
            return View(takenBackTickets);
        }

        // POST: TakenBackTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TakenBackTickets takenBackTickets = db.TakenBackTickets.Find(id);
            db.TakenBackTickets.Remove(takenBackTickets);
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
