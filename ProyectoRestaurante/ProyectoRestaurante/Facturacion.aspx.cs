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

            habilitarCamposTiposPagos();
        }

        private void cargarPedidoEnDataGridView(EncabezadoPedidoEntidad pPedido)
        {
            List<DetallePedidoEntidad> lista = new List<DetallePedidoEntidad>();
            lista = pPedido.listaDetalles;
            grvPedido.DataSource = lista;
            grvPedido.DataBind();            
        }

        private void habilitarCamposTiposPagos() {
            int tipoPago = Convert.ToInt16(ddlTipoPago.SelectedValue);

            lblPagoTarjeta.Visible = false;
            lblNumeroTarjeta.Visible = false;
            txtNumeroTarjeta.Visible = false;
            txtNumeroTarjeta.Enabled = false;
            lblFechaVencimiento.Visible = false;
            lblMesVencimiento.Visible = false;
            txtMesVencimiento.Visible = false;
            txtMesVencimiento.Enabled = false;
            lblAnno.Visible = false;
            txtAnno.Visible = false;
            txtAnno.Enabled = false;
            lblCantidadPagadaTarjeta.Visible = false;
            txtCantidadPagadaTarjeta.Visible = false;
            txtCantidadPagadaTarjeta.Enabled = false;
            lblEfectivo.Visible = false;
            lblCantidadPagadaEfectivo.Visible = false;
            txtCantidadPagadaEfectivo.Visible = false;
            txtCantidadPagadaEfectivo.Enabled = false;
            btnFacturar.Visible = false;
            btnFacturar.Enabled = false;

            if (tipoPago == 2) {
                lblPagoTarjeta.Visible = true;
                lblNumeroTarjeta.Visible = true;
                txtNumeroTarjeta.Visible = true;
                txtNumeroTarjeta.Enabled = true;
                lblFechaVencimiento.Visible = true;
                lblMesVencimiento.Visible = true;
                txtMesVencimiento.Visible = true;
                txtMesVencimiento.Enabled = true;
                lblAnno.Visible = true;
                txtAnno.Visible = true;
                txtAnno.Enabled = true;
                lblCantidadPagadaTarjeta.Visible = true;
                txtCantidadPagadaTarjeta.Visible = true;
                txtCantidadPagadaTarjeta.Enabled = true;

                btnFacturar.Visible = true;
                btnFacturar.Enabled = true;
            }

            if (tipoPago == 1) {
                lblEfectivo.Visible = true;
                lblCantidadPagadaEfectivo.Visible = true;
                txtCantidadPagadaEfectivo.Visible = true;
                txtCantidadPagadaEfectivo.Enabled = true;

                btnFacturar.Visible = true;
                btnFacturar.Enabled = true;
            }

            if (tipoPago == 3) {
                lblPagoTarjeta.Visible = true;
                lblNumeroTarjeta.Visible = true;
                txtNumeroTarjeta.Visible = true;
                txtNumeroTarjeta.Enabled = true;
                lblFechaVencimiento.Visible = true;
                lblMesVencimiento.Visible = true;
                txtMesVencimiento.Visible = true;
                txtMesVencimiento.Enabled = true;
                lblAnno.Visible = true;
                txtAnno.Visible = true;
                txtAnno.Enabled = true;
                lblCantidadPagadaTarjeta.Visible = true;
                txtCantidadPagadaTarjeta.Visible = true;
                txtCantidadPagadaTarjeta.Enabled = true;

                lblEfectivo.Visible = true;
                lblCantidadPagadaEfectivo.Visible = true;
                txtCantidadPagadaEfectivo.Visible = true;
                txtCantidadPagadaEfectivo.Enabled = true;

                btnFacturar.Visible = true;
                btnFacturar.Enabled = true;
            }
        }

        protected void ddlTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            habilitarCamposTiposPagos();
        }

        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            EncabezadoPedidoEntidad pedido = (EncabezadoPedidoEntidad)Session["pedido"];


            Decimal subTotal = 0;
            Decimal iv = 0;
            Decimal total = 0;
            foreach (DetallePedidoEntidad item in pedido.listaDetalles)
            {
                subTotal += item.cantidad * item.producto.precio;
            }
            iv = subTotal * PORC_IV;
            total = iv + subTotal;


            int tipoPago = Convert.ToInt16(ddlTipoPago.SelectedValue);
            UsuarioEntidad usuario = (UsuarioEntidad)Session["usuario"];
            EncabezadoFacturaEntidad factura = new EncabezadoFacturaEntidad();
            factura.encabezadoPedido = pedido;
            factura.restaurante.idRestaurante = 1;
            factura.usuario = usuario;
            factura.nombreCliente = this.txtNombreCliente.Text;
            factura.fecha = DateTime.Today;

            List<MontoPorTipoPagoEntidad> listaFormaPago = new List<MontoPorTipoPagoEntidad>();

            if (tipoPago == 1)
            {
                MontoPorTipoPagoEntidad montoPorTipoPagoEfectivo = new MontoPorTipoPagoEntidad();
                montoPorTipoPagoEfectivo.monto = Convert.ToDecimal(txtCantidadPagadaEfectivo.Text);
                montoPorTipoPagoEfectivo.TipoPago.idTipoPago = 1;

                listaFormaPago.Add(montoPorTipoPagoEfectivo);
            }
            else if (tipoPago == 2)
            {
                MontoPorTipoPagoEntidad montoPorTipoPagoTarjeta = new MontoPorTipoPagoEntidad();
                montoPorTipoPagoTarjeta.monto = Convert.ToDecimal(txtCantidadPagadaTarjeta.Text);
                montoPorTipoPagoTarjeta.TipoPago.idTipoPago = 2;

                listaFormaPago.Add(montoPorTipoPagoTarjeta);
            }
            else {
                MontoPorTipoPagoEntidad montoPorTipoPagoEfectivo = new MontoPorTipoPagoEntidad();
                montoPorTipoPagoEfectivo.monto = Convert.ToDecimal(txtCantidadPagadaEfectivo.Text);
                montoPorTipoPagoEfectivo.TipoPago.idTipoPago = 1;
                listaFormaPago.Add(montoPorTipoPagoEfectivo);

                MontoPorTipoPagoEntidad montoPorTipoPagoTarjeta = new MontoPorTipoPagoEntidad();
                montoPorTipoPagoTarjeta.monto = Convert.ToDecimal(txtCantidadPagadaTarjeta.Text);
                montoPorTipoPagoTarjeta.TipoPago.idTipoPago = 2;

                listaFormaPago.Add(montoPorTipoPagoTarjeta);
            }

            factura.listaFormaPago = listaFormaPago;
            factura.IV = iv;
            factura.Subtotal = subTotal;
            factura.Total = total;

            EncabezadoFacturaLN.Nuevo(factura);

            actualizarEstadoMesa(1, pedido.mesa.idMesa);
            Response.Redirect("disponibilidadMesas.aspx");
        }

        private void actualizarEstadoMesa(int pNuevoEstadoMesa, int pIdMesa)
        {
            MesaEntidad mesa = MesaLN.ObtenerMesa(pIdMesa);
            mesa.estadoMesa.estadoMesa = pNuevoEstadoMesa;
            MesaLN.Modificar(mesa);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("disponibilidadMesas.aspx");
        }
    }
}