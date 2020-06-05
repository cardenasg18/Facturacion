using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(40, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Ubicación")]
        public string Address { get; set; }

        [MaxLength(10, ErrorMessage = "Límite de carácteres excedido.")]
        [Display(Name = "Código postal")]
        [DataType(DataType.PostalCode, ErrorMessage = "Código postal invalido")]
        public string PostalCode { get; set; }

        [StringLength(80, ErrorMessage = "Límite de carácteres excedido.")]
        [Display(Name = "Puntos de referencia")]
        public string Reference { get; set; }

        [Required]
        [Display(Name = "País")]
        [ForeignKey("CountryName")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Company> Companies { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}
