using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Estado")]
        public string StatusOf { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
