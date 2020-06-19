using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [Display(Name ="Tasa de cambio")]
        [ForeignKey("ExchangeName")]
        public int ExchangeId { get; set; }
        public Exchange Exchange { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
