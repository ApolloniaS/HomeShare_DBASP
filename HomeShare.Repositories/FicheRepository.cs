using HomeShare.DAL.Repositories;
using HomeShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Repositories
{
    public class FicheRepository : BaseRepository<FicheEntity>, IConcreteRepository<FicheEntity>
    {
        public FicheRepository(string connectionString) : base(connectionString)
        {
        }

        public bool Delete(FicheEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<FicheEntity> Get()
        {
            throw new NotImplementedException();
        }

        public FicheEntity GetOne(int PK)
        {
            string requete = "SELECT * FROM BienEchange WHERE idBien = " + PK;
            return base.GetOne(PK, requete);
        }

        public bool Insert(FicheEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(FicheEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
