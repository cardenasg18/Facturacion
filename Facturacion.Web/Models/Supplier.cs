using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Suplidor")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo invalido")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Número invalido.")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Sólo debe Colocar Números")]
        public int Telephone { get; set; }

        [Required]
        [Display(Name = "Ubicación")]
        [ForeignKey("Address")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [Required]
        [Display(Name = "Tipo de suplidor")]
        [ForeignKey("Type")]
        public int SupplierTypeId { get; set; }
        public SupplierType SupplierType { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
