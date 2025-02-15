﻿using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AcunMedya.Restaurantly.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
       
        RestauranlyContext Db = new RestauranlyContext();

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values=Db.Admins.FirstOrDefault(x=>x.UserName==p.UserName && x.Password==p.Password);
            if (values != null) 
            {
             FormsAuthentication.SetAuthCookie(values.UserName,true);
                Session["a"]=values.UserName;
                return RedirectToAction("ProductList", "Product");
            }
            return View();
        }
    }
}