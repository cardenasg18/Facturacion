using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(40, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Nombre")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(40, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Tipo Documento")]
        [ForeignKey("TypeDocument")]
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(20, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Documento")]
        public string Document { get; set; }

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Número invalido")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo invalido.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Tipo cliente")]
        [ForeignKey("TypeCustomer")]
        public int CTypeId { get; set; }
        public CustomerType CustomerType { get; set; }

        [Required]
        [Display(Name = "País")]
        [ForeignKey("CountryName")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
