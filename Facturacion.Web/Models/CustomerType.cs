using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class CustomerType
    {
        [Key]
        public int CTypeId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(30, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Tipo cliente")]
        public string TypeCustomer { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
