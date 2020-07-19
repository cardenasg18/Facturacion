using Facturacion.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.ViewModels
{
    public class OrderView
    {
        public Models.Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public Customer Customer { get; set; }
        public Shipping Shipping { get; set; }
        public Payment Payment { get; set; }
        public List<OrderDetail> Details { get; set; }
    }
}
