using DatosRestaurante;
using EntidadesRestaurante;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaRestaurante
{
    public class EncabezadoFacturaLN
    {
        public static List<EncabezadoFacturaEntidad> ObtenerTodos()
        {
            /*public int idEncabezadoFactura { get; set; }
            public EncabezadoPedidoEntidad encabezadoPedido { get; set; }
            public RestauranteEntidad restaurante { get; set; }
            public UsuarioEntidad usuario { get; set; }
            public String nombreCliente { get; set; }
            public DateTime fecha { get; set; }
            public List<MontoPorTipoPagoEntidad> listaFormaPago { get; set; }*/

            List<EncabezadoFacturaEntidad> lista = new List<EncabezadoFacturaEntidad>();
            DataSet ds = EncabezadoFacturaDatos.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                EncabezadoFacturaEntidad elemento = new EncabezadoFacturaEntidad();
                elemento.idEncabezadoFactura = Convert.ToInt16(fila["id"].ToString());
                elemento.encabezadoPedido.idEncabezadoPedido = Convert.ToInt16(fila["idEncabezadoPedido"].ToString());
                elemento.restaurante.idRestaurante = Convert.ToInt16(fila["idRestaurante"].ToString());
                elemento.usuario.idUsuario = fila["idUsuario"].ToString();
                elemento.nombreCliente = fila["nombreCliente"].ToString();
                elemento.fecha = Convert.ToDateTime(fila["fecha"].ToString());

                List<MontoPorTipoPagoEntidad> listaPagos = new List<MontoPorTipoPagoEntidad>();

                listaPagos = MontoPorTipoPagoLN.ObtenerTodos(elemento.idEncabezadoFactura);
                elemento.listaFormaPago = listaPagos;

                lista.Add(elemento);
            }



            return lista;
        }


        public static void Nuevo(EncabezadoFacturaEntidad encabezado)
        {

            DataSet ds = EncabezadoFacturaDatos.Insertar(encabezado); ;
            EncabezadoFacturaEntidad elemento = new EncabezadoFacturaEntidad();

            DataRow fila = ds.Tables[0].Rows[0];
            elemento.idEncabezadoFactura = Convert.ToInt16(fila["id"].ToString());
            elemento.encabezadoPedido.idEncabezadoPedido = Convert.ToInt16(fila["idEncabezadoPedido"].ToString());
            elemento.restaurante.idRestaurante = Convert.ToInt16(fila["idRestaurante"].ToString());
            elemento.usuario.idUsuario = fila["idUsuario"].ToString();
            elemento.nombreCliente = fila["nombreCliente"].ToString();
            elemento.fecha = Convert.ToDateTime(fila["fecha"].ToString());

            foreach (MontoPorTipoPagoEntidad item in encabezado.listaFormaPago) {
                item.encabezadoFactura = elemento.idEncabezadoFactura;
                MontoPorTipoPagoLN.Nuevo(item);
            }

        }

        public static void Modificar(EncabezadoFacturaEntidad encabezado)
        {
            EncabezadoFacturaDatos.Modificar(encabezado);
        }
    }
}
