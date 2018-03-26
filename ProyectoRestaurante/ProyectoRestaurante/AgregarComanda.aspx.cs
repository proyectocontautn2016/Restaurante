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
    public partial class AgregarComanda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMesas.DataSource = MesaLN.ObtenerTodos();
                ddlMesas.DataTextField = "idMesa";
                ddlMesas.DataValueField = "idMesa";
                ddlMesas.DataBind();

                try
                {
                    int pIdMesa = Convert.ToInt16(Request.QueryString["idMesa"].ToString());
                    if (pIdMesa >= 1)
                    {
                        ddlMesas.SelectedValue = pIdMesa.ToString();
                        ddlMesas.Enabled = false;
                    }
                }
                catch (Exception)
                {
                    
                }

                cargarProductos();
            }
        }

        private void cargarProductos() {
            List<ProductoEntidad> listaProductos = ProductoLN.ObtenerTodos();            
            String hileraTabla = "<center><table><tr>";
            int counter = 1;
            foreach (ProductoEntidad item in listaProductos)
            {
                if (counter <= 4) //El 5 determina la cantidad de elementos por fila
                {
                    hileraTabla += "<td style=\"padding:15px\">";

                    hileraTabla += "<a class='btn btn-warning' href=\"incluirProducto.aspx?idProducto=" + item.idProducto + "\">";
                    hileraTabla += "<img src=\"img/productos/" + item.imagen + "\" height=\"200px\" width=\"200px\"/>";
                    hileraTabla += "<br/>";
                    hileraTabla += "<b>" + item.nombre + "</b>";
                    hileraTabla += "<br/>";
                    hileraTabla += "Precio: ₡" + item.precio;
                    hileraTabla += "<br/><br/>";
                    hileraTabla += "</a>";

                    hileraTabla += "</td>";
                }
                else
                {
                    hileraTabla += "</tr>";
                    hileraTabla += "<tr>";
                    hileraTabla += "<td style=\"padding:15px\">";

                    hileraTabla += "<a class='btn btn-warning' href=\"incluirProducto.aspx?idProducto=" + item.idProducto + "\">";
                    hileraTabla += "<img src=\"img/productos/" + item.imagen + "\" height=\"200px\" width=\"200px\"/>";
                    hileraTabla += "<br/>";
                    hileraTabla += "<b>" + item.nombre + "</b>";
                    hileraTabla += "<br/>";
                    hileraTabla += "Precio: ₡" + item.precio;
                    hileraTabla += "<br/><br/>";
                    hileraTabla += "</a>";


                    hileraTabla += "</td>";

                    counter = 1; //Reinicializa el contador para crear una nueva fila de items
                }


                counter++;
            }

            hileraTabla += "</tr></table></center>";

            idListadoProductos.InnerHtml = hileraTabla;
        }
    }
}