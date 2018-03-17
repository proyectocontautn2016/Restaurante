using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoRestaurante
{
    public partial class principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String nombre = Session["nombre"].ToString();
                DateTime fecha = DateTime.Today;
                this.lblNombreUsuario.Text = nombre;
                this.lblFecha.Text = fecha.ToString("dd/MM/yyyy");
            }
            catch (Exception)
            {

                Response.Redirect("default.aspx");
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["nombre"] = null;
            Response.Redirect("default.aspx");
        }
    }
}