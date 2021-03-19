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
        public List<BienAEchangerModel> DisplayMeilleursBiens()
        {
            return ((BienEchangeRepository)_bienEchangeRepo).ObtenirLesMieuxNotes().Select
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
        public List<BienAEchangerModel> DisplayCinqDerniersBien()
        {
            return ((BienEchangeRepository)_bienEchangeRepo).ObtenirCinqDerniers().Select
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
        public List<BienAEchangerModel> DisplayFrontslider()
        {
            return ((BienEchangeRepository)_bienEchangeRepo).ObtenirCinqRandoms().Select
                (biens =>
                new BienAEchangerModel()
                {
                    Titre = biens.Titre,
                    CodePostal = biens.CodePostal,
                    Ville = biens.Ville,
                    DescCourte = biens.DescCourte,
                    Photo = "/images/properties/" + biens.Photo,
                    NomPays = ((PaysRepository)_paysRepo).ObtenirNomPaysDepuisId(biens.Pays).Libelle
                }
                )
                .ToList();
        }

        #endregion

        #region RECHERCHE
        // reprend tous les biens, tout critères confondus, pour la page de recherche depuis le "voir tous les biens" de la homepage
        public List<BienAEchangerModel> ObtenirTousLesBiens()
        {

            return _bienEchangeRepo.Get().Select
                    (biens =>
                    new BienAEchangerModel()
                    {
                        IdBien = biens.IdBien,
                        Photo = "/images/properties/" + biens.Photo,
                        Titre = biens.Titre,
                        NombrePersonne = biens.NombrePerson,
                        DescCourte = biens.DescCourte,
                        Drapeau = "/images/drapeaux/" + ((PaysRepository)_paysRepo).GetOne(biens.Pays).Drapeau,
                        NomPays = ((PaysRepository)_paysRepo).ObtenirNomPaysDepuisId(biens.Pays).Libelle,
                    }
                    ).ToList();
        }

        // recherche depuis la homepage selon critères
        // pour le moment, elle reprend une recherche avec mot clé dans la description
        // + possibilité de trier sur le nombre de personnes
        // todo: trouver d'où vient le bug... 
        public List<BienAEchangerModel> ObtenirBienSelonCriteres(string sortBy, string userInput, int page)
        {
            return ((BienEchangeRepository)_bienEchangeRepo).SeparatePages(sortBy, userInput, page).Select
                (biens =>
                    new BienAEchangerModel()
                    {
                        IdBien = biens.IdBien,
                        Photo = "/images/properties/" + biens.Photo,
                        Titre = biens.Titre,
                        NombrePersonne = biens.NombrePerson,
                        DescCourte = biens.DescCourte,
                        Drapeau = "/images/drapeaux/" + ((PaysRepository)_paysRepo).GetOne(biens.Pays).Drapeau,
                        NomPays = ((PaysRepository)_paysRepo).ObtenirNomPaysDepuisId(biens.Pays).Libelle,
                    }
                    ).ToList();
        }
        #endregion

        #region FICHE
        public FicheModel GenererFiche(int id)
        {
            return new FicheModel()
            {
                //les infos de description
                IdBien = id,
                Titre = _ficheRepo.GetOne(id).Titre,
                NombrePersonnes = _ficheRepo.GetOne(id).NombrePerson,
                DescLongue = _ficheRepo.GetOne(id).DescLong,
                Photo = "/images/properties/" + _ficheRepo.GetOne(id).Photo,
                Drapeau = "/images/drapeaux/" + ((PaysRepository)_paysRepo).ObtenirDrapeauDepuisIdBien(id).Drapeau,
                //todo: récupérer les options
                // les infos des avis
                AvisMembre = (List<AvisMembreModel>)((AvisMembreBienRepository)_avisMembreRepo).ObtenirAvisDepuisIdBien(id).Select
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

        #region ZONE MEMBRE

        public List<BienAEchangerModel> AfficherListeBiens(int idMembre)
        {
            return ((BienEchangeRepository)_bienEchangeRepo).ObtenirLesBiensDepuisMembre(idMembre).Select(
                bien =>
                new BienAEchangerModel
                {
                    IdBien = bien.IdBien,
                    Titre = bien.Titre,
                    DescCourte = bien.DescCourte,
                    DateCreation = bien.DateCreation,
                }).ToList();
        }

        public bool AjouterBien(BienAEchangerModel bm, int idmembre)
        {
            BienEchangeEntity be = new BienEchangeEntity()
            {
                NombrePerson = bm.NombrePersonne,
                Pays = bm.Pays,
                IdMembre = idmembre,
                Titre = bm.Titre,
                DescCourte = bm.DescCourte,
                DescLong = bm.DescLongue,
                Ville = bm.Ville,
                Numero = bm.Numero,
                Rue = bm.Rue,
                CodePostal = bm.CodePostal,
                //faire l'upload !!
                Photo = "à venir upload",
                Latitude = bm.Latitude,
                Longitude = bm.Longitude,
                AssuranceObligatoire = bm.AssuranceObligatoire,
                DateCreation = DateTime.Now,
                IsEnabled = true
    };
            return _bienEchangeRepo.Insert(be);
        }

        public bool SupprimerUnBien(int idBien, int idMembre)
        {
            BienEchangeEntity be = new BienEchangeEntity()
            {//todo: erreur sql multi part identifier... 
                IdBien = idBien,
                NombrePerson = _bienEchangeRepo.GetOne(idBien).NombrePerson,
                Pays = _bienEchangeRepo.GetOne(idBien).Pays,
                IdMembre = idMembre,
                Titre = _bienEchangeRepo.GetOne(idBien).Titre,
                DescCourte = _bienEchangeRepo.GetOne(idBien).DescCourte,
                DescLong = _bienEchangeRepo.GetOne(idBien).DescLong,
                Ville = _bienEchangeRepo.GetOne(idBien).Ville,
                Numero = _bienEchangeRepo.GetOne(idBien).Numero,
                Rue = _bienEchangeRepo.GetOne(idBien).Rue,
                CodePostal = _bienEchangeRepo.GetOne(idBien).CodePostal,
                Photo = _bienEchangeRepo.GetOne(idBien).Photo,
                Latitude = _bienEchangeRepo.GetOne(idBien).Latitude,
                Longitude = _bienEchangeRepo.GetOne(idBien).Longitude,
                AssuranceObligatoire = _bienEchangeRepo.GetOne(idBien).AssuranceObligatoire,
                DateCreation = _bienEchangeRepo.GetOne(idBien).DateCreation,
                IsEnabled = false,
                DisabledDate = DateTime.Now,
            };
            return _bienEchangeRepo.Update(be);
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

