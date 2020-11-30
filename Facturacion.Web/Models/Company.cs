using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(30, ErrorMessage = "Limite de caracteres excedido.")]
        [Display(Name = "Empresa")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(100, ErrorMessage = "Limite de caracteres excedido.")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }


        [Display(Name = "Telefono")]
        [MaxLength(10, ErrorMessage = "Número incorrecto.")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Sólo debe Colocar Números")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo invalido.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Ubicación")]
        [ForeignKey("Address")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [Required]
        [Display(Name = "Vendedor")]
        [ForeignKey("SellerName")]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }


        public ICollection<Brand> Brands { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
