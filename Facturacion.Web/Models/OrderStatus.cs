using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturacion.Web.Models
{
    public enum OrderStatus
    {
        Creada,
        EnProgreso,
        Enviada,
        Entregada,
        Detenida,
        Cancelada
    }
}
