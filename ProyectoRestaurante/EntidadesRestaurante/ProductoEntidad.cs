using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRestaurante
{
    public class ProductoEntidad
    {
        public int idProducto { get; set; }
        public TipoProductoEntidad tipoProducto { get; set; }
        public String nombre { get; set; }
        public Decimal precio { get; set; }
        public String imagen { get; set; }
        public Boolean estado { get; set; }

        public ProductoEntidad()
        {
            tipoProducto = new TipoProductoEntidad();
        }
    }
}
