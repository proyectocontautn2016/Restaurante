using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRestaurante
{
    public class EncabezadoFacturaEntidad
    {
        public int idEncabezadoFactura { get; set; }
        public EncabezadoPedidoEntidad encabezadoPedido { get; set; }
        public RestauranteEntidad restaurante { get; set; }
        public String identificacionCliente { get; set; }
        public String nombreCliente { get; set; }
        public DateTime fecha { get; set; }
        public TipoPagoEntidad tipoPago { get; set; }
        public EncabezadoFacturaEntidad()
        {
            encabezadoPedido = new EncabezadoPedidoEntidad();
            restaurante = new RestauranteEntidad();
            tipoPago = new TipoPagoEntidad();
        }
    }
}
