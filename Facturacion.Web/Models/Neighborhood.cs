using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Neighborhood
    {
        [Key]
        public int NeighborhoodId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, ErrorMessage = "Límete de caracteres excedido.")]
        [Display(Name = "Sector")]
        public string NeighborhoodName { get; set; }

        [Required]
        [Display(Name = "Municipio")]
        [ForeignKey("CityName")]
        public int CityId { get; set; }
        public City City { get; set; }

    }
}
