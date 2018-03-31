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
    public partial class FactImprimir : System.Web.UI.Page
    {
        private Decimal PORC_IV = 0.13M;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["factura"] != null)
            {
                if (!IsPostBack)
                {
                    cargarDatos();
                }
            }
            else
            {
                Response.Redirect("disponibilidadMesas.aspx");
            }


           
        }


        private void cargarDatos()
        {
            EncabezadoFacturaEntidad factu = (EncabezadoFacturaEntidad)Session["factura"];
            EncabezadoPedidoEntidad pedido = EncabezadoPedidoLN.obtenerEncabezadoPedidoXID(factu.encabezadoPedido.idEncabezadoPedido);
            Decimal subTotal = 0;
            Decimal iv = 0;
            Decimal total = 0;
            //DateTime fecha = DateTime.Today;
            //lblFecha.Text = "Fecha: " + fecha.ToString("dd/MM/yyyy");
            cargarPedidoEnDataGridView(pedido);

            foreach (DetallePedidoEntidad item in pedido.listaDetalles)
            {
                subTotal += item.cantidad * item.producto.precio;
            }

            iv = subTotal * PORC_IV;
            total = iv + subTotal;

            lblIV.Text = "₡" + iv;
            lblSubtotal.Text = "₡" + (subTotal + 0.00M);
            lblTotal.Text = "₡" + total;
            lblFecha.Text = factu.fecha.ToString("dd/MM/yyyy");
            this.imgLogo.ImageUrl = "img/infoRestaurante/FactDALEX.jpg";
            this.lblNombre.Text = factu.nombreCliente;


        }


        private void cargarPedidoEnDataGridView(EncabezadoPedidoEntidad pPedido)
        {
            List<DetallePedidoEntidad> lista = new List<DetallePedidoEntidad>();
            lista = pPedido.listaDetalles;
            grvPedido.DataSource = lista;
            grvPedido.DataBind();
        }



        protected void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        protected void btnCorreo_Click(object sender, EventArgs e)
        {

        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {

        }
    }
}