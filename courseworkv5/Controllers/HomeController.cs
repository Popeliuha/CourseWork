using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace courseworkv5.Controllers
{
    public class HomeController : Controller
    {
        SecondDBEntities db = new SecondDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchChildAll()
        {
            List<Workers> workers = new List<Workers>();
            workers = db.Workers.ToList();
            return View(workers);

        }
        [HttpPost]
        public ActionResult SearchChild(int childrenCount)
        {
            List<Workers> work = new List<Workers>();
            foreach (var w in db.Workers.ToList())
            {
                if (w.ChildrenCount >= childrenCount)
                {
                    work.Add(w);
                }
            }
            return View(work);
        }

        public ActionResult WorkersAdmins()
        {
            List<Workers> workers = new List<Workers>();
            foreach(var w in db.Workers.ToList())
            {
                foreach(var a in db.Administrators.ToList())
                {
                    if (a.WorkerId == w.WorkerId)
                    {
                        workers.Add(w);
                    }
                }
            }
            return View(workers);
        }

        public ActionResult WorkersAdminsCount()
        {
            List<Workers> workers = new List<Workers>();
            List<Administrators> administrators = new List<Administrators>();
            foreach(var w in db.Workers.ToList())
            {
                workers.Add(w);
            }
            foreach(var a in db.Administrators.ToList())
            {
                administrators.Add(a);
            }
            string ret = workers.Count.ToString() + " / " + administrators.Count.ToString();
            ViewBag.ret = ret;
            return View("WorkersAdminsCount");
        }

        public ActionResult WorkersBrigadesAll()
        {
            List<Workers> workers = new List<Workers>();
            workers = db.Workers.ToList();
            return View(workers);

        }
        [HttpPost]
        public ActionResult WorkersBrigades(string brigadeId)
        {
            List<Workers> work = new List<Workers>();
            foreach (var w in db.Workers.ToList())
            {   
                foreach (var b in db.BrigadeMembers.ToList())
                if (w.WorkerId == b.BrigadeMembersId && b.BrigadeId.ToString()==brigadeId)
                {
                    work.Add(w);
                }
            }
            return View(work);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}