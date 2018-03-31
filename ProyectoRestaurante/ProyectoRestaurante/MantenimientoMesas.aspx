<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="MantenimientoMesas.aspx.cs" Inherits="ProyectoRestaurante.MantenimientoMesas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12 divRedondear" style="background-color :white">
        
        <center><h2>Listado de Mesas del Restaurante</h2></center>

        <br /> <br />
                 <div>
                    <center><label runat="server" style="font-size:large" id="Label1" for="">Estado de la Mesa</label></center>
                     <br />
                     <center><asp:DropDownList ID="ddlEstadoMesa" Font-Size="Large" runat="server" CssClass="" OnSelectedIndexChanged="ddlEstadoMesa_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </center> <br />
                     <center>
                         <asp:Button ID="btnTodosEstados" runat="server" Text="Mostrar Todos"  OnClick="btnTodosEstados_Click" CssClass="btn btn-primary" /></center>
                     <br />
                     <center><asp:Button ID="btnAgregarMesa"  runat="server" Text="Agregar Mesa"  OnClick="btnAgregarMesa_Click" CssClass="btn btn-success" /></center>
                     <br />
                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <br /><br />
                            <asp:GridView CssClass="mGrid" HeaderStyle-HorizontalAlign="Center"  ID="grvListado" runat="server" AutoGenerateColumns="false" DataKeyNames="idMesa" Width="100%" OnRowCommand="grvListado_RowCommand">
                            <HeaderStyle Font-Size="Large"   BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
                            <Columns>
                            <asp:BoundField  DataField="idMesa" HeaderText="Número Mesa" />
                            <asp:BoundField DataField="cantidadPersonas" HeaderText="Cantidad Personas" />
                            <asp:BoundField DataField="estadoMesa.descripcion" HeaderText="Estado" />
                            <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                            <asp:Button ID="btnEditar" CssClass="btn btn-primary" runat="server" Text="Editar" CommandName="detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                            </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            </asp:GridView> 
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlEstadoMesa" EventName="SelectedIndexChanged" />
                             <asp:AsyncPostBackTrigger ControlID="btnTodosEstados" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>       
           
    </div>

</asp:Content>
