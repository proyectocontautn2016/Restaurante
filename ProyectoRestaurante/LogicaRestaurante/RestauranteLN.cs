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
    public class RestauranteLN
    {
        public static List<RestauranteEntidad> ObtenerTodos()
        {
            /*public int idRestaurante { get; set; }
            public String nombre { get; set; }
            public String direccion { get; set; }
            public String telefono { get; set; }
            public String logo { get; set; }*/

            List<RestauranteEntidad> lista = new List<RestauranteEntidad>();
            DataSet ds = RestauranteDatos.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                RestauranteEntidad elemento = new RestauranteEntidad();
                elemento.idRestaurante = Convert.ToInt16(fila["id"].ToString());
                elemento.nombre = fila["nombre"].ToString();
                elemento.direccion = fila["direccion"].ToString();
                elemento.telefono = fila["telefono"].ToString();
                elemento.logo = fila["logo"].ToString();

                lista.Add(elemento);
            }


            return lista;
        }
    }
}
