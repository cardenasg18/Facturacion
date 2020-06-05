using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, ErrorMessage = "Límete de caracteres excedido.")]
        [Display(Name = "Municipio")]
        public string CityName { get; set; }

        [Required]
        [Display(Name = "Provincia")]
        [ForeignKey("StateName")]
        public int StateId { get; set; }
        public State State { get; set; }


        public ICollection<Neighborhood> Neighborhoods { get; set; }
    }
}
