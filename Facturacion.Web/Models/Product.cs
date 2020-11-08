using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Product
    {
        [Key]
        public int ProductiD { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Límite de carácteres excedido.")]
        [Display(Name = "Producto")]
        public string  ProductName { get; set; }

        [Required]
        [Display(Name ="Cantidad")]
        public int Cantidad { get; set; }

        [Required]
        [Display(Name = "Unidad de medida")]
        [ForeignKey("UnitName")]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        [StringLength(200, ErrorMessage ="Límite de carácteres excedido.")]
        [Display(Name ="Retiros")]
        public string Retiro { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Precio unidad")]
        [DataType(DataType.Currency)]
        public decimal PriceP { get; set; }



    }
}
