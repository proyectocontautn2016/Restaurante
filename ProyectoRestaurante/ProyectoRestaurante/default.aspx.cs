using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoRestaurante
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean condi = false;
                    if ((this.txtUsuario.Text == "usuario") && (this.txtPassword.Text == "12345"))
                    {
                        condi = true;
                        Session["nombre"] = this.txtUsuario.Text;
                        
                    }
              

                if (condi)
                {

                    Response.Redirect("disponibilidadMesas.aspx");
                }
                else
                {
                    this.lblMensaje.Text = "Usuario o Contraseña no concuerdan";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            this.txtUsuario.Text = "";
            this.txtPassword.Text = "";
            this.lblMensaje.Text = "";
        }
    }
}