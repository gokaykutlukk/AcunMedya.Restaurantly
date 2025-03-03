using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
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
            ViewBag.Title=Db.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.Description = Db.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.imageUrl = Db.Abouts.Select(x => x.imageUrl).FirstOrDefault();
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
        public PartialViewResult PartialSpecials()
        {
            var value = Db.Specials.ToList();
            return PartialView(value);
        }
        
        public PartialViewResult PartialBookaTable()
        {
          
            return PartialView();
        }
        [HttpPost]
        public ActionResult BookTableAdd(Reservation model)
        {
            model.ReservationDate = DateTime.Now;
            model.ReservationStatus = "İncelemeye Alındı";
            Db.SaveChanges();
            ViewBag.Message = "Yeriniz Başarıyla Ayrıldı";
            return View("Index");
        }
        public ActionResult PartialTestimonial()
        {
            var value = Db.Testimonials.ToList();
            return PartialView(value); ;
        }
        public ActionResult PartialChefs()
        {
            var value = Db.Chefs.ToList();
            return PartialView(value); ;
        }
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ContactAdd(Contact model)
        {
            model.SendDate= DateTime.Now;
            model.IsRead = false;
            Db.Contacts.Add(model);
            Db.SaveChanges();
            ViewBag.Message = "Mesaj Başarılı";
            return View("Index");
        }
        public ActionResult PartialAdress()
        {
            ViewBag.Location = Db.Adresss.Select(x => x.Location).FirstOrDefault();
            ViewBag.OpenHours = Db.Adresss.Select(x => x.OpenHours).FirstOrDefault();
            ViewBag.Email = Db.Contacts.Select(x => x.Email).FirstOrDefault();
            return PartialView();
           
        }
        public PartialViewResult PartialGallery()
        {
            var value = Db.Galleries.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialEvent()
        {
            var value = Db.Events.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialFooter()
        {
            var value = Db.Adresss.ToList();
            return PartialView(value);
        }
    }
}