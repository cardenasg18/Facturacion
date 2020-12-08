using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [Display(Name = "Estado")]
        [ForeignKey("StatusOf")]
        public int StatusId { get; set; }
        public Status Status { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
