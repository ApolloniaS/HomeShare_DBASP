using HomeShare.DAL.Repositories;
using HomeShare.Entities;
using HomeShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Repositories
{
    public class UnitOfWork
    {
        IConcreteRepository<BienEchangeEntity> _bienEchangeRepo;

        public UnitOfWork(string connectionString)
        {
            _bienEchangeRepo = new BienEchangeRepository(connectionString);
        }

        #region HOMEPAGE

        // slider qui affiche les meilleurs biens
        public List<BienAEchangerModel> displayMeilleursBiens() {
            return ((BienEchangeRepository)_bienEchangeRepo).obtenirLesMieuxNotes().Select
                (biens =>
                new BienAEchangerModel()
                {
                    Photo = biens.Photo,
                    IsEnabled = biens.IsEnabled,
                    Titre = biens.Titre,
                    AssuranceObligatoire = biens.AssuranceObligatoire,
                    //options model ??
                }
                ).ToList();
        }

        // slider qui affiche les 5 derniers biens ajoutés
        public List<BienAEchangerModel> displayCinqDerniersBien()
        {
            return ((BienEchangeRepository)_bienEchangeRepo).obtenirCinqDerniers().Select
                (biens =>
                new BienAEchangerModel()
                {
                    Photo = biens.Photo,
                    Titre = biens.Titre,
                }
                )
                .ToList();
        }

        #endregion
    }

}