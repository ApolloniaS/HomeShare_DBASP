﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Models
{
    public class BienAEchangerModel
    {
        private string _photo, _titre, _codePostal, _ville, _descCourte;
        private bool _assuranceObligatoire, _isEnabled;
        private int _idBien, _pays;
        

        public string Photo { get => _photo; set => _photo = value; }
        public bool AssuranceObligatoire { get => _assuranceObligatoire; set => _assuranceObligatoire = value; }
        public bool IsEnabled { get => _isEnabled; set => _isEnabled = value; }
        public string Titre { get => _titre; set => _titre = value; }
        public string CodePostal { get => _codePostal; set => _codePostal = value; }
        public string Ville { get => _ville; set => _ville = value; }
        public string DescCourte { get => _descCourte; set => _descCourte = value; }
        public int IdBien { get => _idBien; set => _idBien = value; }
        public int Pays { get => _pays; set => _pays = value; }
    }
}