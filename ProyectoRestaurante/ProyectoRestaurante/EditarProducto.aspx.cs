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
        static String tipo = "";
        static String URL = "";
        static String URLProducto = "";
        static FileUpload foto;
        static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ProductoEntidad producto = new ProductoEntidad();
                int idProducto = Convert.ToInt16(Request.QueryString["idProducto"].ToString());
                id = idProducto;
                producto = ProductoLN.ObtenerProducto(idProducto);
                this.txtNombreProducto.Text = producto.nombre;
                this.txtDescripcion.Text = producto.descripcion;
                this.txtPrecio.Text = producto.precio.ToString();
                this.imagenProducto.ImageUrl = "img/productos/" + producto.imagen;
                this.imgPrev.ImageUrl = "img/prev/prev.jpg";
                URLProducto = producto.imagen;



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
                if (producto.estado == true)
                {
                    vEstado = 1;
                }
                this.ddlEstado.SelectedIndex = vEstado;
                tipo = producto.tipoProducto.descripcion;

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ProductoEntidad producto = new ProductoEntidad();

            if (tipo == this.ddlTipoProducto.SelectedItem.ToString())
            {
                if (foto != null)
                {
                    foto.SaveAs(Server.MapPath("~/img/productos/" + tipo + "/" + foto.FileName));
                    String FileToDelete = Server.MapPath(URL);
                    System.IO.File.Delete(FileToDelete);
                    URL = tipo + "/" + foto.FileName;
                    /*this.imagenProducto.ImageUrl = URL;
                    this.lblImgMensaje.Text = "";
                    this.imgPrev.ImageUrl = "img/prev/prev.jpg";*/
                    producto.imagen = URL;

                }
                else
                {
                    producto.imagen = URLProducto;
                }
            }else
            {
                tipo = this.ddlTipoProducto.SelectedItem.ToString();

                if (foto != null)
                {
                    foto.SaveAs(Server.MapPath("~/img/productos/" + tipo + "/" + foto.FileName));
                    String FileToDelete = Server.MapPath(URL);
                    System.IO.File.Delete(FileToDelete);
                    URL = tipo + "/" + foto.FileName;
                    /*this.imagenProducto.ImageUrl = URL;
                    this.lblImgMensaje.Text = "";
                    this.imgPrev.ImageUrl = "img/prev/prev.jpg";*/
                    producto.imagen = URL;

                }
                else
                {
                    String cadena = URLProducto;
                    String[] separadas = cadena.Split('/');
                    producto.imagen = tipo + "/" + separadas[1];
                    String UR1 = "img/productos/" + URLProducto;
                    String UR2 = "img/productos/" + producto.imagen;

                    string sourceFile = Server.MapPath(UR1);
                    string destinationFile = Server.MapPath(UR2);
                    System.IO.File.Move(sourceFile, destinationFile);

                }


            }

            producto.nombre = this.txtNombreProducto.Text;
            Boolean esta = false;
            if (this.ddlEstado.SelectedIndex == 1)
            {
                esta = true;
            }
            producto.estado = esta;
            producto.tipoProducto.idTipoProducto = Convert.ToInt16(this.ddlTipoProducto.SelectedValue);
            producto.descripcion = this.txtDescripcion.Text;
            producto.precio = Convert.ToDecimal(this.txtPrecio.Text);
            producto.idProducto = id;
            ProductoLN.Modificar(producto);
            Response.Redirect("MantenimientoProductos.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (foto != null)
            {
               foto = null;
                URL = "";
            }

            Response.Redirect("MantenimientoProductos.aspx");
        }

        protected void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (this.files.HasFile)
            {
                foto = this.files;
                this.files.SaveAs(Server.MapPath("~/img/prev/" + this.files.FileName));

                URL = "img/prev/" + this.files.FileName;
                this.lblImgMensaje.Text = "";

                this.imgPrev.ImageUrl = URL;
            }
            else
            {
                this.lblImgMensaje.Text = "Seleccione una imagen antes";
            }

        }
    }
}