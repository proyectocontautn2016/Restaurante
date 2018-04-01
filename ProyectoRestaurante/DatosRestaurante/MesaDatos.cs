using EntidadesRestaurante;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosRestaurante
{
    public class MesaDatos
    {
        public static DataSet SeleccionarTodos()
        {
            SqlCommand comando = new SqlCommand("PA_SeleccionarMesas");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = null;

            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                ds = db.ExecuteReader(comando, "mesa");
            }

            return ds;
        }

        public static void Insertar(MesaEntidad mesa)
        {
            SqlCommand comando = new SqlCommand("PA_InsertarMesa");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idEstadoMesa", mesa.estadoMesa.estadoMesa);
            comando.Parameters.AddWithValue("@cantidadPersonas", mesa.cantidadPersonas);
          
            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                db.ExecuteNonQuery(comando);

            }

        }


        public static void Modificar(MesaEntidad mesa)
        {
            SqlCommand comando = new SqlCommand("PA_ModificarMesa");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", mesa.idMesa);
            comando.Parameters.AddWithValue("@idEstadoMesa", mesa.estadoMesa.estadoMesa);
            comando.Parameters.AddWithValue("@cantidadPersonas", mesa.cantidadPersonas);

            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                db.ExecuteNonQuery(comando);
            }
        }
    }
}
