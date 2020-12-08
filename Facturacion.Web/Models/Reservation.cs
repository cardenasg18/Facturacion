using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Reservation
    {
        [Key]
        public int RservationId { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [ForeignKey("CustomerName")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio")]
        [Display(Name ="Cantidad de personas")]
        public int Personas { get; set; }

        [Required]
        [Display(Name = "Forma de envio")]
        [ForeignKey("ShippWay")]
        public int ShippingId { get; set; }
        public Shipping Shipping { get; set; }

        [Display(Name = "Fecha de la orden")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime OrderTime { get; set; }

        [Display(Name = "Hora")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }

    }
}
