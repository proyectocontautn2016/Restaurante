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
            if (Session["pedido"] == null)
            {
                Response.Redirect("disponibilidadMesas.aspx");
            }
            cargarCampos();
        }

        private void cargarCampos() {
            try
            {
                int pIdProducto = Convert.ToInt16(Request.QueryString["idProducto"].ToString());

                if (pIdProducto >= 1)
                {
                    ProductoEntidad producto = ProductoLN.ObtenerProducto(pIdProducto);
                    idNombreProducto.InnerText = producto.nombre;
                    imgImagenProducto.ImageUrl = "img/productos/" + producto.imagen;
                    lblPrecioProducto.Text = "Precio: ₡" + producto.precio;
                    hdfIdProducto.Value = pIdProducto.ToString();
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
                EncabezadoPedidoEntidad pedido = (EncabezadoPedidoEntidad)Session["pedido"];
                DetallePedidoEntidad detallePedido = new DetallePedidoEntidad();
                detallePedido.idEncabezadoPedido = pedido.idEncabezadoPedido;
                detallePedido.producto = producto;
                detallePedido.cantidad = Convert.ToInt16(txtCantidad.Text);
                detallePedido.comentario = txtComentario.Text;
                detallePedido.precio = detallePedido.cantidad * producto.precio;
                detallePedido.estado = true;

                DetallePedidoLN.Nuevo(detallePedido);
                Session.Remove("pedido");

                Response.Redirect("accionMesa.aspx?idMesa=" + pedido.mesa.idMesa);
            }
            else {
                this.lblMensaje.Text = "La cantidad debe ser mayor a 0 y menor o igual a 10";
            }
        }


        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ((Convert.ToInt16(args.Value) >= 1) && (Convert.ToInt16(args.Value) <= 10));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            int idMesa = ((EncabezadoPedidoEntidad)Session["pedido"]).mesa.idMesa;
            Response.Redirect("accionMesa.aspx?idMesa=" + idMesa);
        }
    }
}