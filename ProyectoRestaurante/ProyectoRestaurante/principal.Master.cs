using EntidadesRestaurante;
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
                UsuarioEntidad usuario = (UsuarioEntidad)Session["usuario"];
                DateTime fecha = DateTime.Today;
                this.lblNombreUsuario.Text = usuario.nombre;
                this.lblFecha.Text = fecha.ToString("dd/MM/yyyy");
            }
            catch (Exception)
            {

                Response.Redirect("default.aspx");
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Session.Remove("usuario");
            Response.Redirect("default.aspx");
        }
    }
}