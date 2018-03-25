<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="disponibilidadMesas.aspx.cs" Inherits="ProyectoRestaurante.disponibilidadMesas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row divRedondear" style="background-color:white">
        <div class="col-md-10 divRedondear" style="background-color:#FFFFFF">
            <center><h2>Disponibilidad de Mesas del Restaurante</h2></center>
            
            <div id="idOrganizacionMesas" runat="server" style="margin-top:5%">

            </div>
        </div>
        <div class="col-md-2">
            <center><h2>Estados</h2></center>
            <br /><br />

            <div id="idEstadosMesas" runat="server">
            </div>
        </div>

    </div>
</asp:Content>
