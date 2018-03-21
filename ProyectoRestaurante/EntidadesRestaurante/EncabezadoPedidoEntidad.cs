using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRestaurante
{
    public class EncabezadoPedidoEntidad
    {
        public int idEncabezadoPedido { get; set; }
        public MesaEntidad mesa { get; set; }
        public UsuarioEntidad usuario { get; set; }
        public EstadoPedidoEntidad estadoPedido { get; set; }
        public List<DetallePedidoEntidad> listaDetalles { get; set; }
        public Boolean estado { get; set; }
        public EncabezadoPedidoEntidad()
        {
            mesa = new MesaEntidad();
            usuario = new UsuarioEntidad();
            estadoPedido = new EstadoPedidoEntidad();
        }
    }
}
