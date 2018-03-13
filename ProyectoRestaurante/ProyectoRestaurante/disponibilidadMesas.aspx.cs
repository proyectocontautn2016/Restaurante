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
        //Esto es un ejemplo y se debe retirar
        private List<string> ListaEjemplo = new List<string>();//Esto es un ejemplo y se debe retirar

        protected void Page_Load(object sender, EventArgs e)
        {
            ListaEjemplo.Add("Ejemplo1");//Esto es un ejemplo y se debe retirar
            ListaEjemplo.Add("Ejemplo2");//Esto es un ejemplo y se debe retirar
            ListaEjemplo.Add("Ejemplo3");//Esto es un ejemplo y se debe retirar
            ListaEjemplo.Add("Ejemplo4");//Esto es un ejemplo y se debe retirar
            ListaEjemplo.Add("Ejemplo5");//Esto es un ejemplo y se debe retirar
            ListaEjemplo.Add("Ejemplo6");//Esto es un ejemplo y se debe retirar
            ListaEjemplo.Add("Ejemplo7");//Esto es un ejemplo y se debe retirar
            ListaEjemplo.Add("Ejemplo8");//Esto es un ejemplo y se debe retirar
            ListaEjemplo.Add("Ejemplo9");//Esto es un ejemplo y se debe retirar
            ListaEjemplo.Add("Ejemplo10");//Esto es un ejemplo y se debe retirar
            ListaEjemplo.Add("Ejemplo11");//Esto es un ejemplo y se debe retirar
            ListaEjemplo.Add("Ejemplo12");//Esto es un ejemplo y se debe retirar
            organizarMesas();
        }

        private void organizarMesas() {

            String hileraTabla = "<table><tr>";
            int counter = 1;

            foreach (String item in ListaEjemplo) {
                if (counter <= 5) //El 5 determina la cantidad de elementos por fila
                {
                    hileraTabla += "<td>";

                    hileraTabla += item.ToString() + " ";

                    hileraTabla += "</td>";
                }
                else {
                    hileraTabla += "</tr>";
                    hileraTabla += "<tr>";
                    hileraTabla += "<td>";

                    hileraTabla += item.ToString() + " ";

                    hileraTabla += "</td>";

                    counter = 1; //Reinicializa el contador para crear una nueva fila de items
                }

                counter++;
            }

            hileraTabla += "</tr></table>";


            idOrganizacionMesas.InnerHtml = hileraTabla;

        }


    }
}