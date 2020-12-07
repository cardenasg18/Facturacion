using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }


        [Required]
        [Display(Name = "Correo")]
        [ForeignKey("UserMail")]
        public int UserId { get; set; }
        public Usuario Usuario { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password, ErrorMessage = "Clave no válida.")]
        public int Password { get; set; }
    }
}
