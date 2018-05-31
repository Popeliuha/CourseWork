using courseworkv5.Models.Home;
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
            foreach (var w in db.Workers.Where(worker=>worker.ChildrenCount>=childrenCount).ToList())
            {
                work.Add(w);
            }
           var viewModel= new SearchChildViewModel
            {
                RequestedCount = childrenCount,
                Workers = work
            };

            return View(viewModel);
        }

       

        public ActionResult WorkersAdmins()
        {
            List<Workers> workers = new List<Workers>();
            foreach (var w in db.Workers.ToList())
            {
                foreach (var a in db.Administrators.ToList())
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
            foreach (var w in db.Workers.ToList())
            {
                workers.Add(w);
            }
            foreach (var a in db.Administrators.ToList())
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
                    if (w.WorkerId == b.BrigadeMembersId && b.BrigadeId.ToString() == brigadeId)
                    {
                        work.Add(w);
                    }
            }
            return View(work);
        }

        public ActionResult WorkersDepartmentsAll()
        {
            List<Workers> workers = new List<Workers>();
            workers = db.Workers.ToList();
            return View(workers);
        }
        [HttpPost]
        public ActionResult WorkersDepartments(string departmentId)
        {
            List<Workers> work = new List<Workers>();
            foreach (var w in db.Workers.ToList())
            {
                if (w.DepartmentId.ToString() == departmentId)
                {
                    work.Add(w);
                }
            }
            return View(work);
        }

        public ActionResult WorkersInBrigadeCountAll()
        {
            List<Workers> workers = new List<Workers>();
            workers = db.Workers.ToList();
            return View(workers);

        }
        [HttpPost]
        public ActionResult WorkersInBrigadeCount(string brigadeId)
        {
            List<Workers> workersInBrigades = new List<Workers>();

            foreach (var w in db.Workers.ToList())
            {
                foreach (var b in db.BrigadeMembers.ToList())
                    if (w.WorkerId == b.BrigadeMembersId && b.BrigadeId.ToString() == brigadeId)
                    {
                        workersInBrigades.Add(w);
                    }
            }
            string ret = workersInBrigades.Count.ToString();
            ViewBag.ret = ret;
            return View("WorkersInBrigadeCount");
        }

        public ActionResult WorkersInDepartmentCountAll()
        {
            return View(db.Workers.ToList());

        }
        [HttpPost]
        public ActionResult WorkersInDepartmentCount(string departmentId)
        {
            List<Workers> workersInDepartment = new List<Workers>();

            foreach (var w in db.Workers.ToList())
            {
                if (w.DepartmentId.ToString() == departmentId)
                {
                    workersInDepartment.Add(w);
                }
            }
            string ret = workersInDepartment.Count.ToString();
            ViewBag.ret = ret;
            return View("WorkersInDepartmentCount");
        }

        public ActionResult TrainsByInspectionAll()
        {
            return View(db.Trains.ToList());
        }
        [HttpPost]
        public ActionResult TrainsByInspection(string inspectionType)
        {
            List<Trains> trains = new List<Trains>();

            foreach (var c in db.Trains.ToList())
            {
                if (c.Inspection.Count != 0)
                {
                    if (c.Inspection.First().Inspection1 == inspectionType)
                        trains.Add(c);
                }
            }
            return View(trains);
        }

        public ActionResult TrainsByRepairAll()
        {
            return View(db.Trains.ToList());
        }
        [HttpPost]
        public ActionResult TrainsByRepair(string repairType)
        {
            List<Trains> trains = new List<Trains>();

            foreach (var c in db.Trains.ToList())
            {
                if (c.Repair.Count != 0)
                {
                    if (c.Repair.First().Repair1 == repairType)
                        trains.Add(c);
                }
            }
            return View(trains);
        }

        public ActionResult TrainsByAgeAll()
        {
            return View(db.Trains.ToList());
        }
        [HttpPost]
        public ActionResult TrainsByAge(int trainAge)
        {
            List<Trains> trains = new List<Trains>();

            foreach (var c in db.Trains.ToList())
            {
                if (c.TrainAge >= trainAge)
                {
                    trains.Add(c);
                }
            }
            return View(trains);
        }

        public ActionResult TimeTableByPriceAll()
        {
            return View(db.TimeTable.ToList());
        }
        [HttpPost]
        public ActionResult TimeTableByPrice(int ticketPrice)
        {
            List<TimeTable> timeTables = new List<TimeTable>();

            foreach (var c in db.TimeTable.ToList())
            {
                if (c.TicketPrice >= ticketPrice)
                {
                    timeTables.Add(c);
                }
            }
            return View(timeTables);
        }

        public ActionResult TimeTableCanceledAll()
        {
            List<TimeTable> timeTables = new List<TimeTable>();

            foreach (var c in db.TimeTable.ToList())
            {
                if (c.Canceled == "так")
                {
                    timeTables.Add(c);
                }
            }
            return View(timeTables);
        }

        public ActionResult TimeTableDetainedAll()
        {
            List<TimeTable> timeTables = new List<TimeTable>();

            foreach (var c in db.TimeTable.ToList())
            {
                if (c.Detained == "так")
                {
                    timeTables.Add(c);
                }
            }
            return View(timeTables);
        }

        public ActionResult TimeTableCanceledByRoutsAll()
        {
            List<TimeTable> timeTables = new List<TimeTable>();

            foreach (var c in db.TimeTable.ToList())
            {
                if (c.Canceled == "так")
                {
                    timeTables.Add(c);
                }
            }
            return View(timeTables);
        }
        [HttpPost]
        public ActionResult TimeTableCanceledByRouts(string routId)
        {
            List<TimeTable> timeTables = new List<TimeTable>();

            foreach (var c in db.TimeTable.ToList())
            {
                if ((c.Canceled == "так") && (c.RouteId.ToString() == routId))
                {
                    timeTables.Add(c);
                }
            }
            return View(timeTables);
        }

        public ActionResult TimeTableDetainedByRoutsAll()
        {
            List<TimeTable> timeTables = new List<TimeTable>();

            foreach (var c in db.TimeTable.ToList())
            {
                if (c.Detained == "так")
                {
                    timeTables.Add(c);
                }
            }
            return View(timeTables);
        }
        [HttpPost]
        public ActionResult TimeTableDetainedByRouts(string routId)
        {
            List<TimeTable> timeTables = new List<TimeTable>();

            foreach (var c in db.TimeTable.ToList())
            {
                if ((c.Detained == "так") && (c.RouteId.ToString() == routId))
                {
                    timeTables.Add(c);
                }
            }
            return View(timeTables);
        }

        public ActionResult RoutsByTimeAll()
        {
            return View(db.Routs.ToList());
        }
        [HttpPost]
        public ActionResult RoutsByTime(int routTime)
        {
            List<Routs> routs = new List<Routs>();

            foreach (var c in db.Routs.ToList())
            {
                if (c.RouteTime >= routTime)
                {
                    routs.Add(c);
                }
            }
            return View(routs);
        }

        public ActionResult ClientsByAgeAll()
        {
            return View(db.Clients.ToList());
        }
        [HttpPost]
        public ActionResult ClientsByAge(int age)
        {
            List<Clients> clients = new List<Clients>();

            foreach (var c in db.Clients.ToList())
            {
                if ((int)c.Age >= (int)age)
                {
                    clients.Add(c);
                }
            }
            return View(clients);
        }

        public ActionResult ClientsByPackageAll()
        {
            return View(db.Clients.ToList());
        }
        [HttpPost]
        public ActionResult ClientsByPackage(string package)
        {
            List<Clients> clients = new List<Clients>();

            foreach (var c in db.Clients.ToList())
            {
                if (c.GivenPackage == package)
                {
                    clients.Add(c);
                }
            }
            return View(clients);
        }

        public ActionResult TrainsByBrigadeAll()
        {
            return View(db.Trains.ToList());
        }
        [HttpPost]
        public ActionResult TrainsByBrigade(string brigadeId)
        {
            List<Trains> trains = new List<Trains>();

            foreach (var c in db.Trains.ToList())
            {
                if (c.BrigadeId.ToString() == brigadeId)
                {
                    trains.Add(c);
                }
            }
            return View(trains);
        }

        public ActionResult TicketsThatTakenBackAll()
        {
            List<Tickets> tickets = new List<Tickets>();
            foreach (var t in db.Tickets.ToList())
            {
                foreach(var b in db.TakenBackTickets.ToList())
                {
                    if (t.TicketId == b.TicketId)
                    {
                        tickets.Add(t);
                    }
                }
            }
            return View(tickets);
        }
        public ActionResult Title()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}