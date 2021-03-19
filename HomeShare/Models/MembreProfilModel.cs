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
        private List<BienAEchangerModel> _listeBiens;

        public MembreProfilModel() {
            ListeBiens = uow.AfficherListeBiens(UtilisateurCourant.IdMembre);
        }

        public MembreModel UtilisateurCourant { get => _utilisateurCourant; set => _utilisateurCourant = value; }
        public List<BienAEchangerModel> ListeBiens { get => _listeBiens; set => _listeBiens = value; }
    }
}