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
    public partial class ReporteProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ddlTipo.DataSource = TipoProductoLN.ObtenerTodos();
                this.ddlTipo.DataTextField = "descripcion";
                this.ddlTipo.DataValueField = "idTipoProducto";
                this.ddlTipo.DataBind();
                this.imgLogo.ImageUrl = "img/infoRestaurante/FactDALEX.jpg";
                DateTime fecha = DateTime.Today;
                this.lblFecha.Text = fecha.ToString("dd/MM/yyyy");
                seleccionarProducto(1);
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int tipo = Convert.ToInt16(this.ddlTipo.SelectedValue);
            seleccionarProducto(tipo);
           
        }

        private void seleccionarProducto(int TipoProducto)
        {
            List<ProductoEntidad> productos = new List<ProductoEntidad>();

            productos = ProductoLN.ObtenerProductoTipo(TipoProducto);

            grvListado.DataSource = productos;
            grvListado.DataBind();
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }
    }
}