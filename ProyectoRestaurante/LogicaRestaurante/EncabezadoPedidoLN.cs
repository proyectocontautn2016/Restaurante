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
    public class EncabezadoPedidoLN
    {
        public static List<EncabezadoPedidoEntidad> ObtenerTodos()
        {
        /*public int idEncabezadoPedido { get; set; }
        public MesaEntidad mesa { get; set; }
        public UsuarioEntidad usuario { get; set; }
        public EstadoPedidoEntidad estadoPedido { get; set; }
        public List<DetallePedidoEntidad> listaDetalles { get; set; }
        public int estado { get; set; }*/

        List<EncabezadoPedidoEntidad> lista = new List<EncabezadoPedidoEntidad>();
            DataSet ds = EncabezadoPedidoDatos.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                EncabezadoPedidoEntidad elemento = new EncabezadoPedidoEntidad();
                elemento.idEncabezadoPedido = Convert.ToInt16(fila["id"].ToString());
                elemento.mesa.idMesa = Convert.ToInt16(fila["idMesa"].ToString());
                elemento.usuario.idUsuario = fila["idUsuario"].ToString();
                //elemento.estadoPedido.idEstadoPedido = Convert.ToInt16(fila["idEstadoPedido"].ToString());
                //elemento.estadoPedido.descripcion = fila["descripcion"].ToString();

                if(Convert.ToInt16(fila["estado"].ToString()) == 1)
                {
                    elemento.estado = true;
                }else
                {
                    elemento.estado = false;
                }

                if (Convert.ToInt16(fila["facturado"].ToString()) == 1)
                {
                    elemento.facturado = true;
                }
                else
                {
                    elemento.facturado = false;
                }


                List<DetallePedidoEntidad> listaDetalles = new List<DetallePedidoEntidad>();
                listaDetalles = DetallePedidoLN.ObtenerTodos(elemento.idEncabezadoPedido);
                elemento.listaDetalles = listaDetalles;

                lista.Add(elemento);
            }

            return lista;
        }

        public static EncabezadoPedidoEntidad obtenerEncabezadoPedido(int pIdMesa)
        {
            List<EncabezadoPedidoEntidad> listaEncabezadoPedidos = ObtenerTodos();
            EncabezadoPedidoEntidad encabezadoPedido = new EncabezadoPedidoEntidad();
            encabezadoPedido = (listaEncabezadoPedidos.Find(elemento => (elemento.estado == true) && (elemento.mesa.idMesa == pIdMesa) && (elemento.facturado == false)));
            return encabezadoPedido;
        }

        public static EncabezadoPedidoEntidad obtenerEncabezadoPedidoXID(int pIdEncabezado)
        {
            List<EncabezadoPedidoEntidad> listaEncabezadoPedidos = ObtenerTodos();
            EncabezadoPedidoEntidad encabezadoPedido = new EncabezadoPedidoEntidad();
            encabezadoPedido = (listaEncabezadoPedidos.Find(elemento => (elemento.idEncabezadoPedido == pIdEncabezado)));
            return encabezadoPedido;
        }


        public static EncabezadoPedidoEntidad Nuevo(EncabezadoPedidoEntidad encabezado)
        {
            DataSet ds = EncabezadoPedidoDatos.Insertar(encabezado);
            EncabezadoPedidoEntidad elemento = new EncabezadoPedidoEntidad();

            DataRow fila = ds.Tables[0].Rows[0];
            elemento.idEncabezadoPedido = Convert.ToInt16(fila["id"].ToString());
            elemento.mesa.idMesa = Convert.ToInt16(fila["idMesa"].ToString());
            elemento.usuario.idUsuario = fila["idUsuario"].ToString();
            //elemento.estadoPedido.idEstadoPedido = Convert.ToInt16(fila["idEstadoPedido"].ToString());
            //elemento.estadoPedido.descripcion = fila["descripcion"].ToString();

            if (Convert.ToInt16(fila["estado"].ToString()) == 1)
            {
                elemento.estado = true;
            }
            else
            {
                elemento.estado = false;
            }

            if (Convert.ToInt16(fila["facturado"].ToString()) == 1)
            {
                elemento.facturado = true;
            }
            else
            {
                elemento.facturado = false;
            }

            return elemento;
        }

        public static void Modificar(EncabezadoPedidoEntidad encabezado)
        {
            EncabezadoPedidoDatos.Modificar(encabezado);
        }
    }
}
