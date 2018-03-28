using EntidadesRestaurante;
using LogicaRestaurante;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoRestaurante
{
    public partial class EditarProducto : System.Web.UI.Page
    {
        static String  tipo = "";
        static String URL = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ProductoEntidad producto = new ProductoEntidad();
                int idProducto = Convert.ToInt16(Request.QueryString["idProducto"].ToString());
                producto = ProductoLN.ObtenerProducto(idProducto);
                this.txtNombreProducto.Text = producto.nombre;
                this.txtDescripcion.Text = producto.descripcion;
                this.txtPrecio.Text = producto.precio.ToString();
                this.imagenProducto.ImageUrl = "img/productos/" + producto.imagen;
               
               
                this.ddlTipoProducto.DataSource = TipoProductoLN.ObtenerTodos();
                this.ddlTipoProducto.DataTextField = "descripcion";
                this.ddlTipoProducto.DataValueField = "idTipoProducto";
                this.ddlTipoProducto.DataBind();
                this.ddlTipoProducto.SelectedValue = producto.tipoProducto.idTipoProducto.ToString();

                ListItemCollection items = new ListItemCollection
                {
                    new ListItem("Desactivo", "0"),
                    new ListItem("Activo", "1"),

                };
                this.ddlEstado.DataSource = items;
                this.ddlEstado.DataBind();
                int vEstado = 0;
                if(producto.estado == true)
                {
                    vEstado = 1;
                }
                this.ddlEstado.SelectedIndex = vEstado;
                tipo = producto.tipoProducto.descripcion; 

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
           
            this.files.SaveAs(Server.MapPath("~/img/productos/" + tipo + "/" + this.files.FileName));
            
           
            String FileToDelete = Server.MapPath(URL);
            System.IO.File.Delete(FileToDelete);
            URL = "img/productos/" + tipo + "/" + this.files.FileName;
            this.imagenProducto.ImageUrl = URL;

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnVisualizar_Click(object sender, EventArgs e)
        {
            this.files.SaveAs(Server.MapPath("~/img/prev/" + "/" + this.files.FileName));

            URL = "img/prev/ " + this.files.FileName;

            this.imgPrev.ImageUrl = URL;
        }
    }
}