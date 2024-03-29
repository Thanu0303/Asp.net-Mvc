﻿using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model: model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            return View(model);

                string user = "admin", pwd = "admin";
                if (model.UserName == user && model.Password == pwd)
                {
                //??--> Null Coalescing operator
                string returnUrl = Request.QueryString["ReturnUrl"] ?? "~/";
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                Session["user"] = model;
                return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Bad username/password.");
                    return View(model);
                }           
        }
    }
}