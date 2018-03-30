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
    public partial class EditarPedido : System.Web.UI.Page
    {
        static decimal valor;
        static int encabezado;
        static int deta;
        static int idProduc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DetallePedidoEntidad detalle = new DetallePedidoEntidad();
                int idDetalle = Convert.ToInt16(Request.QueryString["idDetallePedido"].ToString());
                deta = idDetalle;
                int idEncabezado = Convert.ToInt16(Request.QueryString["idEncabezadoPedido"].ToString());
                encabezado = idEncabezado;
                detalle = DetallePedidoLN.ObtenerDetalle(idDetalle, idEncabezado);
                this.txtNombreProducto.Text = detalle.producto.nombre;
                idProduc = detalle.producto.idProducto;
                this.txtComentario.Text = detalle.comentario;
                this.txtCantidad.Text = detalle.cantidad.ToString();
                this.imagenProducto.ImageUrl = "img/productos/" + detalle.producto.imagen;
                this.txtPrecio.Text = (detalle.producto.precio * detalle.cantidad).ToString();
                valor = detalle.producto.precio;

                ListItemCollection items = new ListItemCollection
                {
                    new ListItem("Desactivo", "0"),
                    new ListItem("Activo", "1"),

                };
                this.ddlEstado.DataSource = items;
                this.ddlEstado.DataBind();
                int vEstado = 0;
                if (detalle.estado == true)
                {
                    vEstado = 1;
                }
                this.ddlEstado.SelectedIndex = vEstado;

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            DetallePedidoEntidad detalle = new DetallePedidoEntidad();
            detalle.idEncabezadoPedido = encabezado;
            detalle.idDetallePedido = deta;
            Boolean esta = false;
            if (this.ddlEstado.SelectedIndex == 1)
            {
                esta = true;
            }
            detalle.estado = esta;
            detalle.cantidad = Convert.ToInt16(this.txtCantidad.Text);
            detalle.comentario = this.txtComentario.Text;
            detalle.precio = Convert.ToDecimal(this.txtPrecio.Text);
            detalle.producto.idProducto = idProduc;

            DetallePedidoLN.Modificar(detalle);

            EncabezadoPedidoEntidad enca = new EncabezadoPedidoEntidad();
            enca = EncabezadoPedidoLN.obtenerEncabezadoPedidoXID(encabezado);
            Response.Redirect("accionMesa.aspx?idMesa=" + enca.mesa.idMesa);

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            EncabezadoPedidoEntidad enca = new EncabezadoPedidoEntidad();
            enca = EncabezadoPedidoLN.obtenerEncabezadoPedidoXID(encabezado);
            Response.Redirect("accionMesa.aspx?idMesa=" + enca.mesa.idMesa);
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            int canti = Convert.ToInt16(this.txtCantidad.Text);
            this.txtPrecio.Text = (canti * valor).ToString();   
        }
    }
}