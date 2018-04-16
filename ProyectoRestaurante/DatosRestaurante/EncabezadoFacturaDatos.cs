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
        public static DataSet SeleccionarTodos(DateTime fechaInicial, DateTime fechaFinal)
        {
            SqlCommand comando = new SqlCommand("PA_SeleccionarEncabezadosFactura");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fechaInicial", fechaInicial);
            comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
            DataSet ds = null;

            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                ds = db.ExecuteReader(comando, "EncabezadoFactura");

            }

            return ds;
        }

        public static DataSet SeleccionarTodosTipoPago(DateTime fechaInicial, DateTime fechaFinal)
        {
            SqlCommand comando = new SqlCommand("PA_SeleccionarEncabezadosFacturaTipoPago");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fechaInicial", fechaInicial);
            comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
            DataSet ds = null;

            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                ds = db.ExecuteReader(comando, "EncabezadoFactura");

            }

            return ds;
        }


        public static DataSet SeleccionarTodosXProducto(int idProducto, DateTime fechaInicial, DateTime fechaFinal)
        {
            SqlCommand comando = new SqlCommand("PA_SeleccionarEncabezadosFacturaProducto");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idProducto", idProducto);
            comando.Parameters.AddWithValue("@fechaInicial", fechaInicial);
            comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);
            DataSet ds = null;

            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                ds = db.ExecuteReader(comando, "EncabezadoFactura");

            }

            return ds;
        }


        public static DataSet Insertar(EncabezadoFacturaEntidad encabezado)
        {
           
            SqlCommand comando = new SqlCommand("PA_InsertarEncabezadoFactura");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idEncabezadoPedido", encabezado.encabezadoPedido.idEncabezadoPedido);
            comando.Parameters.AddWithValue("@idRestaurante", encabezado.restaurante.idRestaurante);
            comando.Parameters.AddWithValue("@idUsuario", encabezado.usuario.idUsuario);
            comando.Parameters.AddWithValue("@nombreCliente", encabezado.nombreCliente);
            comando.Parameters.AddWithValue("@fecha", encabezado.fecha);
            comando.Parameters.AddWithValue("@iv", encabezado.IV);
            comando.Parameters.AddWithValue("@subTotal", encabezado.Subtotal);
            comando.Parameters.AddWithValue("@total", encabezado.Total);
            DataSet ds = null;

            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                ds = db.ExecuteReader(comando, "EncabezadoFactura");

            }

            return ds;
        }


        public static void Modificar(EncabezadoFacturaEntidad encabezado)
        {
           
            SqlCommand comando = new SqlCommand("PA_ModificarEncabezadoFactura");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", encabezado.idEncabezadoFactura);
            comando.Parameters.AddWithValue("@idEncabezadoPedido", encabezado.encabezadoPedido.idEncabezadoPedido);
            comando.Parameters.AddWithValue("@idRestaurante", encabezado.restaurante.idRestaurante);
            comando.Parameters.AddWithValue("@idUsuario", encabezado.usuario.idUsuario);
            comando.Parameters.AddWithValue("@nombreCliente", encabezado.nombreCliente);
            comando.Parameters.AddWithValue("@fecha", encabezado.fecha);
            

            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                db.ExecuteNonQuery(comando);

            }
        }
    }
}
