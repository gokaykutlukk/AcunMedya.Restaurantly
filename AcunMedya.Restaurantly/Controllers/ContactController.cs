using AcunMedya.Restaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        RestauranlyContext Db = new RestauranlyContext();

        public ActionResult Index()
        {
            var value = Db.Contacts.ToList();
            return View(value);
        }
        public ActionResult ContactList()
        {
            var value = Db.Contacts.ToList();
            return View(value);
        }
        public ActionResult Okundu(int id)
        {
            var value = Db.Contacts.Find(id);
            value.IsRead = true;
            Db.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
}