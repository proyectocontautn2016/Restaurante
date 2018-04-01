using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosRestaurante
{
    public class TipoPagoDatos
    {
        public static DataSet SeleccionarTodos()
        {
            SqlCommand comando = new SqlCommand("PA_SeleccionarTipoPagos");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = null;

            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                ds = db.ExecuteReader(comando, "tipoPago");
            }
            return ds;
        }
    }
}
