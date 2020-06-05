using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(30, ErrorMessage = "Límite de caracteres excedido")]
        [Display(Name = "Moneda")]
        public string CurrencyName { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
