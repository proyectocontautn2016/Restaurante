using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRestaurante
{
    public class UsuarioEntidad
    {
        public String idUsuario { get; set; }
        public RolEntidad rol { get; set; }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public String email { get; set; }
        public String  telefono { get; set; }
        public Boolean estado { get; set; }

        public UsuarioEntidad()
        {
            rol = new RolEntidad();
        }
    }
}
