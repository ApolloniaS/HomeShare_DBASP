using HomeShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HomeShare.Models
{
    public class HomeViewModel
    {
        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
        private List<BienAEchangerModel> _derniersEchanges;
        private List<BienAEchangerModel> _meilleursEchanges;

        public HomeViewModel()
        {
            // affiche les derniers biens dans le slider en bas à droite de HOMEPAGE
            DerniersEchanges = uow.displayCinqDerniersBien();
            // afficher les meilleurs bien dans le slider du milieu
            MeilleursEchanges = uow.displayMeilleursBiens();

        }

        public List<BienAEchangerModel> DerniersEchanges { get => _derniersEchanges; set => _derniersEchanges = value; }
        public List<BienAEchangerModel> MeilleursEchanges { get => _meilleursEchanges; set => _meilleursEchanges = value; }

    }
}