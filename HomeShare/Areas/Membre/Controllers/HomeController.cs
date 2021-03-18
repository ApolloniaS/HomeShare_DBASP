using HomeShare.Infra;
using HomeShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Areas.Membre.Controllers
{
    public class HomeController : Controller
    {
        // GET: Membre/Home
        public ActionResult Index()
        {
            if (!SessionUtils.IsLogged) return RedirectToAction("Login", "Account", new { area = "" });
            else
            {
                MembreProfilModel mpm = new MembreProfilModel();
                return View(mpm);
            }
        }

    }
}