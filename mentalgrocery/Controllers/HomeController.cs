using mentalgrocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mentalgrocery.Controllers
{
    public class HomeController : Controller
    {
        private webModels db = new webModels();
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

        public ActionResult Groups()
        {
            return View();
        }

        public ActionResult SingleGroup()
        {
            return View();
        }

        public ActionResult VoGroups()
        {
            return View();
        }
        public ActionResult MaGroups()
        {
            return View();
        }
        public ActionResult WaGroups()
        {
            return View();
        }
        public ActionResult CkGroups()
        {
            return View();
        }
    }
}