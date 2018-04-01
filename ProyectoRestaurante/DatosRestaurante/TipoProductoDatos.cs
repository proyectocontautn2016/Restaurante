using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosRestaurante
{
    public class TipoProductoDatos
    {
        public static DataSet SeleccionarTodos()
        {
            SqlCommand comando = new SqlCommand("PA_SeleccionarTipoProductos");
            comando.CommandType = CommandType.StoredProcedure;
            
            DataSet ds = null;

            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                ds = db.ExecuteReader(comando, "tipoProducto");
            }
            return ds;
        }
    }
}
