using HomeShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HomeShare.Models
{
    public class BiensViewModel
    {
        UnitOfWork uow = new UnitOfWork(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
        private List<BienAEchangerModel> _tousLesBiens;


        public BiensViewModel()
        {
            TousLesBiens = uow.obtenirTousLesBiens();
            

        }

        public List<BienAEchangerModel> TousLesBiens { get => _tousLesBiens; set => _tousLesBiens = value; }
    }
}