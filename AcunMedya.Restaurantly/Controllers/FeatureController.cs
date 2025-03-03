using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class FeatureController : Controller
    {
        RestauranlyContext Db = new RestauranlyContext();

        public ActionResult Index()
        {
            var value = Db.Features.ToList();
            return View(value);
        }
        public ActionResult FeatureList()
        {
            var value = Db.Features.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult FeatureCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FeatureCreate(Feature model)
        {
            Db.Features.Add(model);
            Db.SaveChanges();
            return RedirectToAction("FeatureList");
        }
        [HttpGet]
        public ActionResult FeatureEdit(int id)
        {
            var value = Db.Features.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult FeatureEdit(Feature model)
        {
            var value = Db.Features.Find(model.FeatureId);
            value.SubTitle = model.SubTitle;
            value.Title = model.Title;
            value.ImageUrl = model.ImageUrl;
            Db.SaveChanges();
            return RedirectToAction("FeatureList");
        }
        public ActionResult FeatureDelete(int id)
        {
            var value = Db.Features.Find(id);
            Db.Features.Remove(value);
            Db.SaveChanges();
            return RedirectToAction("FeatureList");
        }
    }
}