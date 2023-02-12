using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ContactsManager.Models
{
    public class UserModel
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage ="Campo Obrigatório")]
        [DisplayName("Nome")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Campo Obrigatório")]
        [DisplayName("E-mail")]
        [StringLength(155)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Campo Obrigatório")]
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
