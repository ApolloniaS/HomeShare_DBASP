using HomeShare.Infra;
using HomeShare.Models;
using HomeShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Areas.Membre.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
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

        public ActionResult MesBiens()
        {
            if (!SessionUtils.IsLogged) return RedirectToAction("Login", "Account", new { area = "" });
            else
            {
                MembreProfilModel mpm = new MembreProfilModel();
                return View(mpm);
            }
        }

        [HttpGet]
        public ActionResult AjoutBien() {
            if (!SessionUtils.IsLogged) return RedirectToAction("Login", "Account", new { area = "" });
            else
            {
                MembreProfilModel mpm = new MembreProfilModel();
                return View(mpm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjoutBien(BienAEchangerModel bm)
        {
            if (SessionUtils.IsLogged)
            {//todo: check pq le modèle n'est pas valide
                if (ModelState.IsValid)
                {
                    uow.AjouterBien(bm, SessionUtils.ConnectedUser.IdMembre);
                    return RedirectToAction("MesBiens", "Home", new { area = "Membre" });
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult SupprimerBien(int idBien)
        {
            uow.SupprimerUnBien(idBien, SessionUtils.ConnectedUser.IdMembre);
            return RedirectToAction("Index", "Home", new { area = "Membre" });
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult laisserAvis(int idBien, AvisMembreModel am)
        //{
        //    if (!SessionUtils.IsLogged)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            uow.ajouterAvis(am, SessionUtils.ConnectedUser.IdMembre, idBien);
        //            return View("Avis ajouté !");
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    return View();

        //}

    }
}