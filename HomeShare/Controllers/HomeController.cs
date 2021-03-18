using HomeShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            return View(hvm);
        }

        public ActionResult Biens()
        {

            BiensViewModel bvm = new BiensViewModel();
            return View(bvm);
        }

        public ActionResult Fiche()
        {
            BiensViewModel bvm = new BiensViewModel();
            return View(bvm);
        }
    }
}