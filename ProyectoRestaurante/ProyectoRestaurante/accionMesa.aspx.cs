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
    public partial class accionMesa : System.Web.UI.Page
    {
    
        static int mesaPedido;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["pedido"] != null)
                    {
                        Session.Remove("pedido");
                    }
                    llenarCampos();
                }
                catch (Exception)
                {
                    Response.Redirect("disponibilidadMesas.aspx");
                }
            }
        }

        private void llenarCampos() {
            MesaEntidad mesa = new MesaEntidad();
            int numero = Convert.ToInt16(Request.QueryString["idMesa"].ToString());
            mesaPedido = numero;
            mesa = MesaLN.ObtenerMesa(numero);
            btnAgregarProducto.Enabled = false;
            btnAgregarProducto.Visible = false;
            imgEstadoMesa.ImageUrl = "~/img/mesaEstados/" + mesa.estadoMesa.estadoMesa + ".jpg";
            lblNumeroMesa.Text = "Mesa #" + Request.QueryString["idMesa"].ToString();
            txtMesaId.Text = mesa.idMesa.ToString();
            txtCantidadPersonas.Text = mesa.cantidadPersonas.ToString();
            txtEstado.Text = mesa.estadoMesa.descripcion;
            cargarComboAccionMesa(mesa.estadoMesa.estadoMesa);
        }


        private void cargarComboAccionMesa(int pIdEstadoMesa)
        {
            if (!IsPostBack)
            {
                int idMesa = Convert.ToInt16(this.txtMesaId.Text);

                if (pIdEstadoMesa == 1)
                {
                    ddlAccionMesa.Items.Insert(0, new ListItem("--Seleccionar acción--", "0"));
                    ddlAccionMesa.Items.Insert(1, new ListItem("Ocupar mesa", "2"));
                }

                if (pIdEstadoMesa == 2)
                {
                    ddlAccionMesa.Items.Insert(0, new ListItem("--Seleccionar acción--", "0"));
                    ddlAccionMesa.Items.Insert(1, new ListItem("Liberar Mesa", "1"));
                    ddlAccionMesa.Items.Insert(2, new ListItem("Registrar Comanda", "3"));
                }

                if (pIdEstadoMesa == 3)
                {
                    ddlAccionMesa.Items.Insert(0, new ListItem("--Seleccionar acción--", "0"));
                    ddlAccionMesa.Items.Insert(1, new ListItem("Comanda en proceso", "4"));
                    ddlAccionMesa.Items.Insert(2, new ListItem("Comanda Pendiente", "5"));
                    cargarPedidoEnDataGridView(idMesa);
                    hacerVisibleBotonAgregarProducto();
                }

                if (pIdEstadoMesa == 4)
                {
                    ddlAccionMesa.Items.Insert(0, new ListItem("--Seleccionar acción--", "0"));
                    ddlAccionMesa.Items.Insert(1, new ListItem("Comanda Pendiente", "5"));
                    ddlAccionMesa.Items.Insert(2, new ListItem("Comanda Entregada", "7"));

                    cargarPedidoEnDataGridView(idMesa);
                    hacerVisibleBotonAgregarProducto();
                }

                if (pIdEstadoMesa == 5)
                {
                    ddlAccionMesa.Items.Insert(0, new ListItem("--Seleccionar acción--", "0"));
                    ddlAccionMesa.Items.Insert(1, new ListItem("Comanda en proceso", "4"));
                    ddlAccionMesa.Items.Insert(2, new ListItem("Comanda Entregada", "7"));

                    cargarPedidoEnDataGridView(idMesa);
                    hacerVisibleBotonAgregarProducto();
                }

                if (pIdEstadoMesa == 7)
                {
                    ddlAccionMesa.Items.Insert(0, new ListItem("--Seleccionar acción--", "0"));
                    ddlAccionMesa.Items.Insert(1, new ListItem("Comanda Pendiente", "5"));
                    ddlAccionMesa.Items.Insert(2, new ListItem("Comanda Finalizada", "8"));

                    cargarPedidoEnDataGridView(idMesa);
                }

                if (pIdEstadoMesa == 8)
                {
                    ddlAccionMesa.Items.Insert(0, new ListItem("--Seleccionar acción--", "0"));
                    ddlAccionMesa.Items.Insert(1, new ListItem("Comanda Pendiente", "5"));
                    ddlAccionMesa.Items.Insert(2, new ListItem("Por pagar la cuenta", "9"));

                    cargarPedidoEnDataGridView(idMesa);
                }

                if (pIdEstadoMesa == 9)
                {
                    ddlAccionMesa.Items.Insert(0, new ListItem("--Seleccionar acción--", "0"));
                    ddlAccionMesa.Items.Insert(1, new ListItem("Facturar", "100")); //Esto es solamente de ejemplo

                    cargarPedidoEnDataGridView(idMesa);
                }


                if (pIdEstadoMesa == 10)
                {
                    ddlAccionMesa.Items.Insert(0, new ListItem("--Seleccionar acción--", "0"));
                    ddlAccionMesa.Items.Insert(1, new ListItem("Activar Mesa", "1"));

                }
            }

        }

        protected void ddlAccionMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nuevoEstadoMesa = Convert.ToInt16(this.ddlAccionMesa.SelectedValue.ToString());
            int idMesa = Convert.ToInt16(this.txtMesaId.Text);

            if ((nuevoEstadoMesa == 1) || (nuevoEstadoMesa == 2)) {
                actualizarEstadoMesa(nuevoEstadoMesa);
                Response.Redirect("accionMesa.aspx?idMesa=" + idMesa);
            }

            if (nuevoEstadoMesa == 3)
            {
                crearPedido(idMesa, nuevoEstadoMesa);
                Response.Redirect("accionMesa.aspx?idMesa=" + idMesa);
            }

            if ((nuevoEstadoMesa == 4) || (nuevoEstadoMesa == 5) || (nuevoEstadoMesa == 7) || (nuevoEstadoMesa == 8) || (nuevoEstadoMesa == 9))
            {
                actualizarEstadoMesa(nuevoEstadoMesa);
                Response.Redirect("accionMesa.aspx?idMesa=" + idMesa);
            }

            if (nuevoEstadoMesa == 100)
            {
                EncabezadoPedidoEntidad pedido = EncabezadoPedidoLN.obtenerEncabezadoPedido(idMesa);
                if (Session["pedido"] != null)
                {
                    Session.Remove("pedido");
                }
                Session.Add("pedido", pedido);
                Response.Redirect("Facturacion.aspx");
            }

        }


        private void crearPedido(int pIdMesa, int pNuevoEstadomesa) {
            if (Session["pedido"] == null)
            {
                EncabezadoPedidoEntidad encabezadoPedidoEntidad = new EncabezadoPedidoEntidad();
                encabezadoPedidoEntidad.mesa.idMesa = pIdMesa;
                encabezadoPedidoEntidad.usuario = (UsuarioEntidad)Session["usuario"];
                encabezadoPedidoEntidad.estado = true;
                encabezadoPedidoEntidad.facturado = false;

                EncabezadoPedidoEntidad encabezadoPedidoEntidadGuardado = EncabezadoPedidoLN.Nuevo(encabezadoPedidoEntidad);
                actualizarEstadoMesa(pNuevoEstadomesa);

                //Session.Add("pedido", encabezadoPedidoEntidadGuardado);
            }
        }

        private void actualizarEstadoMesa(int pNuevoEstadoMesa) {
            MesaEntidad mesa = new MesaEntidad();
            mesa.idMesa = Convert.ToInt16(txtMesaId.Text);
            mesa.cantidadPersonas = Convert.ToInt16(this.txtCantidadPersonas.Text);
            mesa.estadoMesa.estadoMesa = pNuevoEstadoMesa;
            MesaLN.Modificar(mesa);
        }

        private void cargarPedidoEnDataGridView(int pIdMesa) {
            EncabezadoPedidoEntidad encabezadoPedido = new EncabezadoPedidoEntidad();
            encabezadoPedido = EncabezadoPedidoLN.obtenerEncabezadoPedido(pIdMesa);
            this.txtUsuarioAsignado.Text =  UsuarioLN.obtenerUsuarioId(encabezadoPedido.usuario.idUsuario).nombre;
            grvPedido.DataSource =  encabezadoPedido.listaDetalles;
            grvPedido.DataBind();
        }


        private void hacerVisibleBotonAgregarProducto() {
            btnAgregarProducto.Enabled = true;
            btnAgregarProducto.Visible = true;
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            int idMesa = Convert.ToInt16(this.txtMesaId.Text);
            EncabezadoPedidoEntidad pedido = EncabezadoPedidoLN.obtenerEncabezadoPedido(idMesa);
            if (Session["pedido"] != null)
            {
                Session.Remove("pedido");
            }
            Session.Add("pedido", pedido);
            Response.Redirect("AgregarComanda.aspx");
        }

        protected void grvPedido_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DetallePedidoEntidad detalle = new DetallePedidoEntidad();
            int num = Convert.ToInt32(e.CommandArgument);

            List<DetallePedidoEntidad> lista = new List<DetallePedidoEntidad>();
            lista = EncabezadoPedidoLN.obtenerEncabezadoPedido(mesaPedido).listaDetalles;

            int id = Convert.ToInt16(this.grvPedido.DataKeys[num].Values[0]);
            detalle = lista[num];


            Response.Redirect("EditarPedido.aspx?idDetallePedido=" + detalle.idDetallePedido + "&idEncabezadoPedido=" + detalle.idEncabezadoPedido );

        }
    }
}