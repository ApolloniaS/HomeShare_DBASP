using HomeShare.Infra;
using HomeShare.Models;
using HomeShare.Repositories;
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
        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel lm)
        {
            if (ModelState.IsValid)
            {
                MembreModel mm = uow.SignIn(lm);
                if (mm == null)
                {
                    ViewBag.Error = "Erreur Login/Password";
                    return View();
                }
                else
                {
                    SessionUtils.IsLogged = true;
                    SessionUtils.ConnectedUser = mm;
                    return RedirectToAction("Index", "Home", new { area = "Membre" });
                }
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(MembreModel mm)
        {
            if (ModelState.IsValid)
            {
                if (uow.SignUp(mm))
                {
                    SessionUtils.IsLogged = true;
                    SessionUtils.ConnectedUser = mm;
                    return RedirectToAction("Index", "Home", new { area = "Membre" });
                }
                else
                {
                    ViewBag.Error = "Erreur Login/Password";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Erreur Login/Password";
                return View();
            }
        }
    }
}