using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRestaurante
{
    public class DetallePedidoEntidad
    {
        public int idDetallePedido { get; set; }
        public int idEncabezadoPedido { get; set; }
        public ProductoEntidad producto { get; set; }
        public int cantidad { get; set; }
        public Decimal precio { get; set; }
        public String comentario { get; set; }
        public Boolean estado { get; set; }

        public DetallePedidoEntidad()
        {
            producto = new ProductoEntidad();
        }
    }
}
