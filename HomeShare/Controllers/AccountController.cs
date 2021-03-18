using HomeShare.Models;
using HomeShare.Repositories;
using Projet_ASP_books.Infra;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Controllers
{
    public class AccountController : Controller
    {
        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(MembreModel um)
        {
            if (ModelState.IsValid)
            {
                if (uow.SignUp(um))
                {
                    SessionUtils.IsLogged = true;
                    SessionUtils.ConnectedUser = um;
                    return RedirectToAction("Index", "Home", new { area = "Membre" });
                }
                else
                {
                    ViewBag.Error = "Erreur Login/Password";
                    return View("Login");
                }
            }
            else
            {
                ViewBag.Error = "Erreur Login/Password";
                return View("Login");
            }
        }
    }
}