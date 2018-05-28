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
    public class RoutsController : Controller
    {
        private SecondDBEntities db = new SecondDBEntities();

        // GET: Routs
        public ActionResult Index()
        {
            return View(db.Routs.ToList());
        }

        // GET: Routs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routs routs = db.Routs.Find(id);
            if (routs == null)
            {
                return HttpNotFound();
            }
            return View(routs);
        }

        // GET: Routs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Routs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteId,RouteName,StartPoint,LastPoint,RouteTime,Category")] Routs routs)
        {
            if (ModelState.IsValid)
            {
                db.Routs.Add(routs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(routs);
        }

        // GET: Routs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routs routs = db.Routs.Find(id);
            if (routs == null)
            {
                return HttpNotFound();
            }
            return View(routs);
        }

        // POST: Routs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RouteId,RouteName,StartPoint,LastPoint,RouteTime,Category")] Routs routs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(routs);
        }

        // GET: Routs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routs routs = db.Routs.Find(id);
            if (routs == null)
            {
                return HttpNotFound();
            }
            return View(routs);
        }

        // POST: Routs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Routs routs = db.Routs.Find(id);
            db.Routs.Remove(routs);
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
