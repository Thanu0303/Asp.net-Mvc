using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWithWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //This action method is for loading the create product feature as a part of a ajax operation
        public ActionResult CreateProduct()
        {
            // we are returning a partial view and not a full view as we donot want
            // the header and footer parts to render . the header and footer
            // is already visible as a part of home/index request. We just 
            //want the Create view to be inserted into the index view
            return PartialView();
        }
    }
}