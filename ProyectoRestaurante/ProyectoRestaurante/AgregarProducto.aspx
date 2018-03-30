<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="ProyectoRestaurante.AgregarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid divRedondear" style="background-color:white">
        
        <div class="col-md-offset-1 col-md-10">


            <center><h2>Modulo Para Agregar Productos</h2></center>

        <br /><br />

              <div class="form-group row">
            <div class="col-md-5">
                <asp:Image ID="imagenProducto" runat="server" ImageUrl="''" Height="200px" Width="200px" />
            </div>
            <div class="col-md-7">

                 <asp:TextBox ID="txtNombreProducto" Font-Size="Large" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="registrar" ControlToValidate="txtNombreProducto" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="El campo nombre es requerido"></asp:RequiredFieldValidator>
                <br /><br />
                
                <asp:Label ID="lblImgMensaje" ForeColor="Red" Font-Size="Large" runat="server" Text=""></asp:Label>
                <br />
                <asp:FileUpload CssClass="btn btn-success" ID="files" runat="server" />
                <br />
                <asp:Button CssClass="btn btn-primary" ID="btnVisualizar" runat="server" Text="Pre-Visualizar" OnClick="btnVisualizar_Click" />
            </div>
         </div>

                <div class="form-group row">
        <div class="col-md-4">
        <label runat="server" style="font-size:large" id="Label1" for="">Tipo Producto</label>
        </div>
        <div class="col-md-8">
        <asp:DropDownList ID="ddlTipoProducto" CssClass="form-control" Font-Size="Large" runat="server"></asp:DropDownList>
         </div>
        </div>


        <div class="form-group row">
            <div class="col-md-4">
                <label runat="server" style="font-size:large" id="lblDescripcion" for="">Descripcion</label>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" Height="200px" Font-Size="Large" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="registrar" ControlToValidate="txtDescripcion" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="El campo descripción es requerido"></asp:RequiredFieldValidator>
            </div>
         </div>


        <div class="form-group row">
            <div class="col-md-4">
                <label runat="server" style="font-size:large" id="Label4" for="">Precio</label>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtPrecio" Font-Size="Large" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="registrar" ControlToValidate="txtPrecio" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="El campo precio es requerido"></asp:RequiredFieldValidator>
            </div>
         </div>
      
       <div class="form-group row">
        <div class="col-md-4">
        <label runat="server" style="font-size:large" id="Label2" for="">Estado</label>
        </div>
        <div class="col-md-8">
        <asp:DropDownList ID="ddlEstado" CssClass="form-control" Font-Size="Large" runat="server"></asp:DropDownList>
         </div>
        </div>

            <br /><br />
            <asp:Label ID="lblMensaje"  ForeColor="red" runat="server" Text=""></asp:Label>
             <br /><br />

            <asp:Button ID="btnAceptar" OnClientClick="if(Page_ClientValidate())return confirm('¿Desea Guardar los cambios?');"  runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnAceptar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-success" OnClick="btnCancelar_Click" />

            <br /><br />
    </div>

    </div>
</asp:Content>
