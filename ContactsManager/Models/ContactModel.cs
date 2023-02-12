using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsManager.Models
{
    [Table("Contacts")]
    public class ContactModel
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage ="Por favor insira seu nome")]
        [StringLength(255)]
        [DisplayName("Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Por favor insira seu E-mail")]
        [StringLength(100)]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage = "Por favor insira seu Telefone")]
        [StringLength(100)]
        [DisplayName("Telefone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Por favor insira seu Nº de Celular")]
        [StringLength(11,ErrorMessage ="Permitido somente 11 numeros")]
        [DisplayName("Celular")]
        public string CelPhone { get; set; }


    }
}
