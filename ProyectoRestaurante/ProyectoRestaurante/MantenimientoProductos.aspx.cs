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
    public partial class MantenimientoProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItemCollection items = new ListItemCollection
                {
                    new ListItem("Desactivo", "0"),
                    new ListItem("Activo", "1")

                };
                this.ddlEstado.DataSource = items;
                this.ddlEstado.DataBind();
                this.ddlEstado.SelectedIndex = 1;

                this.ddlTipo.DataSource = TipoProductoLN.ObtenerTodos();
                this.ddlTipo.DataTextField = "descripcion";
                this.ddlTipo.DataValueField = "idTipoProducto";
                this.ddlTipo.DataBind();

                refrescarListar();


            }
        }

        private void refrescarListar()
        {
            List<ProductoEntidad> lista = new List<ProductoEntidad>();
            lista = ProductoLN.ObtenerTodos();
            grvListado.DataSource = lista;
            grvListado.DataBind();
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ProductoEntidad> lista = new List<ProductoEntidad>();
            int estado = (this.ddlEstado.SelectedIndex);
            Boolean vEstado = false;
            if(estado == 1)
            {
                vEstado = true;
            }
            lista = ProductoLN.ObtenerProductoEstado(vEstado);
            grvListado.DataSource = lista;
            grvListado.DataBind();
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ProductoEntidad> lista = new List<ProductoEntidad>();
            int tipo = Convert.ToInt16(this.ddlTipo.SelectedValue);
            lista = ProductoLN.ObtenerProductoTipo(tipo);
            grvListado.DataSource = lista;
            grvListado.DataBind();
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            refrescarListar();
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProducto.aspx");
        }

        protected void grvListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ProductoEntidad producto = new ProductoEntidad();
            int num = Convert.ToInt32(e.CommandArgument);

            producto.idProducto = Convert.ToInt16(grvListado.DataKeys[num].Values[0]);


            Response.Redirect("EditarProducto.aspx?idProducto=" + producto.idProducto);
        }
    }
}