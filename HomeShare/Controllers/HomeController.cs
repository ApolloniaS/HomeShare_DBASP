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
    public class HomeController : Controller
    {
        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            return View(hvm);
        }

        public ActionResult Biens(string sortBy = "", string userInput = null, int page = 1)
        {
            
            ViewBag.sortByNbPersonnes = sortBy == "Capacite" ? "NombrePerson_desc" : "";
            BiensViewModel bvm = new BiensViewModel();
            bvm.paginationBiens(sortBy, userInput, page);
            return View(bvm);
        }

        [HttpGet]
        public ActionResult Fiche(int idBien) 
         //todo: gérer si un user tape /Home/Fiche sans id!
        {
            FicheViewModel bvm = new FicheViewModel(idBien);

            return View(bvm);
        }
    }
}