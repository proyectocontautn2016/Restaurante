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
        public static List<EncabezadoFacturaEntidad> ObtenerTodos(DateTime fecha1, DateTime fecha2)
        {
            /*public int idEncabezadoFactura { get; set; }
            public EncabezadoPedidoEntidad encabezadoPedido { get; set; }
            public RestauranteEntidad restaurante { get; set; }
            public UsuarioEntidad usuario { get; set; }
            public String nombreCliente { get; set; }
            public DateTime fecha { get; set; }
            public List<MontoPorTipoPagoEntidad> listaFormaPago { get; set; }
            public Decimal IV { get; set; }
            public Decimal Subtotal { get; set; }
            public Decimal Total { get; set; }*/

            List<EncabezadoFacturaEntidad> lista = new List<EncabezadoFacturaEntidad>();
            DataSet ds = EncabezadoFacturaDatos.SeleccionarTodos(fecha1, fecha2);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                EncabezadoFacturaEntidad elemento = new EncabezadoFacturaEntidad();
                elemento.idEncabezadoFactura = Convert.ToInt16(fila["id"].ToString());
                elemento.encabezadoPedido.idEncabezadoPedido = Convert.ToInt16(fila["idEncabezadoPedido"].ToString());
                elemento.encabezadoPedido.mesa.idMesa = Convert.ToInt16(fila["idMesa"].ToString());
                elemento.restaurante.idRestaurante = Convert.ToInt16(fila["idRestaurante"].ToString());
                elemento.usuario.idUsuario = fila["idUsuario"].ToString();
                elemento.fecha = Convert.ToDateTime(fila["fecha"].ToString());
                elemento.IV = Convert.ToDecimal(fila["iv"].ToString());
                elemento.Subtotal = Convert.ToDecimal(fila["subTotal"].ToString());
                elemento.Total = Convert.ToDecimal(fila["total"].ToString());

                List<MontoPorTipoPagoEntidad> listaPagos = new List<MontoPorTipoPagoEntidad>();

                listaPagos = MontoPorTipoPagoLN.ObtenerTodos(elemento.idEncabezadoFactura);
                elemento.listaFormaPago = listaPagos;

                lista.Add(elemento);
            }



            return lista;
        }


        public static List<EncabezadoFacturaEntidad> ObtenerTodosxProducto(DateTime fecha1, DateTime fecha2, int vIdProduct)
        {
            List<EncabezadoFacturaEntidad> lista = new List<EncabezadoFacturaEntidad>();
            DataSet ds = EncabezadoFacturaDatos.SeleccionarTodosXProducto(vIdProduct, fecha1, fecha2);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                EncabezadoFacturaEntidad elemento = new EncabezadoFacturaEntidad();
                elemento.idEncabezadoFactura = Convert.ToInt16(fila["id"].ToString());
                elemento.encabezadoPedido.idEncabezadoPedido = Convert.ToInt16(fila["idEncabezadoPedido"].ToString());
                elemento.encabezadoPedido.mesa.idMesa = Convert.ToInt16(fila["idMesa"].ToString());
                elemento.restaurante.idRestaurante = Convert.ToInt16(fila["idRestaurante"].ToString());
                elemento.usuario.idUsuario = fila["idUsuario"].ToString();
                elemento.fecha = Convert.ToDateTime(fila["fecha"].ToString());
                elemento.IV = Convert.ToDecimal(fila["iv"].ToString());
                elemento.Subtotal = Convert.ToDecimal(fila["subTotal"].ToString());
                elemento.Total = Convert.ToDecimal(fila["total"].ToString());

                List<MontoPorTipoPagoEntidad> listaPagos = new List<MontoPorTipoPagoEntidad>();

                listaPagos = MontoPorTipoPagoLN.ObtenerTodos(elemento.idEncabezadoFactura);
                elemento.listaFormaPago = listaPagos;

                lista.Add(elemento);
            }



            return lista;
        }


        public static List<EncabezadoFacturaEntidad> ObtenerTodosUsuario(DateTime fecha1, DateTime fecha2, String vidUsuario)
        {
           List<EncabezadoFacturaEntidad> lista = EncabezadoFacturaLN.ObtenerTodos(fecha1, fecha2);

            List<EncabezadoFacturaEntidad> listaFacturas;
            listaFacturas = lista.Where(elemento => elemento.usuario.idUsuario == vidUsuario).ToList();

            return listaFacturas;
        }

        public static List<EncabezadoFacturaEntidad> ObtenerTodosMesa(DateTime fecha1, DateTime fecha2, int vidMesa)
        {
            List<EncabezadoFacturaEntidad> lista = EncabezadoFacturaLN.ObtenerTodos(fecha1, fecha2);

            List<EncabezadoFacturaEntidad> listaFacturas;
            listaFacturas = lista.Where(elemento => elemento.encabezadoPedido.mesa.idMesa == vidMesa).ToList();

            return listaFacturas;
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
