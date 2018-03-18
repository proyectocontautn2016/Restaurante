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

            lblNumeroMesa.Text = "Mesa #" + Request.QueryString["idMesa"].ToString();
            txtMesaId.Text = Request.QueryString["idMesa"].ToString();
        }
    }
}