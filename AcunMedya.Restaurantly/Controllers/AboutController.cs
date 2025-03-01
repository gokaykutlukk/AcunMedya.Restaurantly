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
    public class AboutController : Controller
    {
        RestauranlyContext Db = new RestauranlyContext();

        public ActionResult Index()
        {
            var value = Db.Abouts.ToList();
            return View(value);
        }
        public ActionResult AboutList()
        {
            var value = Db.Abouts.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AboutCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AboutCreate(About model)
        {
            Db.Abouts.Add(model);
            Db.SaveChanges();
            return RedirectToAction("AboutList");
        }
        [HttpGet]
        public ActionResult AboutEdit(int id)
        {
            var value = Db.Abouts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult AboutEdit(About model)
        {
            var value = Db.Abouts.Find(model.AboutId);
            value.Title = model.Title;
            value.Description = model.Description;
            value.imageUrl= model.imageUrl;
            Db.SaveChanges();
            return RedirectToAction("AboutList");
        }
        public ActionResult AboutDelete(int id)
        {
            var value = Db.Abouts.Find(id);
            Db.Abouts.Remove(value);
            Db.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}