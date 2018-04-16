using EntidadesRestaurante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoRestaurante
{
    public partial class principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioEntidad usuario = (UsuarioEntidad)Session["usuario"];
                DateTime fecha = DateTime.Today;
                this.lblNombreUsuario.Text = usuario.nombre;
                this.lblFecha.Text = fecha.ToString("dd/MM/yyyy");
                this.lblANIO.Text = fecha.ToString("yyyy");

                if(usuario.rol.idRol == 2)
                {
                    //tipoMenu.InnerHtml = menuAdministrador();
                    idMantenimiento.Visible = false;
                    this.repoFecha.Visible = false;
                    this.repoPago.Visible = false;
                    this.repoPro.Visible = false;
                    this.repoUsu.Visible = false;


                }
                else
                {

                }
            }
            catch (Exception)
            {

                Response.Redirect("default.aspx");
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Session.Remove("usuario");
            Response.Redirect("default.aspx");
        }

        private String menuAdministrador()
        {
            String cadena = "";
            cadena+= "< ul class='nav navbar-nav'>";
            cadena += "< li class=''><a href = 'disponibilidadMesas.aspx' > Disponibilidad Mesas |</a></li>";
            cadena += "<li class='dropdown'><a class='dropdown-toggle' data-toggle='dropdown' href='#'>Reportes |<span class='caret'></span></a>";
            cadena += "<ul class='dropdown-menu'>";
            cadena += "<li><a href = 'ReporteProductos.aspx' > Reporte productos</a></li>";
            cadena += "<li><a href = 'VentasUsuario.aspx' > Ventas a mi cargo</a></li>";
            cadena += "<li><a href = 'ReporteVentasporUsuario.aspx' > Reporte Ventas por Usuario</a></li>";
            cadena += "<li><a href = 'ReporteVentasFecha.aspx' > Reporte Ventas por Rango Fechas</a></li>";
            cadena += "<li><a href = 'ReporteVentasXMedioPago.aspx' > Reporte Ventas por Medio de Pago</a></li>";
            cadena += "<li><a href = 'ReporteVentasxMesaMeseroProducto.aspx' > Reporte Ventas por Mesa, Mesero o Producto</a></li>";
            cadena += "</ ul >";
            cadena += "</ li >";
            cadena += "< li id = 'idMantenimiento' class='dropdown'><a class='dropdown-toggle' data-toggle='dropdown' href='#'>Mantenimientos |<span class='caret'></span></a>";
            cadena += "<ul class='dropdown-menu'>";
            cadena += "<li><a href = 'MantenimientoUsuarios.aspx' > Mantenimiento Usuarios</a></li>";
            cadena += "<li><a href = 'MantenimientoProductos.aspx' > Mantenimiento Productos</a></li>";
            cadena += "<li><a href = 'MantenimientoMesas.aspx' > Mantenimiento Mesas</a></li>";
            cadena += "</ul>";
            cadena += "</li>";
            cadena += "</ul>";
 
            return cadena;
        }

        private String menuMesero()
        {
            String cadena = "";
            return cadena;
        }
    }
}