using DatosRestaurante;
using EntidadesRestaurante;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaRestaurante
{
    public class EstadoPedidoLN
    {
        public static List<EstadoPedidoEntidad> ObtenerTodos()
        {
            /*public int idEstadoPedido { get; set; }
            public String descripcion { get; set; }*/

            List<EstadoPedidoEntidad> lista = new List<EstadoPedidoEntidad>();
            DataSet ds = EstadoPedidoDatos.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                EstadoPedidoEntidad elemento = new EstadoPedidoEntidad();
                elemento.idEstadoPedido = Convert.ToInt16(fila["id"].ToString());
                elemento.descripcion = fila["descripcion"].ToString();
               
                lista.Add(elemento);
            }


            return lista;
        }
    }
}
