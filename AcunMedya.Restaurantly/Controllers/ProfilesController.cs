using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
            if(Session["id"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
                var value = Db.Admins.Find(Session["id"]);
                return View(value);
            }
            [HttpPost]
            public ActionResult Index(Admin p)
            {
                var value = Db.Admins.Find(p.AdminId);
            if (value.Password != p.Password)
            {
                ModelState.AddModelError(string.Empty, "Şifre Hatalı");
                return View(value);
            }
            if(p.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

                var saveLocation = currentDirectory + "Images\\";

                var fileName=Path.Combine(saveLocation, p.ImageFile.FileName);

                p.ImageFile.SaveAs(fileName);

                value.ImageUrl = "Images/" + p.ImageFile.FileName;
            }
                value.UserName = p.UserName;
                value.Password = p.Password;
                value.Name = p.Name;
                value.Surname = p.Surname;
                value.Email = p.Email;
                Db.SaveChanges();
                return RedirectToAction("Index", "Dahboard");
            }
        [HttpGet]
             public ActionResult ChangePassword()
            {
            if (Session["id"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var value = Db.Admins.Find(Session["id"]);
            return View(value);
            }
        [HttpPost]
            public ActionResult ChangePassword(Admin p)
            {
                if (Session["id"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }
            var value = Db.Admins.Find(Session["id"]);

            if (p.CurrentPassword != value.Password)
            {
                ModelState.AddModelError("", "MEvcut Şifre Hatalı");
                return View(p);
            }
            if (p.NewPassword != p.ConfirmPassword)
            {
                ModelState.AddModelError("", "Yeni Şifreler Eşleşmiyor");
                return View(p);
            }
            value.Password = p.NewPassword;
            Db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }

    }
}