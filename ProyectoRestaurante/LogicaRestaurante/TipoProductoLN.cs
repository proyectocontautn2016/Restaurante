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
    public class TipoProductoLN
    {
        public static List<TipoProductoEntidad> ObtenerTodos()
        {
            /*public int idTipoProducto { get; set; }
            public String descripcion { get; set; }
            public Boolean estado { get; set; }*/

            List<TipoProductoEntidad> lista = new List<TipoProductoEntidad>();
            DataSet ds = TipoProductoDatos.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                TipoProductoEntidad elemento = new TipoProductoEntidad();
                elemento.idTipoProducto = Convert.ToInt16(fila["id"].ToString());
                elemento.descripcion =fila["descripcion"].ToString();

                if(Convert.ToInt16(fila["estado"].ToString()) == 1)
                {
                    elemento.estado = true;
                }else
                {
                    elemento.estado = false;
                }
                
                lista.Add(elemento);
            }


            return lista;
        }
    }
}
