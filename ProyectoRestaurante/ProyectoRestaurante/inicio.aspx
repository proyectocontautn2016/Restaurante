<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="ProyectoRestaurante.inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="col-md-12 divRedondear" style="background-color:#F3E2A9">

        <br /><br />
        <center><asp:Label ID="lblTitulo" Font-Size="50px" ForeColor="Red" runat="server" Text=""></asp:Label></center>

        <br /><br />
        <center><asp:Image ID="imgLogo" runat="server" ImageUrl="''" Height="600px" Width="600px" /></center>
         <br /><br />

        
         <center><asp:Label ID="lblDireccion" Font-Size="X-Large" ForeColor="Black" runat="server" Text=""></asp:Label></center>

        <br />

         
          <center><asp:Label ID="lblTelefono" Font-Size="X-Large" ForeColor="Black" runat="server" Text=""></asp:Label></center>

        <br /><br />
    </div>

</asp:Content>
