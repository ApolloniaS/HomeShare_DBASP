using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Entities
{
    public class BienEchangeEntity
    {
        private int _idBien, _nombrePerson, _pays, _idMembre;
        private string _titre, descCourte, descLong, _ville, _rue, _numero, _codePostal, _photo, _latitude, _longitude;
        private bool _assuranceObligatoire, _isEnabled;
        private DateTime _disabledDate, _dateCreation;

        public int IdBien { get => _idBien; set => _idBien = value; }
        public int NombrePerson { get => _nombrePerson; set => _nombrePerson = value; }
        public int Pays { get => _pays; set => _pays = value; }
        public int IdMembre { get => _idMembre; set => _idMembre = value; }
        public string Titre { get => _titre; set => _titre = value; }
        public string DescCourte { get => descCourte; set => descCourte = value; }
        public string DescLong { get => descLong; set => descLong = value; }
        public string Ville { get => _ville; set => _ville = value; }
        public string Rue { get => _rue; set => _rue = value; }
        public string Numero { get => _numero; set => _numero = value; }
        public string CodePostal { get => _codePostal; set => _codePostal = value; }
        public string Photo { get => _photo; set => _photo = value; }
        public string Latitude { get => _latitude; set => _latitude = value; }
        public string Longitude { get => _longitude; set => _longitude = value; }
        public bool AssuranceObligatoire { get => _assuranceObligatoire; set => _assuranceObligatoire = value; }
        public bool IsEnabled { get => _isEnabled; set => _isEnabled = value; }
        public DateTime DisabledDate { get => _disabledDate; set => _disabledDate = value; }
        public DateTime DateCreation { get => _dateCreation; set => _dateCreation = value; }
    }
}
