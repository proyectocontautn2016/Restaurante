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
    public class MontoPorTipoPagoDatos
    {
        public static DataSet SeleccionarTodos(int id)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");
            SqlCommand comando = new SqlCommand("[PA_SeleccionarEncabezadoFacturaTipoPago]");
            comando.Parameters.AddWithValue("@idEncabezadoFactura", id);
            comando.CommandType = CommandType.StoredProcedure;
            DataSet ds = db.ExecuteReader(comando, "EncabezadoFacturaTipoPago");
            return ds;

        }

        public static void Insertar(MontoPorTipoPagoEntidad pMontoPorTipoPagoDatos)
        {
            Database db = DatabaseFactory.CreateDatabase("Default");

            SqlCommand comando = new SqlCommand("PA_InsertarEncabezadoFacturaTipoPago");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idEncabezadoFactura", pMontoPorTipoPagoDatos.encabezadoFactura);
            comando.Parameters.AddWithValue("@idTipoPago", pMontoPorTipoPagoDatos.TipoPago.idTipoPago);
            comando.Parameters.AddWithValue("@monto", pMontoPorTipoPagoDatos.monto);
            db.ExecuteNonQuery(comando);

        }
    }
}
