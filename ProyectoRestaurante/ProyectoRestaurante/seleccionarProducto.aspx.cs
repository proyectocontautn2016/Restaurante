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
    public partial class seleccionarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarCampos();
        }

        private void cargarCampos() {
            try
            {
                int pIdProducto = Convert.ToInt16(Request.QueryString["idProducto"].ToString());
                int pIdMesa = Convert.ToInt16(Request.QueryString["idMesa"].ToString());
                if (pIdProducto >= 1)
                {
                    ProductoEntidad producto = ProductoLN.ObtenerProducto(pIdProducto);
                    idNombreProducto.InnerText = producto.nombre;
                    imgImagenProducto.ImageUrl = "img/productos/" + producto.imagen;
                    lblPrecioProducto.Text = "Precio: ₡" + producto.precio;
                    hdfIdProducto.Value = pIdProducto.ToString();
                    hdfIdMesa.Value = pIdMesa.ToString();
                }
            }
            catch (Exception)
            {
                Response.Redirect("disponibilidadMesas.aspx");
            }
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(this.txtCantidad.Text) >= 1 && Convert.ToInt16(this.txtCantidad.Text) <= 10)
            {
                ProductoEntidad producto = ProductoLN.ObtenerProducto(Convert.ToInt16(hdfIdProducto.Value));
                EncabezadoPedidoEntidad pedido = new EncabezadoPedidoEntidad();
                DetallePedidoEntidad detallePedido = new DetallePedidoEntidad();
                detallePedido.producto = producto;
                detallePedido.cantidad = Convert.ToInt16(txtCantidad.Text);
                detallePedido.comentario = txtComentario.Text;



                if (Session["pedido"] != null)
                {
                    pedido = (EncabezadoPedidoEntidad)Session["pedido"];
                    Session.Remove("pedido");
                }

                pedido.listaDetalles.Add(detallePedido);
                Session.Add("pedido", pedido);
                Response.Redirect("AgregarComanda.aspx?idMesa=" + hdfIdMesa.Value);
            }
            else {
                this.lblMensaje.Text = "La cantidad debe ser mayor a 0 y menor o igual a 10";
            }
        }


        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ((Convert.ToInt16(args.Value) >= 1) && (Convert.ToInt16(args.Value) <= 10));
        }
    }
}