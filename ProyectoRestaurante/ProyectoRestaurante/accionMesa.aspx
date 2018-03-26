<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="accionMesa.aspx.cs" Inherits="ProyectoRestaurante.accionMesa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row divRedondear" style="background-color:white">
        <div class="col-md-8">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <center>
                    <br><bre>
                    <asp:Label ID="lblNumeroMesa" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
                </center>

                <div class="form-group row" style="margin-top:10%">
                    <asp:Label ID="Label5" runat="server" Text="Mesa número"></asp:Label>
                    <asp:textbox id="txtMesaId" runat="server" ReadOnly="True" CssClass="form-control"></asp:textbox>                
                </div>
            
                <div class="form-group row">
                    <asp:Label ID="Label1" runat="server" Text="Cantidad de personas"></asp:Label>
                    <asp:textbox id="txtCantidadPersonas" runat="server" ReadOnly="True" CssClass="form-control"></asp:textbox>
                </div>

                 <div class="form-group row">
                    <asp:Label ID="Label2" runat="server" Text="Estado"></asp:Label>
                    <asp:textbox id="txtEstado" runat="server" ReadOnly="True" CssClass="form-control"></asp:textbox>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>

        <div class="col-md-4">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <center>
                    <br><bre>
                    <asp:Label ID="Label3" runat="server" Text="Acción" Font-Bold="True" Font-Size="Larger"></asp:Label>
                </center>
                <div class="form-group row" style="margin-top:10%">
                    <asp:DropDownList ID="ddlAccionMesa" runat="server" OnSelectedIndexChanged="ddlAccionMesa_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group row">
                    <asp:Image ID="imgEstadoMesa" runat="server" height="180px" width="180px" />
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
    </div>
</asp:Content>
