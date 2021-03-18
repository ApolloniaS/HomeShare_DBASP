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

        public FicheViewModel(int id)
        {
            Fiche = uow.genererFiche(id);
        }

        public FicheModel Fiche { get => _fiche; set => _fiche = value; }
    }
}