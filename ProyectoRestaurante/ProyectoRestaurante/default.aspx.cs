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
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {

            try
            {
                UsuarioEntidad usuario = UsuarioLN.Login(txtUsuario.Text, txtPassword.Text);
               
                if (usuario != null)
                {
                    Session["usuario"] = usuario;
                    Response.Redirect("disponibilidadMesas.aspx");

                }else{
                    this.lblMensaje.Text = "Usuario o Contraseña no concuerdan";
                }

            }
            catch (Exception)
            {

                this.lblMensaje.Text = "Existe un problema con la conexión a base de datos";
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