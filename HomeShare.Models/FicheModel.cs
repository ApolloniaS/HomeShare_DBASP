using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Models
{
    public class FicheModel
    {
        string _photo, _titre, _descLongue, _drapeau, _nomDuProprio;
        int _idBien, _nombrePersonnes;
        private List<AvisMembreModel> _avisMembre;
        public string Photo { get => _photo; set => _photo = value; }
        public string Titre { get => _titre; set => _titre = value; }
        public int NombrePersonnes { get => _nombrePersonnes; set => _nombrePersonnes = value; }
        public string DescLongue { get => _descLongue; set => _descLongue = value; }
        public string Drapeau { get => _drapeau; set => _drapeau = value; }
        public int IdBien { get => _idBien; set => _idBien = value; }
        public List<AvisMembreModel> AvisMembre { get => _avisMembre; set => _avisMembre = value; }
        public string NomDuProprio { get => _nomDuProprio; set => _nomDuProprio = value; }
    }
}
