﻿using AcunMedya.Restaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class DefaultController : Controller
    {
        RestauranlyContext Db = new RestauranlyContext();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead() 
        {
            return PartialView(); 
        }
        public PartialViewResult PartialTop()
        {
           
            ViewBag.OpenHours= Db.Adresss.Select(x => x.OpenHours).FirstOrDefault();

            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeaturne()
        {
            ViewBag.Subtitle=Db.Features.Select(x => x.SubTitle).FirstOrDefault();
            ViewBag.Title=Db.Features.Select(x => x.Title).FirstOrDefault();
            ViewBag.VideoUrl=Db.Features.Select(x => x.VideoUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            return PartialView();
        }
        public PartialViewResult PartialService()
        {
            var value=Db.Services.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialMenu()
        {
            var value = Db.Products.ToList();
            return PartialView(value);
        }
    }
}