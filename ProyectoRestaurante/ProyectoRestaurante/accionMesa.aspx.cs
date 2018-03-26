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
    public partial class accionMesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                llenarCampos();
            }
            catch (Exception)
            {

            }
        }

        private void llenarCampos() {
            MesaEntidad mesa = new MesaEntidad();
            int numero = Convert.ToInt16(Request.QueryString["idMesa"].ToString());
            mesa = MesaLN.ObtenerMesa(numero);
            lblNumeroMesa.Text = "Mesa #" + Request.QueryString["idMesa"].ToString();
            txtMesaId.Text = mesa.idMesa.ToString();
            txtCantidadPersonas.Text = mesa.cantidadPersonas.ToString();
            txtEstado.Text = mesa.estadoMesa.descripcion;
            cargarComboAccionMesa(mesa.estadoMesa.estadoMesa);
            imgEstadoMesa.ImageUrl = "~/img/Mesas/" + mesa.estadoMesa.estadoMesa + ".jpg";
        }


        private void cargarComboAccionMesa(int pIdEstadoMesa)
        {
            if (!IsPostBack)
            {
                if (pIdEstadoMesa == 1)
                {
                    ddlAccionMesa.Items.Insert(0, new ListItem("--Seleccionar acción--", "0"));
                    ddlAccionMesa.Items.Insert(1, new ListItem("Ocupar mesa", "2"));
                }

                if (pIdEstadoMesa == 2)
                {
                    ddlAccionMesa.Items.Insert(0, new ListItem("--Seleccionar acción--", "0"));
                    ddlAccionMesa.Items.Insert(1, new ListItem("Liberar Mesa", "1"));
                    ddlAccionMesa.Items.Insert(2, new ListItem("Registrar Comanda", "3"));
                }

                if (pIdEstadoMesa == 5)
                {
                    ddlAccionMesa.Items.Insert(0, new ListItem("--Seleccionar acción--", "0"));
                    ddlAccionMesa.Items.Insert(1, new ListItem("Activar Mesa", "1"));
                }
            }
            
        }

        protected void ddlAccionMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nuevoEstadoMesa = Convert.ToInt16(this.ddlAccionMesa.SelectedValue.ToString());

            if ((nuevoEstadoMesa == 1) || (nuevoEstadoMesa == 2)) {
                actualizarEstadoMesa(nuevoEstadoMesa);
            }

            if (nuevoEstadoMesa == 3)
            {
                int idMesa = Convert.ToInt16(this.txtMesaId.Text);
                Response.Redirect("AgregarComanda.aspx?idMesa=" + idMesa);
            }
        }



        private void actualizarEstadoMesa(int pNuevoEstadoMesa) {
            MesaEntidad mesa = new MesaEntidad();
            mesa.idMesa = Convert.ToInt16(txtMesaId.Text);
            mesa.cantidadPersonas = Convert.ToInt16(this.txtCantidadPersonas.Text);
            mesa.estadoMesa.estadoMesa = pNuevoEstadoMesa;
            MesaLN.Modificar(mesa);

            Response.Redirect("accionMesa.aspx?idMesa=" + mesa.idMesa);
        }
    }
}