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
    public class RolLN
    {
        public static List<RolEntidad> ObtenerTodos()
        {
            /*public int idRol { get; set; }
            public String descripcion { get; set; }*/

            List<RolEntidad> lista = new List<RolEntidad>();
            DataSet ds = RolDatos.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                RolEntidad elemento = new RolEntidad();
                elemento.idRol = Convert.ToInt16(fila["id"].ToString());
                elemento.descripcion = fila["descripcion"].ToString();
                
                lista.Add(elemento);
            }



            return lista;
        }
    }
}
