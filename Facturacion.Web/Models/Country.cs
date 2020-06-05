using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Country
    {

        [Key]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, ErrorMessage = "Límete de caracteres excedido.")]
        [Display(Name = "País")]
        public string CountryName { get; set; }

        public ICollection<State> States { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
