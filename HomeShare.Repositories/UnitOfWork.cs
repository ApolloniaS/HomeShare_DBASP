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
        IConcreteRepository<MembreEntity> _membreRepo;


        public UnitOfWork(string connectionString)
        {
            _bienEchangeRepo = new BienEchangeRepository(connectionString);
            _membreRepo = new MembreRepository(connectionString);
        }

        #region HOMEPAGE

        // slider qui affiche les meilleurs biens
        public List<BienAEchangerModel> displayMeilleursBiens()
        {
            return ((BienEchangeRepository)_bienEchangeRepo).obtenirLesMieuxNotes().Select
                (biens =>
                new BienAEchangerModel()
                {
                    Photo = "/images/properties/" + biens.Photo,
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
                    Photo = "/images/properties/" + biens.Photo,
                    Titre = biens.Titre,
                }
                )
                .ToList();
        }

        // slider tout en haut; c'est un random sur les meilleurs biens
        public List<BienAEchangerModel> displayFrontslider()
        {
            return ((BienEchangeRepository)_bienEchangeRepo).obtenirCinqRandoms().Select
                (biens =>
                new BienAEchangerModel()
                {
                    Titre = biens.Titre,
                    CodePostal = biens.CodePostal,
                    Ville = biens.Ville,
                    Pays = biens.Pays,
                    DescCourte = biens.DescCourte,
                    Photo = "/images/properties/" + biens.Photo,
                }
                )
                .ToList();
        }

        #endregion

        #region PAGE RECHERCHE
        // reprend tous les biens, tout critères confondus
        public List<BienAEchangerModel> obtenirTousLesBiens()
        {

            return ((BienEchangeRepository)_bienEchangeRepo).Get().Select
                    (biens =>
                    new BienAEchangerModel()
                    {
                        Photo = "/images/properties/" + biens.Photo,
                        IsEnabled = biens.IsEnabled,
                        Titre = biens.Titre,
                        AssuranceObligatoire = biens.AssuranceObligatoire,
                        //options model ??
                    }
                    ).ToList();
        }
        #endregion

        #region INSCRIPTION ET CONNEXION
        //inscription
        public bool SignUp(MembreModel mm)
        {
            MembreEntity me = new MembreEntity()
            { 
                Nom = mm.Nom,
                Prenom = mm.Nom,
                Email = mm.Email,
                Telephone = mm.Telephone,
                Login = mm.Login,
                Password = mm.Password,
                Pays = mm.Pays

            };

            return _membreRepo.Insert(me);
        }

        //connexion
        public MembreModel SignIn(LoginModel lm)
        {
            MembreEntity me = ((MembreRepository)_membreRepo).GetFromLogin(lm.Login);
            if (me == null) return null;

            if (me != null)
            {
                return new MembreModel()
                {
                    IdMembre = me.IdMembre,
                    Login = me.Login,
                    Password = me.Password,
                };
            }
            else
            {
                return null;
            }
        }
        #endregion


    }

}

