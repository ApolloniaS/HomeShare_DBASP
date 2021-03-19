using HomeShare.DAL.Repositories;
using HomeShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Repositories
{
    public class AvisMembreBienRepository : BaseRepository<AvisMembreBienEntity>, IConcreteRepository<AvisMembreBienEntity>
    {
        public AvisMembreBienRepository(string connectionString) : base(connectionString)
        {
        }

        public List<AvisMembreBienEntity> ObtenirAvisDepuisIdBien(int idBien)
        {
            string requete = "SELECT * FROM Vue_AvisMembres WHERE idBien = "+idBien;
            return base.Get(requete);
        }

        public bool Delete(AvisMembreBienEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<AvisMembreBienEntity> Get()
        {
            throw new NotImplementedException();
        }

        public AvisMembreBienEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(AvisMembreBienEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(AvisMembreBienEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
