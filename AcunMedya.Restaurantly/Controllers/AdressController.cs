using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class AdressController : Controller
    {
        RestauranlyContext Db = new RestauranlyContext();

        // GET: Adress
        public ActionResult AdressList()
        {
            var values = Db.Adresss.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateAdress(int id)
        {
            var values = Db.Adresss.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAdress(Adress updateAdress)
        {
            var values = Db.Adresss.Find(updateAdress.AdressId);
            values.Location = updateAdress.Location;
            values.OpenHours = updateAdress.OpenHours;
           
            
            Db.SaveChanges();
            return RedirectToAction("AdressList");
        }
    }
}