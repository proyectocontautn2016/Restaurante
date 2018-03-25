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
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_SeleccionarMesas");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "mesa");
            return ds;
        }

        public static void Insertar(MesaEntidad mesa)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_InsertarMesa");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idEstadoMesa", mesa.estadoMesa.estadoMesa);
            comando.Parameters.AddWithValue("@cantidadPersonas", mesa.cantidadPersonas);
            db.ExecuteNonQuery(comando);

          }


        public static void Modificar(MesaEntidad mesa)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_ModificarMesa");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", mesa.idMesa);
            comando.Parameters.AddWithValue("@idEstadoMesa", mesa.estadoMesa.estadoMesa);
            comando.Parameters.AddWithValue("@cantidadPersonas", mesa.cantidadPersonas);
            db.ExecuteNonQuery(comando);
        }
    }
}
