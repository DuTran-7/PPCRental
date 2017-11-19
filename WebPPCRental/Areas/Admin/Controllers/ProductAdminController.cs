using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPPCRental.Models;

namespace WebPPCRental.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        //
        // GET: /Admin/ProductAdmin/
        DemoPPCRentalEntities1 model = new DemoPPCRentalEntities1();
        //
        // GET: /ProductAdmin/
        public ActionResult Index()
        {
            var product = model.PROPERTies.OrderByDescending(x => x.ID).ToList();
            return View(product);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = model.PROPERTies.SingleOrDefault(x => x.ID == id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(int id, PROPERTY p)
        {
            var product = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            product.PropertyName = p.PropertyName;
            product.Price = p.Price;
            model.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}