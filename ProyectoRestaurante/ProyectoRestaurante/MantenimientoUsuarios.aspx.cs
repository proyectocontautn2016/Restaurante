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
    public partial class MantenimientoUsuarios : System.Web.UI.Page
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

                this.ddlRol.DataSource = RolLN.ObtenerTodos();
                this.ddlRol.DataTextField = "descripcion";
                this.ddlRol.DataValueField = "idRol";
                this.ddlRol.DataBind();

                refrescarListar();


            }
        }

        private void refrescarListar()
        {
            List<UsuarioEntidad> lista = new List<UsuarioEntidad>();
            lista = UsuarioLN.ObtenerTodos();
            grvListado.DataSource = lista;
            grvListado.DataBind();
        }

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<UsuarioEntidad> lista = new List<UsuarioEntidad>();
            int rol = Convert.ToInt16(this.ddlRol.SelectedValue);
            lista = UsuarioLN.ObtenerUsuarioRol(rol);
            grvListado.DataSource = lista;
            grvListado.DataBind();
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<UsuarioEntidad> lista = new List<UsuarioEntidad>();
            int estado = (this.ddlEstado.SelectedIndex);
            lista = UsuarioLN.ObtenerUsuarioEstado(estado);
            grvListado.DataSource = lista;
            grvListado.DataBind();
        }

        protected void btnTodosEstados_Click(object sender, EventArgs e)
        {
            refrescarListar();
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarUsuario.aspx");
        }

        protected void grvListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            UsuarioEntidad usuario = new UsuarioEntidad();
            int num = Convert.ToInt32(e.CommandArgument);

            usuario.idUsuario = grvListado.Rows[num].Cells[0].Text;
            

            Response.Redirect("EditarUsuario.aspx?idIdentificacion=" + usuario.idUsuario);
        }
    }
}