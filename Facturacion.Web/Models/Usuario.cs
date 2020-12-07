using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Usuario
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo invalido.")]
        public string UserMail { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password, ErrorMessage = "Clave no válida.")]
        public int Password { get; set; }

        [Required]
        [Display(Name = "Rol usuario")]
        [ForeignKey("RoleName")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<Login> Logins { get; set; }


    }
}
