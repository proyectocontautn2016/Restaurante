<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="seleccionarProducto.aspx.cs" Inherits="ProyectoRestaurante.seleccionarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid divRedondear" style="background-color:white">
        <div class="col-md-12">
            <center>
                <h2 id="idNombreProducto" runat="server"></h2>
                <asp:image id="imgImagenProducto" runat="server" height="200px" width="200px"></asp:image>
                <br/>
                <asp:label id="lblPrecioProducto" runat="server" text=""></asp:label>
                <br/><br/>
             </center>
             <div class="row">
                 <div class="col-md-4"></div>
                <div class="col-md-4">
                     <div class="form-group row">
                        <label runat="server" id="Label1" for="">Cantidad</label>
                         <asp:TextBox ID="txtCantidad" Font-Size="Large"  TextMode="Number"  runat="server" CssClass="form-control"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  ControlToValidate="txtCantidad" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="El campo cantidad es requerido"></asp:RequiredFieldValidator>
                         <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtCantidad" ForeColor="Red" ErrorMessage="" Display="Dynamic" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                         <asp:Label ID="lblMensaje"  ForeColor="red" runat="server" Text=""></asp:Label>
                     </div> 
                    <div class="form-group row">
                        <label runat="server" id="Label2" for="">Comentarios</label>
                         <asp:textbox id="txtComentario" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:textbox>
                    </div> 

                    <center>
                        <div class="form-group row">
                            <asp:Button ID="btnAgregarProducto" OnClick="btnAgregarProducto_Click"  runat="server" Text="Agregar" CssClass="btn btn-success" />
                        </div>
                    </center>
                </div>
                <div class="col-md-4"></div>
              </div>
                <asp:HiddenField ID="hdfIdProducto" runat="server"></asp:HiddenField>
        </div>
    </div>
</asp:Content>
