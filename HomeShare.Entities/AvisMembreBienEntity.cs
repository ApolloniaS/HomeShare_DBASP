using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Entities
{
    public class AvisMembreBienEntity
    {
        private int _idAvis, _note, _idMembre, _idBien;
        private string _message;
        private DateTime _dateAvis;
        private bool _approuve;

        public int IdAvis { get => _idAvis; set => _idAvis = value; }
        public int Note { get => _note; set => _note = value; }
        public int IdMembre { get => _idMembre; set => _idMembre = value; }
        public int IdBien { get => _idBien; set => _idBien = value; }
        public string Message { get => _message; set => _message = value; }
        public DateTime DateAvis { get => _dateAvis; set => _dateAvis = value; }
        public bool Approuve { get => _approuve; set => _approuve = value; }
    }
}
