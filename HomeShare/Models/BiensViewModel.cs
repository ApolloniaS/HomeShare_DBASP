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
        private List<BienAEchangerModel> _biensAvecCriteres;
        private int _maxBook, _maxPage;


        public BiensViewModel()
        {
            TousLesBiens = uow.ObtenirTousLesBiens();
            

        }

        public void paginationBiens(string sortBy = "", string userInput = null, int page = 1)
        {

            BiensAvecCriteres = uow.ObtenirBienSelonCriteres(sortBy, userInput, page);
            if (userInput != null)
            {
                MaxBook = BiensAvecCriteres.Count();
                MaxPage = BiensAvecCriteres.Count() / 5;
            }

        }

        public List<BienAEchangerModel> TousLesBiens { get => _tousLesBiens; set => _tousLesBiens = value; }
        public List<BienAEchangerModel> BiensAvecCriteres { get => _biensAvecCriteres; set => _biensAvecCriteres = value; }
        public int MaxBook { get => _maxBook; set => _maxBook = value; }
        public int MaxPage { get => _maxPage; set => _maxPage = value; }
    }
}