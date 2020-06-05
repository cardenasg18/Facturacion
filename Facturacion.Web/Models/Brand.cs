using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(30, ErrorMessage = "Limite de caracteres excedido.")]
        [Display(Name = "Marca")]
        public string BrandName { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        [ForeignKey("CompanyName")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
