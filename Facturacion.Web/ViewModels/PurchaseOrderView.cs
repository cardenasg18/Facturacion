using Facturacion.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.ViewModels
{
    public class PurchaseOrderView
    {
        public Models.PurchaseOrder PurchaseOrder { get; set; }
        public PurchaseDetail PurchaseDetail { get; set; }
        public Customer Customer { get; set; }
        public Shipping Shipping { get; set; }
        public Payment Payment { get; set; }
        public Chair Chair { get; set; }
        public List<PurchaseDetail> PurchaseDetails { get; set; }
    }

}
