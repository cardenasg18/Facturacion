using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Vendedor")]
        public string SellerName { get; set; }

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Número invalido.")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo invalido.")]
        public string Email { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
