<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="AgregarMesa.aspx.cs" Inherits="ProyectoRestaurante.AgregarMesa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid divRedondear" style="background-color:white">
        <div class="col-md-offset-1 col-md-10">


            <center><h2>Modulo de Agragar de Mesas</h2></center>

        <br /><br />


     
        <div class="form-group row">
        <div class="col-md-4">
        <label runat="server" style="font-size:large" id="Label1" for="">Cantidad de personas</label>
        </div>
        <div class="col-md-8">
        <asp:TextBox ID="txtCantidad" Font-Size="Large"  TextMode="Number"  runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="registrar"  ControlToValidate="txtCantidad" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="El campo cantidad es requerido"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="cumCantidad" runat="server" ErrorMessage="La cantidad debe estar entre 1 y 12 personas" ControlToValidate="txtCantidad" OnServerValidate="cumCantidad_ServerValidate"></asp:CustomValidator>
         </div>
        </div>

         <div class="form-group row">
        <div class="col-md-4">
        <label runat="server" style="font-size:large" id="Label2" for="">Estado</label>
        </div>
        <div class="col-md-8">
        <asp:DropDownList ID="ddlEstadoMesa" Font-Size="Large" runat="server" AutoPostBack="true"></asp:DropDownList>
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
