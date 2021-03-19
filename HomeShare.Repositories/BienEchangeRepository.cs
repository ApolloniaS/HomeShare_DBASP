using HomeShare.DAL.Repositories;
using HomeShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Repositories
{
    public class BienEchangeRepository : BaseRepository<BienEchangeEntity>, IConcreteRepository<BienEchangeEntity>
    {
        public BienEchangeRepository(string connectionString) : base(connectionString)
        {
        }

        public List<BienEchangeEntity> SeparatePages(string sortBy, string userInput, int page) 
        {
            // todo: sp ?
            string requete = @"SELECT * FROM BienEchange LEFT JOIN 
                      AvisMembreBien ON AvisMembreBien.idBien = BienEchange.idBien left JOIN 
                      Membre ON AvisMembreBien.idMembre = Membre.idMembre AND BienEchange.idMembre = Membre.idMembre left JOIN 
                      MembreBienEchange ON BienEchange.idBien = MembreBienEchange.idBien AND Membre.idMembre = MembreBienEchange.idMembre left JOIN
                      OptionsBien ON BienEchange.idBien = OptionsBien.idBien left JOIN
                      Options ON OptionsBien.idOption = Options.idOption left JOIN
                      Pays ON BienEchange.Pays = Pays.idPays";
            if (!String.IsNullOrEmpty(userInput))
            {
                requete += " WHERE descCourte LIKE '%" + userInput + "%' ";
            }
            switch (sortBy)
            {
                case "capacite":
                    requete += " ORDER BY NombrePerson DESC ";
                    break;
                default:
                    requete += " ORDER BY NEWID()";
                    break;
            }
            int biensAffiches = 5;
            int pageSuivante = (page - 1) * 5;
            requete += $@"  OFFSET {pageSuivante} ROWS 
                                FETCH NEXT {biensAffiches} ROWS ONLY";
            return base.Get(requete);
        }
        public List<BienEchangeEntity> ObtenirLesBiensDepuisMembre(int idMembre)
        {
            //IL Y A UNE SP POUR CA !!
            string requete = "SELECT * FROM BienEchange WHERE idMembre = " + idMembre;
            return base.Get(requete);
        }

        public List<BienEchangeEntity> ObtenirCinqDerniers()
        {
            string requete = "SELECT * FROM Vue_CinqDernierBiens";
            return base.Get(requete);
        }

        public List<BienEchangeEntity> ObtenirLesMieuxNotes()
        { 
            string requete = "SELECT * FROM Vue_MeilleursAvis";
            return base.Get(requete);
        }

        public List<BienEchangeEntity> ObtenirCinqRandoms()
        {
            string requete = "SELECT TOP(5) * FROM Vue_MeilleursAvis ORDER BY NEWID()";
            return base.Get(requete);
        }

        public bool Delete(BienEchangeEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<BienEchangeEntity> Get()
        {
            string requete = "SELECT * FROM BienEchange";
            return base.Get(requete);
        }

        public BienEchangeEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(BienEchangeEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(BienEchangeEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
