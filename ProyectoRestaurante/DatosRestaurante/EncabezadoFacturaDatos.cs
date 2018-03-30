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
    public class EncabezadoFacturaDatos
    {
        public static DataSet SeleccionarTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_SeleccionarEncabezadosFactura");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "EncabezadoFactura");
            return ds;
        }

        public static DataSet Insertar(EncabezadoFacturaEntidad encabezado)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_InsertarEncabezadoFactura");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idEncabezadoPedido", encabezado.encabezadoPedido.idEncabezadoPedido);
            comando.Parameters.AddWithValue("@idRestaurante", encabezado.restaurante.idRestaurante);
            comando.Parameters.AddWithValue("@idUsuario", encabezado.usuario.idUsuario);
            comando.Parameters.AddWithValue("@nombreCliente", encabezado.nombreCliente);
            comando.Parameters.AddWithValue("@fecha", encabezado.fecha);
            comando.Parameters.AddWithValue("@iv", encabezado.IV);
            comando.Parameters.AddWithValue("@subTotal", encabezado.Subtotal);
            comando.Parameters.AddWithValue("@total", encabezado.Subtotal);

            DataSet ds = db.ExecuteReader(comando, "EncabezadoFactura");
            return ds;
        }


        public static void Modificar(EncabezadoFacturaEntidad encabezado)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("PA_ModificarEncabezadoFactura");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", encabezado.idEncabezadoFactura);
            comando.Parameters.AddWithValue("@idEncabezadoPedido", encabezado.encabezadoPedido.idEncabezadoPedido);
            comando.Parameters.AddWithValue("@idRestaurante", encabezado.restaurante.idRestaurante);
            comando.Parameters.AddWithValue("@idUsuario", encabezado.usuario.idUsuario);
            comando.Parameters.AddWithValue("@nombreCliente", encabezado.nombreCliente);
            comando.Parameters.AddWithValue("@fecha", encabezado.fecha);
            db.ExecuteNonQuery(comando);
        }
    }
}
