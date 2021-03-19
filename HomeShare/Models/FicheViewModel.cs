using HomeShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HomeShare.Models
{
    public class FicheViewModel
    {
        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
        private FicheModel _fiche;
        private AvisMembreModel _avisMembre;


        public FicheViewModel(int id)
        {
            Fiche = uow.GenererFiche(id);
            
        }

        public FicheModel Fiche { get => _fiche; set => _fiche = value; }
        public AvisMembreModel AvisMembre { get => _avisMembre; set => _avisMembre = value; }
    }
}