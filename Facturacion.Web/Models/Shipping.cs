using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Shipping
    {

        [Key]
        public int ShippingId { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio.")]
        [Display(Name ="Forma de envío")]
        [MaxLength(30, ErrorMessage ="Límite de caracteres excedido.")]
        public string ShippWay { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
