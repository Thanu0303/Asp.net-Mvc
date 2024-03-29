﻿using MvcApplication.Infrastructure;
using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
   // [Authorize]   // can be used on action methods
    
    public class CustomerController : Controller
    {
        IRepository<Customer, string> repository;

        public CustomerController()
        {
            repository = new CustomerRepository();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var model = repository.GetAll();          // getall the customers and store it to model
            return View(model : model);               //pass the model to the view
        }
        public ActionResult Details(string id)
        {
            var model = repository.GetDetails(identity: id);
            if (model != null)
                return View(model);
            else
                return RedirectToAction("Index");
        }
[Authorize]
    public ActionResult Edit(string id)                  // calling through get method
    {
        var model = repository.GetDetails(identity: id);       
        if (model != null)
            return View(model:model);
        else
            return RedirectToAction("Index");
    }
        [HttpPost]
        public ActionResult Edit(Customer model)                   //calling through post method
        {
            //string id = Request.Form["CustomerId"];
            //string company = Request.Form["CompanyName"];
            //string contact = Request.Form["ContactName"];
            //string city = Request.Form["City"];
            //string country = Request.Form["Country"];


            //validate the data for FormCollection
            //string id = theForm["CustomerId"];
            //string company = theForm["CompanyName"];
            //string contact = theForm["ContactName"];
            //string city = theForm["City"];
            //string country = theForm["Country"];


            //Customer obj = new Customer
            //{
            //    CustomerId = id,
            //    CompanyName = company,
            //    ContactName = contact,
            //    City = city,
            //    Country = country
            //};
              repository.Update(model);               //       will throw notImplmentedException
            return RedirectToAction("Index");
        }

        public ActionResult Create()                  // calling through get method
        {
            var model = new Customer();
            return View(model: model);
            
        }
        [HttpPost]
        public ActionResult Create(Customer model)
        {
            repository.CreateNew(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)                  // calling through get method
        {
            var model = repository.GetDetails(identity: id);
            return View(model: model);

        }
        [HttpPost]
        public ActionResult DeleteConfirm(string id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
