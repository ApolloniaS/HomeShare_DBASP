using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShare.Models
{
    public class MembreModel
    {
        private int _idMembre, _pays;
        private string _nom, _prenom, _email, _telephone, _login, _password, _passwordConfirmation;

        public int IdMembre { get => _idMembre; set => _idMembre = value; }
        [Required]
        public int Pays { get => _pays; set => _pays = value; }
        [Required]
        [MaxLength(50)]
        public string Nom { get => _nom; set => _nom = value; }
        [Required]
        [MaxLength(50)]
        public string Prenom { get => _prenom; set => _prenom = value; }
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get => _email; set => _email = value; }
        [Required]
        public string Telephone { get => _telephone; set => _telephone = value; }
        [Required]
        [MaxLength(50)] 
        public string Login { get => _login; set => _login = value; }
        [Required]
        [MaxLength(50)] 
        public string Password { get => _password; set => _password = value; }
        [Required]
        [MaxLength(50)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne sont pas identiques !")]
        public string PasswordConfirmation { get => _passwordConfirmation; set => _passwordConfirmation = value; }
    }
}
