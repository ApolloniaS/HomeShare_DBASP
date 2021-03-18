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
        private List<BienAEchangerModel> _fiche;

        public FicheViewModel()
        {
            Fiche = uow.obtenirTousLesBiens();
        }

        public List<BienAEchangerModel> Fiche { get => _fiche; set => _fiche = value; }
    }
}