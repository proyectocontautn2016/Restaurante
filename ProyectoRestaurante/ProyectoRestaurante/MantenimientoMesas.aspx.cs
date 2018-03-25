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
    public partial class MantenimientoMesas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

               
                    this.ddlEstadoMesa.DataSource = EstadoMesaLN.ObtenerTodos();
                    this.ddlEstadoMesa.DataTextField = "descripcion";
                    this.ddlEstadoMesa.DataValueField = "estadoMesa";
                    this.ddlEstadoMesa.DataBind();

                    refrescarListar();
               

            }
        }

        public int numeroescogido;

        protected void ddlEstadoMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MesaEntidad> lista = new List<MesaEntidad>();
            int estado = Convert.ToInt16(this.ddlEstadoMesa.SelectedValue);
            lista = MesaLN.ObtenerMesasEstado(estado);
            grvListado.DataSource = lista;
            grvListado.DataBind();
        }

        private void refrescarListar()
        {
            List<MesaEntidad> lista = new List<MesaEntidad>();
            lista = MesaLN.ObtenerTodos();
            grvListado.DataSource = lista;
            grvListado.DataBind();
        }

        protected void btnTodosEstados_Click(object sender, EventArgs e)
        {
            refrescarListar();
        }

        protected void grvListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MesaEntidad mesa = new MesaEntidad();
            int num = Convert.ToInt32(e.CommandArgument);
            
            mesa.idMesa = Convert.ToInt16(grvListado.Rows[num].Cells[0].Text);
            numeroescogido = mesa.idMesa;

            Response.Redirect("EditarMesa.aspx?idMesa=" + numeroescogido);


        }

        protected void btnAgregarMesa_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMesa.aspx");
        }
    } 
}