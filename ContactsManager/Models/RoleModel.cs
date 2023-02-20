using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsManager.Models
{
    [Table("roles")]
    public class RoleModel
    {
        [Key]
        public string RoleId { get; set; } = Guid.NewGuid().ToString(); 
        [Required]
        [DisplayName("Perfil")]
        [StringLength(15,ErrorMessage ="permitido até 15 caracteres!")]
        public string RoleName { get; set; }
        public UserModel User { get; set; }
        public string UserId { get; set; }  
    }
}
