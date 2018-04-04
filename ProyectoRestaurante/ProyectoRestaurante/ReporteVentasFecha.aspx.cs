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
    public partial class ReporteVentasFecha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime fecha = DateTime.Today;
                this.txtFechaFinal.Text = fecha.ToString("dd/MM/yyyy");
                this.txtFechaInicial.Text = fecha.ToString("dd/MM/yyyy");
                this.lblFecha.Text = fecha.ToString("dd/MM/yyyy");
                this.imgLogo.ImageUrl = "img/infoRestaurante/FactDALEX.jpg";
                UsuarioEntidad usuario = (UsuarioEntidad)Session["usuario"];
                llenarGrid(Convert.ToDateTime(this.txtFechaInicial.Text), Convert.ToDateTime(this.txtFechaFinal.Text));
            }
        }

        private void llenarGrid(DateTime fecha1, DateTime fecha2)
        {
            List<EncabezadoFacturaEntidad> lista = new List<EncabezadoFacturaEntidad>();
            lista = EncabezadoFacturaLN.ObtenerTodos(fecha1, fecha2);
            grvListado.DataSource = lista;
            grvListado.DataBind();

            Decimal IVA = 0;
            Decimal Sub = 0;
            Decimal tot = 0;
            foreach (EncabezadoFacturaEntidad item in lista)
            {
                IVA += item.IV;
                Sub += item.Subtotal;
                tot += item.Total;
            }

            this.lblIV.Text = "₡" + (IVA + 0.00M);
            this.lblSubtotal.Text = "₡" + (Sub + 0.00M);
            this.lblTotal.Text = "₡" + (tot + 0.00M);
        }

        protected void txtBusqueda_Click(object sender, EventArgs e)
        {
            llenarGrid(Convert.ToDateTime(this.txtFechaInicial.Text), Convert.ToDateTime(this.txtFechaFinal.Text));
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }
    }
}