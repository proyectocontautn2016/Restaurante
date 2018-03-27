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
    public class ProductoLN
    {
        public static List<ProductoEntidad> ObtenerTodos()
        {
            /*public int idProducto { get; set; }
            public TipoProductoEntidad tipoProducto { get; set; }
            public String nombre { get; set; }
            public String descripcion { get; set; }
            public Decimal precio { get; set; }
            public String imagen { get; set; }
            public int estado { get; set; }*/

            List<ProductoEntidad> lista = new List<ProductoEntidad>();
            DataSet ds = ProductoDatos.SeleccionarTodos();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                ProductoEntidad elemento = new ProductoEntidad();
                elemento.idProducto = Convert.ToInt16(fila["id"].ToString());
                elemento.tipoProducto.idTipoProducto = Convert.ToInt16(fila["idTipoProducto"].ToString());
                elemento.tipoProducto.descripcion = fila["descriTipoProducto"].ToString();
                elemento.nombre = fila["nombre"].ToString();
                elemento.descripcion = fila["descripcion"].ToString();
                elemento.precio = Convert.ToDecimal(fila["precio"].ToString());
                elemento.imagen = fila["imagen"].ToString();

                if(Convert.ToInt16(fila["estado"].ToString()) == 1)
                {
                    elemento.estado = true;
                }else
                {
                    elemento.estado = false;
                }
               
                lista.Add(elemento);
            }


            return lista;
        }

        public static List<ProductoEntidad> ObtenerProductoEstado(Boolean estado)
        {

            List<ProductoEntidad> listaProductos = ProductoLN.ObtenerTodos();
            List<ProductoEntidad> lista;
            lista = listaProductos.Where(elemento => elemento.estado == estado).ToList();

            return lista;
        }

        public static List<ProductoEntidad> ObtenerProductoTipo(int tipo)
        {

            List<ProductoEntidad> listaProductos = ProductoLN.ObtenerTodos();
            List<ProductoEntidad> lista;
            lista = listaProductos.Where(elemento => elemento.tipoProducto.idTipoProducto == tipo).ToList();

            return lista;
        }


        public static void Nuevo(ProductoEntidad producto)
        {
            ProductoDatos.Insertar(producto);
        }

        public static void Modificar(ProductoEntidad producto)
        {
            ProductoDatos.Modificar(producto);
        }
    }
}
