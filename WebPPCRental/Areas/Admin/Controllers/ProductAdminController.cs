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
        Team12Entities1 model = new Team12Entities1();
        //
        // GET: /ProductAdmin/
        public ActionResult Index()
        {
            var property = model.PROPERTies.OrderByDescending(x => x.ID).ToList();
            return View(property);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var property = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            ViewBag.PROPERTY_TYPE = model.PROPERTY_TYPE.OrderByDescending(x => x.ID).ToList();
            ViewBag.DISTRICT = model.DISTRICTs.OrderByDescending(x => x.ID).ToList();
            ViewBag.userr = model.USERs.OrderByDescending(x => x.ID).ToList();
            ViewBag.WARD = model.WARDs.OrderByDescending(x => x.ID).ToList();
            ViewBag.STREET = model.STREETs.OrderByDescending(x => x.ID).ToList();
            return View(property);
        }
        [HttpPost]
        public ActionResult Edit(int id, PROPERTY p)
        {
           
            var property = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            property.PropertyName = p.PropertyName;
            property.Price = p.Price;
            property.Content = p.Content;
            property.Avatar = p.Avatar;
            property.PROPERTY_TYPE = p.PROPERTY_TYPE;
            property.PROJECT_STATUS = p.PROJECT_STATUS;
            model.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PROPERTY p)
        {
            var property = new PROPERTY();
            property.PropertyName = p.PropertyName;
            property.Price = p.Price;
            property.Content = p.Content;
            property.Avatar = p.Avatar;
            property.PROPERTY_TYPE = p.PROPERTY_TYPE;
            property.PROJECT_STATUS = p.PROJECT_STATUS;
            model.PROPERTies.Add(property);
            model.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var property = model.PROPERTies.Find(id);
            return View(property);
        }
        [HttpPost]
        public ActionResult DeleteFirm(int id)
        {
            var property = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            model.PROPERTies.Remove(property);
            model.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details (int id)
        {
            var property = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            return View(property);
        }
	}
}