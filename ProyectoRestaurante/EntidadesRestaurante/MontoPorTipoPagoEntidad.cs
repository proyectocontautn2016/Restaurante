using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRestaurante
{
    public class MontoPorTipoPagoEntidad
    {
        public TipoPagoEntidad TipoPago { get; set; }
        public int encabezadoFactura { get; set; }
        public decimal monto { get; set; }

        public MontoPorTipoPagoEntidad() {
            TipoPago = new TipoPagoEntidad();
        }
    }
}
