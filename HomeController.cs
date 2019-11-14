using MvcApplication.Infrastructure;
using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    { 
        public JsonResult Details()
        {
            var obj = new { Id = 1234, Name = "Canarys", Location = "Bengaluru" };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        CategoryRepository categoryRepository = new CategoryRepository();
        NorthwindContext productdb = new NorthwindContext();

     //   [HandleError(ExceptionType = typeof(Exception), View ="Error")]
        public ActionResult Index()
        {
            throw new Exception("something went wrong");

            //var model = new CategoryProductViewModel
            //{
            //    Categories = categoryRepository.GetAll().ToList(),
            //    Products = productdb.Products.ToList(),
            //    SelectedCatgeoryId = 0,
            //    SelectedCatgeoryName = string.Empty
            //};
            //return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var id = Convert.ToInt32("0" +collection["SelectedCategoryId"]);
            var products = productdb.Products.ToList();
            var categories = categoryRepository.GetAll();
            var selectedCategory = categories.FirstOrDefault(c => c.CategoryId == id);
            var matchingProducts = products.Where(c => c.CategoryId == selectedCategory.CategoryId);
            var model = new CategoryProductViewModel
            {
                Categories = categories.ToList(),
                Products = matchingProducts.ToList(),
                SelectedCatgeoryId = selectedCategory.CategoryId,
                SelectedCatgeoryName = selectedCategory.CategoryName,
            };
            return View(model);
    }

            public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Route("home/customers/country/{country}")]
        
        public ActionResult GetCustomersByCountry(string country)
        {
            ViewBag.Message = "Customers by country page baesd in " + country;
            
            
            return View("Contact");
        }

        [Route("home/about-us/{option}")]
        public ActionResult AboutUs(int option)
        {
            ViewData["one"] = "something else";
            ViewBag.one = "something";

            ViewData["ViewDataMessage"] = "This is from AboutUs ACtion->ViewDataMessage";
            ViewBag.ViewBagMessage = "This is from About-Us Action->ViewBagMessage";
            TempData["TempDataMessage"] = "This is from About-Us Action->TempDataMessage";
            Session["SessionMessage"] = "This is from About-Us Action->SessionMessage";
            if(option == 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AnotherAboutUs");
            }
        }
        [Route("home/another-about-us")]
        public ActionResult AnotherAboutUs()
        {
            return View();
        }

    }
}