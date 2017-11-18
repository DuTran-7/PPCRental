using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPPCRental.Models;

namespace WebPPC.Controllers
{
    public class HomeController : Controller
    {
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();
        public ActionResult Index()
        {
            List<PROPERTY> mi = new List<PROPERTY>();
            mi = db.PROPERTies.ToList();
            return View(mi);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Detail(int id)
        {
            PROPERTY team2 = db.PROPERTies.Find(id);
            return View(team2);
        }
        [HttpGet]
        public ActionResult Filter(string filter)
        {
            var team2 = db.PROPERTies.Where(x => x.DISTRICT.DistrictName.Contains(filter)).ToList();
            if (string.IsNullOrEmpty(filter))
                team2 = db.PROPERTies.ToList();
            return View(team2);
        }
    }
}