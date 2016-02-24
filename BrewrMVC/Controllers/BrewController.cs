﻿using BrewrMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrewrMVC.Controllers
{
    public class BrewController : Controller
    {
        private readonly BrewRepository _db = new BrewRepository();
        public ActionResult Index()
        {
            List<Brew> model = _db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create([Bind()]Brew brew)
        {
            if (ModelState.IsValid)
            {
                _db.AddNewBrew(brew);
                return RedirectToAction("Index");
            }

            return View("Create");
        }
    }
}