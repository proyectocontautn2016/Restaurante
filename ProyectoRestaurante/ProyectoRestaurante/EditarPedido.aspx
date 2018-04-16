<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="EditarPedido.aspx.cs" Inherits="ProyectoRestaurante.EditarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="container-fluid divRedondear" style="background-color:white">
         
        
        <div class="col-md-offset-1 col-md-10">


            <center><h2>Modulo Para Editar Pedido</h2></center>

        <br /><br />

              <div class="form-group row">
            <div class="col-md-5">
                <asp:Image ID="imagenProducto" runat="server" ImageUrl="''" Height="200px" Width="200px" />
            </div>
            <div class="col-md-7">

                 <asp:TextBox ID="txtNombreProducto" Font-Size="Large" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="registrar" ControlToValidate="txtNombreProducto" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="El campo nombre es requerido"></asp:RequiredFieldValidator>
                <br /><br />
            </div>
         </div>

 
          <div class="form-group row">
            <div class="col-md-4">
                <label runat="server" style="font-size:large" id="Label4" for="">Cantidad</label>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtCantidad" TextMode="Number" Font-Size="Large" runat="server" CssClass="form-control" OnTextChanged="txtCantidad_TextChanged" AutoPostBack="true" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="registrar" ControlToValidate="txtCantidad" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="La cantidad es requerido"></asp:RequiredFieldValidator>
            </div>
         </div>

             <div class="form-group row">
            <div class="col-md-4">
                <label runat="server" style="font-size:large" id="Label1" for="">Precio</label>
            </div>
            <div class="col-md-8">

                      <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                             <asp:TextBox ID="txtPrecio" Font-Size="Large" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txtCantidad" EventName="TextChanged" /> 
                        </Triggers>
                    </asp:UpdatePanel>
                
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


        <div class="form-group row">
            <div class="col-md-4">
                <label runat="server" style="font-size:large" id="lblComentario" for="">Descripcion</label>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtComentario" TextMode="MultiLine" Height="200px" Font-Size="Large" runat="server" CssClass="form-control"></asp:TextBox>
       
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
