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
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                
                this.ddlRol.DataSource = RolLN.ObtenerTodos();
                this.ddlRol.DataTextField = "descripcion";
                this.ddlRol.DataValueField = "idRol";
                this.ddlRol.DataBind();
               

                ListItemCollection items = new ListItemCollection
                {
                    new ListItem("Desactivo", "0"),
                    new ListItem("Activo", "1"),

                };
                this.ddlEstado.DataSource = items;
                this.ddlEstado.DataBind();

                this.txtPassword.Text = "12345";


            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioEntidad usuario = new UsuarioEntidad();
            usuario.idUsuario = (this.txtIdentificación.Text);
            usuario.nombre = (this.txtNombre.Text);
            usuario.password = this.txtPassword.Text;
            usuario.email = (this.txtEmail.Text);
            usuario.direccion = (this.txtDireccion.Text);
            usuario.telefono = (this.txtTelefono.Text);
            usuario.rol.idRol = Convert.ToInt16(this.ddlRol.SelectedValue);
            usuario.estado = Convert.ToInt16(this.ddlEstado.SelectedIndex);
            UsuarioLN.Nuevo(usuario);
            Response.Redirect("MantenimientoUsuarios.aspx");

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoUsuarios.aspx");
        }
    }
}