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
        IConcreteRepository<PaysEntity> _paysRepo;
        IConcreteRepository<FicheEntity> _ficheRepo;
        IConcreteRepository<AvisMembreBienEntity> _avisMembreRepo;



        public UnitOfWork(string connectionString)
        {
            _bienEchangeRepo = new BienEchangeRepository(connectionString);
            _membreRepo = new MembreRepository(connectionString);
            _paysRepo = new PaysRepository(connectionString);
            _ficheRepo = new FicheRepository(connectionString);
            _avisMembreRepo = new AvisMembreBienRepository(connectionString);
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
                    DescCourte = biens.DescCourte,
                    Photo = "/images/properties/" + biens.Photo,
                    NomPays = ((PaysRepository)_paysRepo).obtenirNomPaysDepuisId(biens.Pays).Libelle
                }
                )
                .ToList();
        }

        #endregion

        #region PAGE RECHERCHE
        // reprend tous les biens, tout critères confondus, pour la page de recherche
        public List<BienAEchangerModel> obtenirTousLesBiens()
        {

            return ((BienEchangeRepository)_bienEchangeRepo).Get().Select
                    (biens =>
                    new BienAEchangerModel()
                    {
                        IdBien = biens.IdBien,
                        Photo = "/images/properties/" + biens.Photo,
                        Titre = biens.Titre,
                        NombrePersonne = biens.NombrePerson,
                        DescCourte = biens.DescCourte,
                        Drapeau = "/images/drapeaux/" + ((PaysRepository)_paysRepo).GetOne(biens.Pays).Drapeau,
                        NomPays = ((PaysRepository)_paysRepo).obtenirNomPaysDepuisId(biens.Pays).Libelle,
                    }
                    ).ToList();
        }
        #endregion

        #region FICHE
        public FicheModel genererFiche(int id)
        {
            return new FicheModel()
            {
                //les infos de description
                IdBien = id,
                Titre = _ficheRepo.GetOne(id).Titre,
                NombrePersonnes = _ficheRepo.GetOne(id).NombrePerson,
                DescLongue = _ficheRepo.GetOne(id).DescLong,
                Photo = "/images/properties/" + _ficheRepo.GetOne(id).Photo,
                Drapeau = "/images/drapeaux/" + ((PaysRepository)_paysRepo).obtenirDrapeauDepuisIdBien(id).Drapeau,
                //todo: récupérer les options
                // les infos des avis
                AvisMembre = (List<AvisMembreModel>)((AvisMembreBienRepository)_avisMembreRepo).obtenirAvisDepuisIdBien(id).Select
                    (avis => new AvisMembreModel {
                        Message = avis.Message,
                        Note = avis.Note,
                        Login = _membreRepo.GetOne(avis.IdMembre).Login
                    }
                    ).ToList(),
                NomDuProprio = ((MembreRepository)_membreRepo).ObtenirProprioDepuisIdBien(id).Nom + " " + ((MembreRepository)_membreRepo).ObtenirProprioDepuisIdBien(id).Prenom,
            };

        }

        // ajout d'un avis -- prob de récupération de l'idBien
        //public bool ajouterAvis(AvisMembreModel am, int idMembre, int idBien)
        //{
        //    AvisMembreBienEntity ae = new AvisMembreBienEntity()
        //    {
        //        IdMembre = idMembre,
        //        IdBien = idBien,
        //        Message = am.Message,
        //        Note = am.Note,
        //        DateAvis = DateTime.Now,
        //        Approuve = false
        //    };
        //    return _avisMembreRepo.Insert(ae);
        //}
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
                    Nom = me.Nom,
                    Prenom = me.Prenom,
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

