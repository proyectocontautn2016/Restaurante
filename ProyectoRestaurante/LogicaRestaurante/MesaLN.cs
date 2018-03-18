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
    public class MesaLN
    {
        public static List<MesaEntidad> ObtenerTodos()
        {
            List<MesaEntidad> lista = new List<MesaEntidad>();
            DataSet ds = MesaDatos.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                MesaEntidad elemento = new MesaEntidad();
                elemento.idMesa = Convert.ToInt16(fila["id"].ToString());

                EstadoMesaEntidad estadoMesa = new EstadoMesaEntidad();
                estadoMesa.estadoMesa = Convert.ToInt16(fila["idEstadoMesa"].ToString());
                estadoMesa.descripcion = fila["descripcion"].ToString();

                elemento.estadoMesa = estadoMesa;

                lista.Add(elemento);
            }

            return lista;
        }
    }
}
