﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPPCRental.Models;

namespace WebPPCRental.Controllers
{
    public class PropertyController : Controller
    {
        DemoPPCRentalEntities model = new DemoPPCRentalEntities();
        //
        // GET: /Property/
        public ActionResult Detail(int id)
        {
            PROPERTY product = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            return View(product);
        }
	}
}