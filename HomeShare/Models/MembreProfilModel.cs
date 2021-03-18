using HomeShare.Infra;
using HomeShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HomeShare.Models
{
    public class MembreProfilModel
    {
        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
        private MembreModel _utilisateurCourant = SessionUtils.ConnectedUser;

        public MembreProfilModel() { }

        public MembreModel UtilisateurCourant { get => _utilisateurCourant; set => _utilisateurCourant = value; }
    }
}