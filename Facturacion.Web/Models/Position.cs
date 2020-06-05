using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Posición empleado")]
        public string PositionName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
