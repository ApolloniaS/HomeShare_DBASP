﻿using HomeShare.DAL.Repositories;
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

        public MembreEntity GetFromLogin(string login)
        {
            //sans la vérif du password, à faire si temps
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("login", login);
            return base.Get("Select * from [Membre] where Login=@login", p).FirstOrDefault();
        }
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
            string requete = @"EXEC [dbo].[SP_Ajout_User]
            @nom,
            @prenom,
            @email,
            @tel,
            @login,
            @password,
            @pays";
            return base.Insert(toInsert, requete);
        }

        public bool Update(MembreEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
