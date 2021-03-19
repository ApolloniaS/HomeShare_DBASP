using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Models
{
    public class BienAEchangerModel
    {
        private string _photo, _titre, _codePostal, _ville, _descCourte, _nomPays, _drapeau;
        private bool _assuranceObligatoire, _isEnabled;
        private int _idBien, _pays, _nombrePersonne;
        private DateTime _dateCreation;
        //pour la fiche dans le bien
        private string _photoFiche, _titreFiche, _nombrePersonneFiche, _descFiche, _drapeauFiche;



        public string Photo { get => _photo; set => _photo = value; }
        public bool AssuranceObligatoire { get => _assuranceObligatoire; set => _assuranceObligatoire = value; }
        public bool IsEnabled { get => _isEnabled; set => _isEnabled = value; }
        public string Titre { get => _titre; set => _titre = value; }
        public string CodePostal { get => _codePostal; set => _codePostal = value; }
        public string Ville { get => _ville; set => _ville = value; }
        public string DescCourte { get => _descCourte; set => _descCourte = value; }
        public int IdBien { get => _idBien; set => _idBien = value; }
        public int Pays { get => _pays; set => _pays = value; }
        public string NomPays { get => _nomPays; set => _nomPays = value; }
        public int NombrePersonne { get => _nombrePersonne; set => _nombrePersonne = value; }
        public string Drapeau { get => _drapeau; set => _drapeau = value; }
        public string PhotoFiche { get => _photoFiche; set => _photoFiche = value; }
        public string TitreFiche { get => _titreFiche; set => _titreFiche = value; }
        public string NombrePersonneFiche { get => _nombrePersonneFiche; set => _nombrePersonneFiche = value; }
        public string DescFiche { get => _descFiche; set => _descFiche = value; }
        public string DrapeauFiche { get => _drapeauFiche; set => _drapeauFiche = value; }
        public DateTime DateCreation { get => _dateCreation; set => _dateCreation = value; }
    }
}
