using DatosRestaurante;
using EntidadesRestaurante;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaRestaurante
{
    public class MesaLN
    {
        public static List<MesaEntidad> ObtenerTodos()
        {
            List<MesaEntidad> lista = new List<MesaEntidad>();
            DataSet ds = MesaDatos.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                MesaEntidad elemento = new MesaEntidad();
                elemento.idMesa = Convert.ToInt16(fila["id"].ToString());
                elemento.cantidadPersonas = Convert.ToInt16(fila["cantidadPersonas"].ToString());

                EstadoMesaEntidad estadoMesa = new EstadoMesaEntidad();
                estadoMesa.estadoMesa = Convert.ToInt16(fila["idEstadoMesa"].ToString());
                estadoMesa.descripcion = fila["descripcion"].ToString();
  
                elemento.estadoMesa = estadoMesa;

                lista.Add(elemento);
            }

            return lista;
        }

        public static MesaEntidad ObtenerMesa(int numero)
        {

            List<MesaEntidad> listaMesas = MesaLN.ObtenerTodos();
            MesaEntidad mesa = (listaMesas.Find(elemento => (elemento.idMesa == numero)));

            return mesa;
        }

        public static List<MesaEntidad> ObtenerMesasEstado(int estado)
        {

            List<MesaEntidad> listaMesas = MesaLN.ObtenerTodos();
            List<MesaEntidad> lista;
            lista = listaMesas.Where(elemento => elemento.estadoMesa.estadoMesa == estado).ToList();

            return lista;
        }


        public static void Nuevo(MesaEntidad mesa)
        {
            MesaDatos.Insertar(mesa);
        }

        public static void Modificar(MesaEntidad mesa)
        {
            MesaDatos.Modificar(mesa);
        }
    }
}
