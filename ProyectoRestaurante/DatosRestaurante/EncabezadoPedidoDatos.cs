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
    public class EncabezadoPedidoDatos
    {
        public static DataSet SeleccionarTodos()
        {
            SqlCommand comando = new SqlCommand("PA_SeleccionarEncabezadosPedido");
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = null;

            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                ds = db.ExecuteReader(comando, "EncabezadoPedido");

            }
            return ds;
        }

        public static DataSet Insertar(EncabezadoPedidoEntidad encabezado)
        {
            SqlCommand comando = new SqlCommand("PA_InsertarEncabezadoPedido");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idMesa", encabezado.mesa.idMesa);
            comando.Parameters.AddWithValue("@idUsuario", encabezado.usuario.idUsuario);
            //comando.Parameters.AddWithValue("@idEstadoPedido", encabezado.estadoPedido.idEstadoPedido);
            int estado = 0;
            if (encabezado.estado == true)
            {
                estado = 1;
            }

            int facturado = 0;
            if (encabezado.facturado == true)
            {
                facturado = 1;
            }
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@facturado", facturado);
            DataSet ds = null;

            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                ds = db.ExecuteReader(comando, "EncabezadoPedido");

            }
            return ds;
        }


        public static void Modificar(EncabezadoPedidoEntidad encabezado)
        {
            SqlCommand comando = new SqlCommand("PA_ModificarEncabezadoPedido");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", encabezado.idEncabezadoPedido);
            comando.Parameters.AddWithValue("@idMesa", encabezado.mesa.idMesa);
            comando.Parameters.AddWithValue("@idUsuario", encabezado.usuario.idUsuario);
            //comando.Parameters.AddWithValue("@idEstadoPedido", encabezado.estadoPedido.idEstadoPedido);
            int estado = 0;
            if (encabezado.estado == true)
            {
                estado = 1;
            }

            int facturado = 0;
            if (encabezado.facturado == true)
            {
                facturado = 1;
            }

            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@facturado", facturado);

            using (Database db = DatabaseFactory.CreateDatabase("Default"))
            {
                db.ExecuteNonQuery(comando);
            } 
        }
    }
}
