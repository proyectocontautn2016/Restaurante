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
    public class MontoPorTipoPagoLN
    {
        public static List<MontoPorTipoPagoEntidad> ObtenerTodos(int id)
        {
            /*public int idTipoPago { get; set; }
            public int encabezadoFactura { get; set; }
            public decimal monto { get; set; }*/

            List<MontoPorTipoPagoEntidad> lista = new List<MontoPorTipoPagoEntidad>();
            DataSet ds = MontoPorTipoPagoDatos.SeleccionarTodos(id);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                MontoPorTipoPagoEntidad elemento = new MontoPorTipoPagoEntidad();
                elemento.TipoPago.idTipoPago = Convert.ToInt16(fila["idTipoPago"].ToString());
                elemento.TipoPago.descripcion = fila["descripcion"].ToString();
                elemento.encabezadoFactura = Convert.ToInt16(fila["idEncabezadoFactura"].ToString());
                elemento.monto = Convert.ToInt16(fila["monto"].ToString());
               
                lista.Add(elemento);
            }


            return lista;
        }
    }
}
