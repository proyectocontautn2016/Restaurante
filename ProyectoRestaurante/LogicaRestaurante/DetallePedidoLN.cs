﻿using DatosRestaurante;
using EntidadesRestaurante;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaRestaurante
{
    public class DetallePedidoLN
    {
        public static List<DetallePedidoEntidad> ObtenerTodos(int id)
        {
            /*public int idDetallePedido { get; set; }
            public int idEncabezadoPedido { get; set; }
            public ProductoEntidad producto { get; set; }
            public int cantidad { get; set; }
            public Decimal precio { get; set; }
            public String comentario { get; set; }
            public int estado { get; set; }
            */

            List<DetallePedidoEntidad> lista = new List<DetallePedidoEntidad>();
            DataSet ds = DetallePedidoDatos.SeleccionarTodosporID(id);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                DetallePedidoEntidad elemento = new DetallePedidoEntidad();
                elemento.idDetallePedido = Convert.ToInt16(fila["id"].ToString());
                elemento.idEncabezadoPedido = Convert.ToInt16(fila["idEncabezadoPedido"].ToString());
                elemento.producto.idProducto = Convert.ToInt16(fila["idProducto"].ToString());
                elemento.producto.nombre = fila["nombre"].ToString();
                elemento.producto.imagen = fila["imagen"].ToString();
                elemento.cantidad = Convert.ToInt16(fila["cantidad"].ToString());
                elemento.precio = Convert.ToDecimal(fila["precio"].ToString());
                elemento.producto.precio = Convert.ToDecimal(fila["precioProducto"].ToString());
                elemento.comentario = fila["comentario"].ToString();

                if(Convert.ToInt16(fila["estado"].ToString()) == 1)
                {
                    elemento.estado = true;
                }else
                {
                    elemento.estado = false;
                }

                if (Convert.ToInt16(fila["estadoProducto"].ToString()) == 1)
                {
                    elemento.producto.estado = true;
                }
                else
                {
                    elemento.producto.estado = false;
                }


                lista.Add(elemento);
            }

            return lista;
        }

        public static DetallePedidoEntidad ObtenerDetalle(int pIdDetalle, int pIDEncabezado)
        {
            List<DetallePedidoEntidad> listaDetalles = DetallePedidoLN.ObtenerTodos(pIDEncabezado);
            DetallePedidoEntidad detalle;
            detalle = listaDetalles.Find(elemento => (elemento.idDetallePedido == pIdDetalle));
            return detalle;
        }


        public static void Nuevo(DetallePedidoEntidad detalle)
        {
            DetallePedidoDatos.Insertar(detalle);
        }

        public static void Modificar(DetallePedidoEntidad detalle)
        {
            DetallePedidoDatos.Modificar(detalle);
        }
    }
}
