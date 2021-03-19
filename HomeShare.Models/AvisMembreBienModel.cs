using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Models
{
    public class AvisMembreModel
    {
        private int idMembre;
        private string _login, _message;
        private int _note;

        public int IdMembre { get => idMembre; set => idMembre = value; }
        public string Login { get => _login; set => _login = value; }
        public string Message { get => _message; set => _message = value; }
        public int Note { get => _note; set => _note = value; }
    }
}
