using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Exchange
    {
        [Key]
        public int ExchangeId { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio.")]
        [Display(Name ="Tasa de cambio")]       
        public float Rate { get; set; }

        public ICollection<Currency> Currencies { get; set; }
    }
}
