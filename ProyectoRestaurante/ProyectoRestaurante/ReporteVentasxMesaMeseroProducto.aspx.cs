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
    public partial class ReporteVentasxMesaMeseroProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItemCollection items = new ListItemCollection
                {
                    new ListItem("Mesa", "0"),
                    new ListItem("Mesero", "1"),
                    new ListItem("Producto", "2")

                };
                this.ddlOpcion.DataSource = items;
                this.ddlOpcion.DataBind();
                this.ddlOpcion.SelectedIndex = 1;
                llenarCombo();

                DateTime fecha = DateTime.Today;
                this.txtFechaFinal.Text = fecha.ToString("dd/MM/yyyy");
                this.txtFechaInicial.Text = fecha.ToString("dd/MM/yyyy");
                this.lblFecha.Text = fecha.ToString("dd/MM/yyyy");
                this.imgLogo.ImageUrl = "img/infoRestaurante/FactDALEX.jpg";
                //llenarGrid(Convert.ToDateTime(this.txtFechaInicial.Text), Convert.ToDateTime(this.txtFechaFinal.Text), this.ddlUsuario.SelectedValue);
            }
        }

        private void llenarGridMesa(DateTime fecha1, DateTime fecha2, int VidMesa)
        {
            List<EncabezadoFacturaEntidad> lista = new List<EncabezadoFacturaEntidad>();
            lista = EncabezadoFacturaLN.ObtenerTodosMesa(fecha1, fecha2, VidMesa);
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

        private void llenarGridMesero(DateTime fecha1, DateTime fecha2, String VidUsuario)
        {
            List<EncabezadoFacturaEntidad> lista = new List<EncabezadoFacturaEntidad>();
            lista = EncabezadoFacturaLN.ObtenerTodosUsuario(fecha1, fecha2, VidUsuario);
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

        private void llenarGridProducto(DateTime fecha1, DateTime fecha2, int VidProducto)
        {
            List<EncabezadoFacturaEntidad> lista = new List<EncabezadoFacturaEntidad>();
            lista = EncabezadoFacturaLN.ObtenerTodosxProducto(fecha1, fecha2, VidProducto);
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

        protected void llenarCombo()
        {
            int opcion = this.ddlOpcion.SelectedIndex;

            if (opcion == 0)
            {
                List<MesaEntidad> lista = MesaLN.ObtenerTodos();
                this.ddlBusqueda.DataSource = lista;
                this.ddlBusqueda.DataTextField = "idMesa";
                this.ddlBusqueda.DataValueField = "idMesa";
                this.ddlBusqueda.DataBind();
                this.ddlBusqueda.SelectedIndex = 0;
                this.lblBusqueda.Text = "Mesa";
            }
            else
            {
                if (opcion == 1)
                {
                    List<UsuarioEntidad> lista = UsuarioLN.ObtenerTodos();
                    this.ddlBusqueda.DataSource = lista;
                    this.ddlBusqueda.DataTextField = "nombre";
                    this.ddlBusqueda.DataValueField = "idUsuario";
                    this.ddlBusqueda.DataBind();
                    this.ddlBusqueda.SelectedIndex = 0;
                    this.lblBusqueda.Text = "Usuario";
                }
                else
                {
                    List<ProductoEntidad> lista = ProductoLN.ObtenerTodos();
                    this.ddlBusqueda.DataSource = lista;
                    this.ddlBusqueda.DataTextField = "nombre";
                    this.ddlBusqueda.DataValueField = "idProducto";
                    this.ddlBusqueda.DataBind();
                    this.ddlBusqueda.SelectedIndex = 0;
                    this.lblBusqueda.Text = "Producto";
                }
            }
        }

        protected void ddlOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarCombo();
        }

        protected void txtBusqueda_Click(object sender, EventArgs e)
        {
            int opcion = this.ddlOpcion.SelectedIndex;

            if (opcion == 0)
            {
                llenarGridMesa(Convert.ToDateTime(this.txtFechaInicial.Text), Convert.ToDateTime(this.txtFechaFinal.Text), Convert.ToInt16(this.ddlBusqueda.SelectedValue));
            }
            else
            {
                if (opcion == 1)
                {
                    llenarGridMesero(Convert.ToDateTime(this.txtFechaInicial.Text), Convert.ToDateTime(this.txtFechaFinal.Text), this.ddlBusqueda.SelectedValue);
                }
                else
                {
                    llenarGridProducto(Convert.ToDateTime(this.txtFechaInicial.Text), Convert.ToDateTime(this.txtFechaFinal.Text), Convert.ToInt16(this.ddlBusqueda.SelectedValue));
                }
               }
            }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }
    }
}