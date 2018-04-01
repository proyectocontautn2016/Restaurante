using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosRestaurante
{
    public class RolDatos
    {
        public static DataSet SeleccionarTodos()
        {
            SqlCommand comando = new SqlCommand("PA_SeleccionarRol");
            comando.CommandType = CommandType.StoredProcedure;
           
            DataSet ds = null;

            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                ds = db.ExecuteReader(comando, "rol");
            }
            return ds;
        }
    }
}
