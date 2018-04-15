<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="accionMesa.aspx.cs" Inherits="ProyectoRestaurante.accionMesa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row divRedondear" style="background-color:white">
        <div class="row">
            <div class="col-md-8">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <center>
                        <br /><br />
                        <asp:Label ID="lblNumeroMesa" style="font-size:large" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
                    </center>

                    <div class="form-group row" style="margin-top:10%">
                        <asp:Label ID="Label5" runat="server" Text="Mesa número"  style="font-size:large"></asp:Label>
                        <asp:textbox id="txtMesaId" Font-Size="Large" runat="server" ReadOnly="True" CssClass="form-control"></asp:textbox>                
                    </div>
            
                    <div class="form-group row">
                        <asp:Label ID="Label1" runat="server" Text="Cantidad de personas"  style="font-size:large"></asp:Label>
                        <asp:textbox id="txtCantidadPersonas" Font-Size="Large" runat="server" ReadOnly="True" CssClass="form-control"></asp:textbox>
                    </div>

                     <div class="form-group row">
                        <asp:Label ID="Label2" runat="server" Text="Estado"  style="font-size:large"></asp:Label>
                        <asp:textbox id="txtEstado" Font-Size="Large" runat="server" ReadOnly="True" CssClass="form-control"></asp:textbox>
                    </div>

                    <div class="form-group row">
                        <asp:Label ID="Label4" runat="server" Text="Usuario asignada a mesa"  style="font-size:large"></asp:Label>
                        <asp:textbox id="txtUsuarioAsignado" Font-Size="Large" runat="server" ReadOnly="True" CssClass="form-control"></asp:textbox>
                    </div>
                </div>
                <div class="col-md-2"></div>
            </div>

            <div class="col-md-4">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <center>
                        <br><bre>
                        <asp:Label ID="Label3" runat="server"  style="font-size:large" Text="Acción" Font-Bold="True" Font-Size="Larger"></asp:Label>
                    </center>
                    <div class="form-group row" style="margin-top:10%">
                        <asp:DropDownList ID="ddlAccionMesa"  style="font-size:large" runat="server" OnSelectedIndexChanged="ddlAccionMesa_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group row">
                        <asp:Image ID="imgEstadoMesa" runat="server" height="180px" width="180px" />
                    </div>
                </div>
                <div class="col-md-2"></div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-1"></div>

            <div class="col-md-10">
               

                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        <asp:Button ID="btnAgregarProducto" OnClick="btnAgregarProducto_Click" runat="server" Text="Agregar Producto" CssClass="btn btn-success" />
                    </div>
                    <div class="col-md-4"></div>
                </div>
                <br /><br />
                 <asp:GridView CssClass="mGrid" HeaderStyle-HorizontalAlign="Center"  ID="grvPedido" runat="server" AutoGenerateColumns="false" DataKeyNames="idDetallePedido" Width="100%" OnRowCommand="grvPedido_RowCommand">
                                <HeaderStyle Font-Size="Large"   BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
                            <Columns>
                            <asp:BoundField  DataField="producto.nombre" HeaderText="Producto" />
                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="precio" HeaderText="Precio" />
                            <asp:BoundField DataField="comentario" HeaderText="Comentario" />
                            <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                            <asp:Button ID="btnEditar" CssClass="btn btn-primary" runat="server" Text="Editar" CommandName="detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                            </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            </asp:GridView> 


            </div>

            <div class="col-md-1"></div>
        </div>
        <br/><br/><br/>
    </div>
</asp:Content>
