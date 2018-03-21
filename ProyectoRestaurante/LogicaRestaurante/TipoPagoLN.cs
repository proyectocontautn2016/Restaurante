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
    public class TipoPagoLN
    {
        public static List<TipoPagoEntidad> ObtenerTodos()
        {
            /*public int idTipoPago { get; set; }
            public String descripcion { get; set; }*/

            List<TipoPagoEntidad> lista = new List<TipoPagoEntidad>();
            DataSet ds = TipoPagoDatos.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                TipoPagoEntidad elemento = new TipoPagoEntidad();
                elemento.idTipoPago = Convert.ToInt16(fila["id"].ToString());
                elemento.descripcion = fila["descripcion"].ToString();
               
                lista.Add(elemento);
            }


            return lista;
        }
    }
}
