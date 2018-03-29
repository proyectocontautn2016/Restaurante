<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="AgregarComanda.aspx.cs" Inherits="ProyectoRestaurante.AgregarComanda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid divRedondear" style="background-color:white">
        <div class="row">
            <center><h2>Modulo de Agregar Comanda</h2></center>
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <br /><br />
                 
                <div class="form-group row">
                    <div class="col-md-4">
                    <label runat="server" style="font-size:large" id="Label1" for="">Número de mesa</label>
                    </div>
                    <div class="col-md-8">            
                        <asp:TextBox ID="txtMesa" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-md-5"></div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <center><h3>Productos</h3></center>
                <br/>
                <center>
                    <label runat="server" id="Label3" style="font-size:large" for="">Listar productos por</label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlTipoProducto" Font-Size="Large" OnSelectedIndexChanged="ddlTipoProducto_SelectedIndexChanged1" runat="server" AutoPostBack="true"></asp:DropDownList>
                </center>
                <br/>
                <div id="idListadoProductos" runat="server">

                </div>
            </div>
        </div>
    </div>
</asp:Content>
