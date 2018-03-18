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
    public class UsuarioLN
    {



        public static List<UsuarioEntidad> ObtenerTodos()
        {
            List<UsuarioEntidad> lista = new List<UsuarioEntidad>();
            DataSet ds = UsuarioDatos.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                UsuarioEntidad elemento = new UsuarioEntidad();
                elemento.idUsuario = fila["id"].ToString();

                RolEntidad role = new RolEntidad();
                role.idRol = Convert.ToInt16(fila["idRol"].ToString());
                elemento.rol = role;
                elemento.nombre = fila["nombre"].ToString();
                elemento.direccion = fila["direccion"].ToString();
                elemento.email = fila["correo"].ToString();
                elemento.telefono = fila["telefono"].ToString();
                elemento.estado = Convert.ToBoolean(fila["estado"].ToString());

                lista.Add(elemento);
            }

            return lista;
        }
    }
}
