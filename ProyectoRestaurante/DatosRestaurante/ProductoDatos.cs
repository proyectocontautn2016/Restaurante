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
    public class ProductoDatos
    {
        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_SeleccionarProductos");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "producto");
            return ds;
        }

        public static void Insertar(ProductoEntidad producto)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_InsertarProductos");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idTipoProducto", producto.tipoProducto.idTipoProducto);
            comando.Parameters.AddWithValue("@nombre", producto.nombre);
            comando.Parameters.AddWithValue("@precio", producto.precio);
            comando.Parameters.AddWithValue("@imagen", producto.imagen);

            int estado = 0;
            if(producto.estado == true)
            {
                estado = 1;
            }
            comando.Parameters.AddWithValue("@estado", estado);
            db.ExecuteNonQuery(comando);
        }


        public static void Modificar(ProductoEntidad producto)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_ModificarProductos");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", producto.idProducto);
            comando.Parameters.AddWithValue("@idTipoProducto", producto.tipoProducto.idTipoProducto);
            comando.Parameters.AddWithValue("@nombre", producto.nombre);
            comando.Parameters.AddWithValue("@precio", producto.precio);
            comando.Parameters.AddWithValue("@imagen", producto.imagen);

            int estado = 0;
            if (producto.estado == true)
            {
                estado = 1;
            }
            comando.Parameters.AddWithValue("@estado", estado);
            db.ExecuteNonQuery(comando);
        }
    }
}
