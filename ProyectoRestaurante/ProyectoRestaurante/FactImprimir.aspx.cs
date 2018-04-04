using EntidadesRestaurante;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using LogicaRestaurante;
using System;
using System.Collections.Generic;
using System.IO;
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
            this.lblIdFactura.Text = factu.idEncabezadoFactura.ToString();


        }

        private String facturaHTML()
        {
            String HTML = "";
            EncabezadoFacturaEntidad factu = (EncabezadoFacturaEntidad)Session["factura"];
            EncabezadoPedidoEntidad pedido = EncabezadoPedidoLN.obtenerEncabezadoPedidoXID(factu.encabezadoPedido.idEncabezadoPedido);
            HTML += "<style>table{font - family: arial, sans - serif;border - collapse: collapse;width: 100 %;}th{border: 1px solid black;text - align: center;";
            HTML += "padding: 8px;background - color: black;color: white;}td {border: 1px solid black;text - align: center;padding: 8px;}tr: nth - child(even) {";
            HTML += "background - color: #BDBDBD;}</ style >< center >< h1 > Factura </ h1 ></ center >< div style = 'width:49%; height:190px; float:left; margin-left:1%' >";
            HTML += "< img src = 'C:/Users/Alex/Documents/ProyectoFinalASPX/Restaurante/Restaurante/ProyectoRestaurante/ProyectoRestaurante/img/infoRestaurante/FactDALEX.jpg' alt = ''";
            HTML += "style = 'width:150px; height:150px; margin-top:20px; display: block;margin - left: auto;margin - right: auto;'></ div >< div style = 'width:49%; height:160px;float:left; padding-top:30px'>";
            HTML += "<span style='font-size:18px; font-weight:bold ; margin-left:5%'>Restaurante DALEX </ span ><br/><br/><span style = 'font-size:18px; font-weight:bold; margin-left:5%'> Fecha:&nbsp; &nbsp; ";
            HTML += factu.fecha.ToString("dd/MM/yyyy");
            HTML += "</span><br/><br/><span style = 'font-size:18px; font-weight:bold ; margin-left:5%'> Numero Factura: &nbsp; &nbsp;";
            HTML += factu.idEncabezadoFactura;
            HTML += "</span></div><br><br><div style = 'width:49%; height:50px; float:left; margin-left:1%; padding-top:10px'><span style = 'font-size:18px; font-weight:bold ; margin-left:50%'>Nombre:</ span ></ div >";
            HTML += "<div style = 'width:49%; height:50px;float:left; padding-top:10px'><label style = 'font-size:18px; font-weight:bold'>";
            HTML += factu.nombreCliente;
            HTML += "</label></div><div style = 'width:90%; height:250px; float:left; margin-left:5%; padding-top:10px'>< table ><tr><th>Producto</th><th>Cantidad</th><th>Precio</th></tr>";

            foreach (DetallePedidoEntidad item in pedido.listaDetalles)
            {
                HTML += "<tr><td>";
                HTML += item.producto.nombre + "</td>";
                HTML += "<td>";
                HTML += item.cantidad + "</td>";
                HTML += "<td>";
                HTML += item.precio + "</td>";
                HTML += "</td></tr>";
            }

           

            Decimal subTotal = 0;
            Decimal iv = 0;
            Decimal total = 0;
            foreach (DetallePedidoEntidad item in pedido.listaDetalles)
            {
                subTotal += item.cantidad * item.producto.precio;
            }

            iv = subTotal * PORC_IV;
            total = iv + subTotal;

            HTML += "<tr><td colspan = '2' ><b>Impuesto Venta</b></td><td><b>";
            HTML += iv;
            HTML += "</b></td></tr><tr><td colspan = '2' ><b>Subtotal</b></td><td><b>";
            HTML += subTotal;
            HTML += "</b></td></tr><tr><td colspan = '2'><b>Total</b></td><td><b>";
            HTML += total;
            HTML += "</b></td></tr></table></div>";


            return HTML;
        }


        private void cargarPedidoEnDataGridView(EncabezadoPedidoEntidad pPedido)
        {
            List<DetallePedidoEntidad> lista = new List<DetallePedidoEntidad>();
            lista = pPedido.listaDetalles;
            grvPedido.DataSource = lista;
            grvPedido.DataBind();
        }


        public class ReturnValue
        {
            // constructor  
            public ReturnValue()
            {
                this.Success = false;
                this.Message = string.Empty;
            }

            // properties  
            public bool Success = false;
            public string Message = string.Empty;
            public Byte[] Data = null;
        }

       

        protected void btnCorreo_Click(object sender, EventArgs e)
        {

        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoMesas.aspx");
        }
    }
}