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
        public UsuarioEntidad usuario { get; set; }
        public String nombreCliente { get; set; }
        public DateTime fecha { get; set; }
        public List<MontoPorTipoPagoEntidad> listaFormaPago { get; set; }
        public MontoPorTipoPagoEntidad miTipoPago { get; set; }
        public Decimal IV { get; set; }
        public Decimal Subtotal { get; set; }
        public Decimal Total { get; set; }

        public EncabezadoFacturaEntidad()
        {
            encabezadoPedido = new EncabezadoPedidoEntidad();
            restaurante = new RestauranteEntidad();
            usuario = new UsuarioEntidad();
            listaFormaPago = new List<MontoPorTipoPagoEntidad>();
            miTipoPago = new MontoPorTipoPagoEntidad();
        }
    }
}
