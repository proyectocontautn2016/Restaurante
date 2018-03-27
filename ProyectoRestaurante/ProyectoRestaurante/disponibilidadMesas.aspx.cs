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
    public partial class disponibilidadMesas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            organizarMesas();
            mostrarEstados();
        }

        private void mostrarEstados()
        {
            List<EstadoMesaEntidad> listaEstadosMesas = EstadoMesaLN.ObtenerTodos();
            String hilera = "<center><table style='border:solid 1px black'>";

            foreach(EstadoMesaEntidad item in listaEstadosMesas)
            {
                hilera += "<tr><td style=\"padding:5px\">";
                hilera += "<strong>" + item.descripcion + "</strong>" + "</td>"; 
                hilera += "<td style=\"padding:5px\">";
                hilera += "<img src=\"img/mesaEstados/E" + (item.estadoMesa) + ".jpg\" height=\"30px\" width=\"30px\"/>";
                hilera += "</td></tr>";
            }

            hilera += "</table></center>";


            idEstadosMesas.InnerHtml = hilera;
        }

        private void organizarMesas() {
            List<MesaEntidad> listaMesas = MesaLN.ObtenerTodos();
            String hileraTabla = "<center><table><tr>";
            int counter = 1;

            foreach (MesaEntidad item in listaMesas) {
                if (counter <= 5) //El 5 determina la cantidad de elementos por fila
                {
                    hileraTabla += "<td style=\"padding:15px\">";


                    hileraTabla += "<a class='btn btn-warning' href=\"accionMesa.aspx?idMesa=" + item.idMesa + "\">";
                     hileraTabla += "<img src=\"img/mesaEstados/" + item.estadoMesa.estadoMesa + ".jpg\" height=\"100px\" width=\"100px\"/>";
                    hileraTabla += "<br/>";
                    hileraTabla += "<b>Mesa N° " + item.idMesa + "</b>";
                    hileraTabla += "<br/>";
                    hileraTabla += item.cantidadPersonas + " Personas";
                    hileraTabla += "<br/>";
                    hileraTabla += item.estadoMesa.descripcion;
                    hileraTabla += "<br/><br/>";
                    hileraTabla += "</a>";




                    hileraTabla += "</td>";
                }
                else {
                    hileraTabla += "</tr>";
                    hileraTabla += "<tr>";
                    hileraTabla += "<td style=\"padding:15px\">";


                    hileraTabla += "<a class='btn btn-warning' href=\"accionMesa.aspx?idMesa=" + item.idMesa + "\">";
                    hileraTabla += "<img src=\"img/mesaEstados/" + item.estadoMesa.estadoMesa + ".jpg\" height=\"100px\" width=\"100px\"/>";
                    hileraTabla += "<br/>";
                    hileraTabla += "<b>Mesa N° " + item.idMesa + "</b>";
                    hileraTabla += "<br/>";
                    hileraTabla += item.cantidadPersonas + " Personas";
                    hileraTabla += "<br/>";
                    hileraTabla += item.estadoMesa.descripcion;
                    hileraTabla += "</a>";


                    hileraTabla += "</td>";

                    counter = 1; //Reinicializa el contador para crear una nueva fila de items
                }


                counter++;
            }

            hileraTabla += "</tr></table></center>";


            idOrganizacionMesas.InnerHtml = hileraTabla;

        }


    }
}