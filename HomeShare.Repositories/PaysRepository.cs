﻿using HomeShare.DAL.Repositories;
using HomeShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Repositories
{
    public class PaysRepository : BaseRepository<PaysEntity>, IConcreteRepository<PaysEntity>
    {
        public PaysRepository(string connectionString) : base(connectionString)
        {
        }

        public PaysEntity obtenirNomPaysDepuisId(int idPays)
        {
            string requete = "SELECT libelle FROM Pays WHERE idPays = " + idPays;
            return base.GetOne(idPays, requete);
        }

        public bool Delete(PaysEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<PaysEntity> Get()
        {
            throw new NotImplementedException();
        }

        public PaysEntity GetOne(int PK)
        {
            string requete = "SELECT drapeau FROM Pays WHERE idPays = " + PK;
            return base.GetOne(PK, requete);
        }

        public bool Insert(PaysEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(PaysEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
