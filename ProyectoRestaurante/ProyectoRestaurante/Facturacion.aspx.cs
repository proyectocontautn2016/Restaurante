using EntidadesRestaurante;
using LogicaRestaurante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoRestaurante
{
    public partial class Facturacion : System.Web.UI.Page
    {
        private Decimal PORC_IV = 0.13M;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pedido"] != null)
            {
                if (!IsPostBack) {
                    cargarDatos();
                }
            }
            else {
                Response.Redirect("disponibilidadMesas.aspx");
            }
  
        }


        private void cargarDatos() {
            EncabezadoPedidoEntidad pedido = (EncabezadoPedidoEntidad)Session["pedido"];
            Decimal subTotal = 0;
            Decimal iv = 0;
            Decimal total = 0;
            DateTime fecha = DateTime.Today;
            lblFecha.Text = "Fecha: " + fecha.ToString("dd/MM/yyyy");
            cargarPedidoEnDataGridView(pedido);

            foreach (DetallePedidoEntidad item in pedido.listaDetalles) {
                subTotal += item.cantidad * item.producto.precio;
            }

            iv = subTotal * PORC_IV;
            total = iv + subTotal;

            lblIV.Text = "₡" + iv;
            lblSubtotal.Text = "₡" + (subTotal + 0.00M);
            lblTotal.Text = "₡" + total;

            ddlTipoPago.Items.Insert(0, new ListItem("--Seleccionar acción--", "0"));
            ddlTipoPago.Items.Insert(1, new ListItem("Efectivo", "1"));
            ddlTipoPago.Items.Insert(2, new ListItem("Tarjeta", "2"));
            ddlTipoPago.Items.Insert(3, new ListItem("Ejectivo y Tarjeta", "3"));
        }

        private void cargarPedidoEnDataGridView(EncabezadoPedidoEntidad pPedido)
        {
            List<DetallePedidoEntidad> lista = new List<DetallePedidoEntidad>();
            lista = pPedido.listaDetalles;
            grvPedido.DataSource = lista;
            grvPedido.DataBind();
        }

        protected void ddlTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}