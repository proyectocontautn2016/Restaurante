<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="AgregarComanda.aspx.cs" Inherits="ProyectoRestaurante.AgregarComanda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid divRedondear" style="background-color:white">
        <div class="row">
            <center><h2>Modulo de Agragar Comanda</h2></center>
            <div class="col-md-1"></div>
            <div class="col-md-6">
                <br /><br />
                 
                <div class="form-group row">
                    <div class="col-md-4">
                    <label runat="server" style="font-size:large" id="Label1" for="">Número de mesa</label>
                    </div>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlMesas" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-md-5"></div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <h3>Productos</h3>
                <br/>
                <div id="idListadoProductos" runat="server">

                </div>
            </div>
        </div>

    </div>
</asp:Content>
