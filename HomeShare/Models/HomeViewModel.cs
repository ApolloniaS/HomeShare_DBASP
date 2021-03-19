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
        private List<BienAEchangerModel> _frontSlider;


        public HomeViewModel()
        {
            // affichage dans le gros slider
            FrontSlider = uow.DisplayFrontslider();
            // affiche les derniers biens dans le slider en bas à droite de HOMEPAGE
            DerniersEchanges = uow.DisplayCinqDerniersBien();
            // afficher les meilleurs bien dans le slider du milieu
            MeilleursEchanges = uow.DisplayMeilleursBiens();

        }

        public List<BienAEchangerModel> DerniersEchanges { get => _derniersEchanges; set => _derniersEchanges = value; }
        public List<BienAEchangerModel> MeilleursEchanges { get => _meilleursEchanges; set => _meilleursEchanges = value; }
        public List<BienAEchangerModel> FrontSlider { get => _frontSlider; set => _frontSlider = value; }
    }
}