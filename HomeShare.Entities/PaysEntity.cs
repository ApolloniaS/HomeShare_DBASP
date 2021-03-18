using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Entities
{
    public class PaysEntity
    {
        private int _idPays;
        private string _libelle, _drapeau;

        public int IdPays { get => _idPays; set => _idPays = value; }
        public string Libelle { get => _libelle; set => _libelle = value; }
        public string Drapeau { get => _drapeau; set => _drapeau = value; }
    }
}
