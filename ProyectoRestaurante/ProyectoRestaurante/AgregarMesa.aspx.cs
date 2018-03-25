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
    public partial class AgregarMesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                
                this.ddlEstadoMesa.DataSource = EstadoMesaLN.ObtenerTodos();
                this.ddlEstadoMesa.DataTextField = "descripcion";
                this.ddlEstadoMesa.DataValueField = "estadoMesa";
                this.ddlEstadoMesa.DataBind();


            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(this.txtCantidad.Text) >= 1 && Convert.ToInt16(this.txtCantidad.Text) <= 20)
            {
                MesaEntidad mesa = new MesaEntidad();
                mesa.cantidadPersonas = Convert.ToInt16(this.txtCantidad.Text);
                mesa.estadoMesa.estadoMesa = Convert.ToInt16(this.ddlEstadoMesa.SelectedValue);
                MesaLN.Nuevo(mesa);
                Response.Redirect("MantenimientoMesas.aspx");
            }
            else
            {
                this.lblMensaje.Text = "La cantidad de personas por mesa debe ser mayor a 0 y menor a 20";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoMesas.aspx");
        }

        protected void cumCantidad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ((args.Value.Length >= 1) && (args.Value.Length <= 20));
        }
    }
}