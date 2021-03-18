using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Entities
{
    public class FicheEntity
    {
            string _photo, _titre, _descLong, _drapeau;
            int _idBien, _nombrePerson;
            
            public string Photo { get => _photo; set => _photo = value; }
            public string Titre { get => _titre; set => _titre = value; }
            public int NombrePerson { get => _nombrePerson; set => _nombrePerson = value; }
            public string DescLong { get => _descLong; set => _descLong = value; }
            public string Drapeau { get => _drapeau; set => _drapeau = value; }
            public int IdBien { get => _idBien; set => _idBien = value; }

       
    }
}
