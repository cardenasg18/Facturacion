using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio.")]
        [Display(Name ="Forma de pago")]
        [MaxLength(20, ErrorMessage ="Límite de caracteres excedido.")]
        public string Pway { get; set; }

    }
}
