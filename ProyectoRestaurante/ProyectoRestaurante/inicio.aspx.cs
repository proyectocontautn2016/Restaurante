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
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RestauranteEntidad resta = new RestauranteEntidad();
            resta = RestauranteLN.ObtenerRestaurante(1);
            this.imgLogo.ImageUrl = "img/infoRestaurante/" + resta.logo;
            this.lblTitulo.Text = "Restaurante " + resta.nombre;
            this.lblDireccion.Text = "Dirección:  " + resta.direccion;
            this.lblTelefono.Text = "Teléfono:  " + resta.telefono;
        }
    }
}