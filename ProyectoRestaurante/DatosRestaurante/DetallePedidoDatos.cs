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
    public class DetallePedidoDatos
    {
        public static DataSet SeleccionarTodosporID(int idPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_SeleccionarDetallesPedido");
            // Es requerido indicar que el tipo es un StoreProcedure
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idEncabezadoPedido", idPedido);
            DataSet ds = db.ExecuteReader(comando, "detallePedido");
            return ds;
        }


        public static void Insertar(DetallePedidoEntidad detalle)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_InsertarDetallesPedido");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idEncabezadoPedido", detalle.idEncabezadoPedido);
            comando.Parameters.AddWithValue("@idProducto", detalle.producto.idProducto);
            comando.Parameters.AddWithValue("@cantidad", detalle.cantidad);
            comando.Parameters.AddWithValue("@precio", detalle.precio);
            comando.Parameters.AddWithValue("@comentario", detalle.comentario);

            int estado = 0;
            if (detalle.estado == true)
            {
                estado = 1;
            }
            comando.Parameters.AddWithValue("@estado", estado);
            db.ExecuteNonQuery(comando);
        }


        public static void Modificar(DetallePedidoEntidad detalle)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_ModificarProductos");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", detalle.idDetallePedido);
            comando.Parameters.AddWithValue("@idEncabezadoPedido", detalle.idEncabezadoPedido);
            comando.Parameters.AddWithValue("@idProducto", detalle.producto.idProducto);
            comando.Parameters.AddWithValue("@cantidad", detalle.cantidad);
            comando.Parameters.AddWithValue("@precio", detalle.precio);
            comando.Parameters.AddWithValue("@comentario", detalle.comentario);

            int estado = 0;
            if (detalle.estado == true)
            {
                estado = 1;
            }
            comando.Parameters.AddWithValue("@estado", estado);
            db.ExecuteNonQuery(comando);
        }
    }
}
