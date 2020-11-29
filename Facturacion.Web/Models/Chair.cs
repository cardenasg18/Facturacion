using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public class Chair
    {
        [Key]
        public int ChairID { get; set; }

        [Required]
        [Display(Name ="Silla")]
        public string ChairName { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [ForeignKey("StatusOf")]
        public int StatusId { get; set; }
        public Status Status { get; set; }

        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
