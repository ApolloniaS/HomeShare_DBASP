using HomeShare.DAL.Repositories;
using HomeShare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Repositories
{
    public class MembreRepository : BaseRepository<MembreEntity>, IConcreteRepository<MembreEntity>
    {
        public MembreRepository(string connectionString) : base(connectionString)
        {
        }

        public bool Delete(MembreEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<MembreEntity> Get()
        {
            throw new NotImplementedException();
        }

        public MembreEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(MembreEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(MembreEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
