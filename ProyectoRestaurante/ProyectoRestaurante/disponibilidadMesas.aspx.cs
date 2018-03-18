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
        }

        private void organizarMesas() {
            List<MesaEntidad> listaMesas = MesaLN.ObtenerTodos();
            String hileraTabla = "<center><table><tr>";
            int counter = 1;

            foreach (MesaEntidad item in listaMesas) {
                if (counter <= 5) //El 5 determina la cantidad de elementos por fila
                {
                    hileraTabla += "<td style=\"padding:30px\">";


                   
                    hileraTabla += "<img src=\"img/estadoMesas/" + item.estadoMesa.estadoMesa + ".png\" height=\"100px\" width=\"100px\"/>";
                    hileraTabla += "<br/>";
                    hileraTabla += "<b>Mesa N° " + item.idMesa + "</b>";
                    hileraTabla += "<br/>";
                    hileraTabla += item.estadoMesa.descripcion;
                    hileraTabla += "<br/><br/>";
                    hileraTabla += "<a href=\"accionMesa.aspx?idMesa=" + item.idMesa + "\">Seleccionar mesa</a>";




                    hileraTabla += "</td>";
                }
                else {
                    hileraTabla += "</tr>";
                    hileraTabla += "<tr>";
                    hileraTabla += "<td style=\"padding:30px\">";


                    
                    hileraTabla += "<img src=\"img/estadoMesas/" + item.estadoMesa.estadoMesa + ".png\" height=\"100px\" width=\"100px\"/>";
                    hileraTabla += "<br/>";
                    hileraTabla += "<b>Mesa N° " + item.idMesa + "</b>";
                    hileraTabla += "<br/>";
                    hileraTabla += item.estadoMesa.descripcion;
                    hileraTabla += "<br/><br/>";
                    hileraTabla += "<a href=\"accionMesa.aspx?idMesa=" + item.idMesa + "\">Seleccionar mesa</a>";


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