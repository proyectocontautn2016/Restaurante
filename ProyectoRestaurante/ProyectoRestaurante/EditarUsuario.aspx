<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="ProyectoRestaurante.EditarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid divRedondear" style="background-color:white">
        <div class="col-md-offset-1 col-md-10">


            <center><h2>Modulo de Edición de Usuario</h2></center>

        <br /><br />


        <div class="form-group row">
            <div class="col-md-4">
                <label runat="server" style="font-size:large" id="lblIdentificacion" for="">Identificación</label>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtIdentificación" Font-Size="Large" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="registrar" ControlToValidate="txtIdentificación" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="El campo Identificación es requerido"></asp:RequiredFieldValidator>
            </div>
         </div>


             <div class="form-group row">
        <div class="col-md-4">
        <label runat="server" style="font-size:large" id="Label3" for="">Rol</label>
        </div>
        <div class="col-md-8">
        <asp:DropDownList ID="ddlRol" CssClass="form-control" Font-Size="Large" runat="server" AutoPostBack="true"></asp:DropDownList>
         </div>
        </div>

            <div class="form-group row">
            <div class="col-md-4">
                <label runat="server" style="font-size:large" id="Label4" for="">Nombre</label>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtNombre" Font-Size="Large" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="registrar" ControlToValidate="txtNombre" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="El campo nombre es requerido"></asp:RequiredFieldValidator>
            </div>
         </div>

             <div class="form-group row">
            <div class="col-md-4">
                <label runat="server" style="font-size:large" id="Label5" for="">Dirección</label>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtDireccion" Font-Size="Large" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="registrar" ControlToValidate="txtDireccion" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="El campo dirección es requerido"></asp:RequiredFieldValidator>
            </div>
         </div>

             <div class="form-group row">
            <div class="col-md-4">
                <label runat="server" style="font-size:large" id="Label6" for="">Email</label>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtEmail" Font-Size="Large" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="registrar" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="El campo email es requerido"></asp:RequiredFieldValidator>
            </div>
         </div>

             <div class="form-group row">
            <div class="col-md-4">
                <label runat="server" style="font-size:large" id="Label7" for="">Telefono</label>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtTelefono" Font-Size="Large" runat="server" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="registrar" ControlToValidate="txtTelefono" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="El campo telefono es requerido"></asp:RequiredFieldValidator>
            </div>
         </div>

         
       <div class="form-group row">
        <div class="col-md-4">
        <label runat="server" style="font-size:large" id="Label2" for="">Estado</label>
        </div>
        <div class="col-md-8">
        <asp:DropDownList ID="ddlEstado" CssClass="form-control" Font-Size="Large" runat="server" AutoPostBack="true"></asp:DropDownList>
         </div>
        </div>

            <br /><br />
            <asp:Label ID="lblMensaje"  ForeColor="red" runat="server" Text=""></asp:Label>
             <br /><br />

            <asp:Button ID="btnAceptar" OnClientClick="return confirm('¿Desea realizar los cambios?');"  runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnAceptar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-success" OnClick="btnCancelar_Click" />

            <br /><br />
    </div>

    </div>


</asp:Content>
