<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="accionMesa.aspx.cs" Inherits="ProyectoRestaurante.accionMesa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="background-color:white">
        <div class="col-md-2"></div>
        <div class="col-md-4">
            <asp:Label ID="lblNumeroMesa" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>

            <div class="form-group row" style="margin-top:10%">
                <asp:Label ID="Label5" runat="server" Text="Mesa número"></asp:Label>
                <asp:textbox id="txtMesaId" runat="server" ReadOnly="True" CssClass="form-control"></asp:textbox>
            </div>
        </div>
        <div class="col-md-6"></div>
    </div>
</asp:Content>
