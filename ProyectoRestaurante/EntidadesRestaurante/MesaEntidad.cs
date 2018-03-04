using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesRestaurante
{
    public class MesaEntidad
    {
        public int idMesa { get; set; }
        public EstadoMesaEntidad estadoMesa { get; set; }

        public MesaEntidad()
        {
            estadoMesa = new EstadoMesaEntidad();
        }
    }
}
