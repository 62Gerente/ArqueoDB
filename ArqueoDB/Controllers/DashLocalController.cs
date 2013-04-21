﻿using ArqueoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArqueoDB.Controllers
{
    public class DashLocalController : Controller
    {
        private EntidadesArqueoDB db = new EntidadesArqueoDB();

        public ActionResult Dashboard(int id = 1)
        {
            Local local = db.Locais.Find(id);
            if (local == null)
            {
                return HttpNotFound();
            }

            ViewData["Locais"] = "Organizacao";
            ViewData["Activo"] = "Dashboard";

            return View(local);
        }

    }
}