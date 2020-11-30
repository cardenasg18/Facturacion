using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(100, ErrorMessage = "Límite de caracteres excedido")]
        [Display(Name = "Artículo")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Unidades disponibles")]
        public int UnitsInStock { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Límite de caracteres excedido.")]
        [Display(Name = "Descripción")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Precio unidad")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [Required]
        [Display(Name = "Clasificación de artículo")]
        [ForeignKey("ItemType")]
        public int ClasificationId { get; set; }
        public Clasification Clasification { get; set; }

        [Required]
        [Display(Name = "Marca")]
        [ForeignKey("BrandName")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        [Required]
        [Display(Name = "Moneda")]
        [ForeignKey("CurrencyName")]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        [Required]
        [Display(Name = "Unidad de medida")]
        [ForeignKey("UnitName")]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [ForeignKey("StatusOf")]
        public int StatusId { get; set; }
        public Status Status { get; set; }

        [Required]
        [Display(Name = "Suplidor")]
        [ForeignKey("SupplierName")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
