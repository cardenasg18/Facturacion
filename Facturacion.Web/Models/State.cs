using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, ErrorMessage = "Límete de caracteres excedido.")]
        [Display(Name = "Provincia")]
        public string StateName { get; set; }

        [Required]
        [Display(Name = "País")]
        [ForeignKey("CountryName")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
