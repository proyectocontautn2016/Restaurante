using DatosRestaurante;
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
    public partial class EditarMesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MesaEntidad mesa = new MesaEntidad();
                int numero = Convert.ToInt16(Request.QueryString["idMesa"].ToString());
                mesa = MesaLN.ObtenerMesa(numero);
                this.txtCantidad.Text = mesa.cantidadPersonas.ToString();
                this.txtNumero.Text = mesa.idMesa.ToString();
                this.ddlEstadoMesa.DataSource = EstadoMesaLN.ObtenerTodos();
                this.ddlEstadoMesa.DataTextField = "descripcion";
                this.ddlEstadoMesa.DataValueField = "estadoMesa";
                this.ddlEstadoMesa.DataBind();
                this.ddlEstadoMesa.SelectedValue = mesa.estadoMesa.estadoMesa.ToString();


            }
        }

        protected void cumCantidad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ((args.Value.Length >=1) && (args.Value.Length <=20));
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt16(this.txtCantidad.Text) >= 1 && Convert.ToInt16(this.txtCantidad.Text) <= 20)
            {
                MesaEntidad mesa = new MesaEntidad();
                mesa.idMesa = Convert.ToInt16(this.txtNumero.Text);
                mesa.cantidadPersonas = Convert.ToInt16(this.txtCantidad.Text);
                mesa.estadoMesa.estadoMesa = Convert.ToInt16(this.ddlEstadoMesa.SelectedValue);
                MesaLN.Modificar(mesa);
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
    }
}