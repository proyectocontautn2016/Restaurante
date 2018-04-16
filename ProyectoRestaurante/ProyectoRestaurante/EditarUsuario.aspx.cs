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
    public partial class EditarUsuario : System.Web.UI.Page
    {
        public static String password = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    UsuarioEntidad usuario = new UsuarioEntidad();
                    String identificación = (Request.QueryString["idIdentificacion"].ToString());
                    usuario = UsuarioLN.obtenerUsuarioId(identificación);
                    this.txtDireccion.Text = usuario.direccion;
                    this.txtEmail.Text = usuario.email;
                    this.txtIdentificación.Text = usuario.idUsuario;
                    this.txtNombre.Text = usuario.nombre;
                    password = usuario.password;
                    this.txtTelefono.Text = usuario.telefono;
                    this.ddlRol.DataSource = RolLN.ObtenerTodos();
                    this.ddlRol.DataTextField = "descripcion";
                    this.ddlRol.DataValueField = "idRol";
                    this.ddlRol.DataBind();
                    this.ddlRol.SelectedValue = usuario.rol.idRol.ToString();

                    ListItemCollection items = new ListItemCollection
                {
                    new ListItem("Desactivo", "0"),
                    new ListItem("Activo", "1"),

                };
                    this.ddlEstado.DataSource = items;
                    this.ddlEstado.DataBind();
                    this.ddlEstado.SelectedIndex = usuario.estado;
                }
                catch (Exception)
                {

                    Response.Redirect("MantenimientoUsuarios.aspx");
                }
                


            }
        }

        
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioEntidad usuario = new UsuarioEntidad();
            usuario.idUsuario = (this.txtIdentificación.Text);
            usuario.nombre = (this.txtNombre.Text);
            usuario.password = password;
            usuario.email = (this.txtEmail.Text);
            usuario.direccion = (this.txtDireccion.Text);
            usuario.telefono = (this.txtTelefono.Text);
            usuario.rol.idRol = Convert.ToInt16(this.ddlRol.SelectedValue);
            usuario.estado = Convert.ToInt16(this.ddlEstado.SelectedIndex);
            UsuarioLN.Modificar(usuario);
            Response.Redirect("MantenimientoUsuarios.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoUsuarios.aspx");
        }
    }
}