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
    public partial class AgregarProducto : System.Web.UI.Page
    {
        static String tipo = "";
        static String URL2 = "";
        static FileUpload foto2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.imagenProducto.ImageUrl = "img/prev/prev.jpg";
                this.ddlTipoProducto.DataSource = TipoProductoLN.ObtenerTodos();
                this.ddlTipoProducto.DataTextField = "descripcion";
                this.ddlTipoProducto.DataValueField = "idTipoProducto";
                this.ddlTipoProducto.DataBind();

                ListItemCollection items = new ListItemCollection
                {
                    new ListItem("Desactivo", "0"),
                    new ListItem("Activo", "1"),
                };
                this.ddlEstado.DataSource = items;
                this.ddlEstado.DataBind();
                foto2 = null;
            }
        }

        protected void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (this.files.HasFile)
            {
                foto2 = this.files;
                this.files.SaveAs(Server.MapPath("~/img/prev/" + this.files.FileName));

                URL2 = "img/prev/" + this.files.FileName;
                this.lblImgMensaje.Text = "";

                this.imagenProducto.ImageUrl = URL2;
            }
            else
            {
                this.lblImgMensaje.Text = "Seleccione una imagen antes";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ProductoEntidad producto = new ProductoEntidad();
            if (foto2 != null)
            {
                tipo = this.ddlTipoProducto.SelectedItem.ToString();
                foto2.SaveAs(Server.MapPath("~/img/productos/" + tipo + "/" + foto2.FileName));
                String FileToDelete = Server.MapPath(URL2);
                System.IO.File.Delete(FileToDelete);
                URL2 = tipo + "/" + foto2.FileName;
                /*this.imagenProducto.ImageUrl = URL;
                this.lblImgMensaje.Text = "";
                this.imgPrev.ImageUrl = "img/prev/prev.jpg";*/
                producto.imagen = URL2;
                producto.nombre = this.txtNombreProducto.Text;
                Boolean esta = false;
                if (this.ddlEstado.SelectedIndex == 1)
                {
                    esta = true;
                }
                producto.estado = esta;
                producto.tipoProducto.idTipoProducto = Convert.ToInt16(this.ddlTipoProducto.SelectedValue);
                producto.descripcion = this.txtDescripcion.Text;
                if (Convert.ToDecimal(this.txtPrecio.Text) >= 0)
                {
                    producto.precio = Convert.ToDecimal(this.txtPrecio.Text);
                }
                else
                {
                    producto.precio = 0;
                }

                ProductoLN.Nuevo(producto);
                Response.Redirect("MantenimientoProductos.aspx");

            }
            else
            {
                this.lblMensaje.Text = "Es necesario una imagen para guardar el producto";
            }



        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            foto2 = null;
            URL2 = "";
            Response.Redirect("MantenimientoProductos.aspx");
        }
    }
}