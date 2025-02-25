using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{[Authorize]
    public class ProfilesController : Controller
    {
        // GET: Prof
        
        
            RestauranlyContext Db = new RestauranlyContext();
            [HttpGet]
            public ActionResult Index()
            {
                var value = Db.Admins.Find(Session["id"]);
                return View(value);
            }
            [HttpPost]
            public ActionResult Index(Admin p)
            {
                var value = Db.Admins.Find(p.AdminId);
                value.UserName = p.UserName;
                value.Password = p.Password;
                value.Name = p.Name;
                value.Surname = p.Surname;
                value.ImageUrl = p.ImageUrl;
                value.Email = p.Email;
                Db.SaveChanges();
                return RedirectToAction("Index", "Profiles");
            }
        
    }
}