using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosRestaurante
{
    public class DetallePedidoDatos
    {
        public static DataSet SeleccionarTodosporID(int idPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarDetallesPedido");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idEncabezadoPedido", idPedido);
            DataSet ds = db.ExecuteReader(comando, "carrera");
            return ds;
        }
    }
}
