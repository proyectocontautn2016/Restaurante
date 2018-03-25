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
    public class UsuarioDatos
    {
        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_SeleccionarUsuarios");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "usuario");
            return ds;
        }

        public static void Insertar(UsuarioEntidad usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_InsertarUsuarios");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@id", usuario.idUsuario);
            comando.Parameters.AddWithValue("@idRol", usuario.rol.idRol);
            comando.Parameters.AddWithValue("@nombre", usuario.nombre);
            comando.Parameters.AddWithValue("@direccion", usuario.direccion);
            comando.Parameters.AddWithValue("@correo", usuario.email);
            comando.Parameters.AddWithValue("@password", usuario.password);
            comando.Parameters.AddWithValue("@telefono", usuario.telefono);
            comando.Parameters.AddWithValue("@estado", usuario.estado);
            db.ExecuteNonQuery(comando);
        }


        public static void Modificar(UsuarioEntidad usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_ModificarUsuarios");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", usuario.idUsuario);
            comando.Parameters.AddWithValue("@idRol", usuario.rol.idRol);
            comando.Parameters.AddWithValue("@nombre", usuario.nombre);
            comando.Parameters.AddWithValue("@direccion", usuario.direccion);
            comando.Parameters.AddWithValue("@correo", usuario.email);
            comando.Parameters.AddWithValue("@password", usuario.password);
            comando.Parameters.AddWithValue("@telefono", usuario.telefono);
            comando.Parameters.AddWithValue("@estado", usuario.estado);
            db.ExecuteNonQuery(comando);
        }

    }
}
