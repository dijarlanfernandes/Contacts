using System.ComponentModel.DataAnnotations;

namespace ContactsManager.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Campo Obrigatório!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Campo Obrigatório!")]
        public string Password { get; set; }
    }
}
