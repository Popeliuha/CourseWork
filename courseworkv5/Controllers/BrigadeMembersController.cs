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
    public class BrigadeMembersController : Controller
    {
        private SecondDBEntities db = new SecondDBEntities();

        // GET: BrigadeMembers
        public ActionResult Index()
        {
            var brigadeMembers = db.BrigadeMembers.Include(b => b.Brigades).Include(b => b.Workers);
            return View(brigadeMembers.ToList());
        }

        // GET: BrigadeMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrigadeMembers brigadeMembers = db.BrigadeMembers.Find(id);
            if (brigadeMembers == null)
            {
                return HttpNotFound();
            }
            return View(brigadeMembers);
        }

        // GET: BrigadeMembers/Create
        public ActionResult Create()
        {
            ViewBag.BrigadeId = new SelectList(db.Brigades, "BrigadeId", "BrigadeName");
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName");
            return View();
        }

        // POST: BrigadeMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrigadeMembersId,BrigadeId,WorkerId")] BrigadeMembers brigadeMembers)
        {
            if (ModelState.IsValid)
            {
                db.BrigadeMembers.Add(brigadeMembers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrigadeId = new SelectList(db.Brigades, "BrigadeId", "BrigadeName", brigadeMembers.BrigadeId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", brigadeMembers.WorkerId);
            return View(brigadeMembers);
        }

        // GET: BrigadeMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrigadeMembers brigadeMembers = db.BrigadeMembers.Find(id);
            if (brigadeMembers == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrigadeId = new SelectList(db.Brigades, "BrigadeId", "BrigadeName", brigadeMembers.BrigadeId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", brigadeMembers.WorkerId);
            return View(brigadeMembers);
        }

        // POST: BrigadeMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrigadeMembersId,BrigadeId,WorkerId")] BrigadeMembers brigadeMembers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brigadeMembers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrigadeId = new SelectList(db.Brigades, "BrigadeId", "BrigadeName", brigadeMembers.BrigadeId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "WorkerName", brigadeMembers.WorkerId);
            return View(brigadeMembers);
        }

        // GET: BrigadeMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrigadeMembers brigadeMembers = db.BrigadeMembers.Find(id);
            if (brigadeMembers == null)
            {
                return HttpNotFound();
            }
            return View(brigadeMembers);
        }

        // POST: BrigadeMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BrigadeMembers brigadeMembers = db.BrigadeMembers.Find(id);
            db.BrigadeMembers.Remove(brigadeMembers);
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
