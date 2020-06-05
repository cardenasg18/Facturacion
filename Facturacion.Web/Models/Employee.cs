using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(40, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Nombre empleado")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(40, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Número invalido.")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo invalido.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        [ForeignKey("CompanyName")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        [Display(Name = "Posición empleado")]
        [ForeignKey("PositionName")]
        public int PositionId { get; set; }
        public Position Position { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [ForeignKey("StatusOf")]
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
