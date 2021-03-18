using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Models
{
    public class LoginModel
    {
        private string _login, _password;

        public string Login { get => _login; set => _login = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
