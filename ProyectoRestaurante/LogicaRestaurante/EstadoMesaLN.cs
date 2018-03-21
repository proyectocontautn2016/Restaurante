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
    public class EstadoMesaLN
    {
        public static List<EstadoMesaEntidad> ObtenerTodos()
        {
            List<EstadoMesaEntidad> lista = new List<EstadoMesaEntidad>();
            DataSet ds = EstadoMesaDatos.SeleccionarTodos();


            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                 /*public int estadoMesa { get; set; }
                 public String descripcion { get; set; }*/

                EstadoMesaEntidad elemento = new EstadoMesaEntidad();
                elemento.estadoMesa = Convert.ToInt16(fila["id"].ToString());
                elemento.descripcion = fila["descripcion"].ToString();
                
                lista.Add(elemento);
            }

            return lista;
        }
    }
}
