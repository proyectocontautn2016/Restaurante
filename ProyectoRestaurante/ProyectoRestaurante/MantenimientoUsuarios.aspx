<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="MantenimientoUsuarios.aspx.cs" Inherits="ProyectoRestaurante.MantenimientoUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-md-12 divRedondear" style="background-color :white">
       
        <center><h2>Listado de Usuarios del Restaurante</h2></center>

        <br /> <br />
                 <div>
                    <center><label runat="server" style="font-size:large" id="Label1" for="">Estado del Usuario</label></center>
                     <br />
                     <center><asp:DropDownList ID="ddlEstado" Font-Size="Large" runat="server" CssClass="" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </center> <br />
                     <center><asp:DropDownList ID="ddlRol" Font-Size="Large" runat="server" CssClass="" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </center> <br />
                     <center>
                         <asp:Button ID="btnTodosEstados" runat="server" Text="Mostrar Todos"  OnClick="btnTodosEstados_Click" CssClass="btn btn-primary" /></center>
                     <br />
                     <center><asp:Button ID="btnAgregarUsuario"  runat="server" Text="Agregar Usuario"  OnClick="btnAgregarUsuario_Click" CssClass="btn btn-success" /></center>
                     <br />
                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <br /><br />
                            <asp:GridView CssClass="mGrid" HeaderStyle-HorizontalAlign="Center"  ID="grvListado" runat="server" AutoGenerateColumns="false" DataKeyNames="idUsuario" Width="100%" OnRowCommand="grvListado_RowCommand">
                            <HeaderStyle Font-Size="Large"   BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
                            <Columns>
                            <asp:BoundField  DataField="idUsuario" HeaderText="Identificación" />
                            <asp:BoundField DataField="rol.descripcion" HeaderText="Rol" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                             <asp:BoundField DataField="email" HeaderText="Email" />
                             <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                            <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                            <asp:Button ID="btnEditar" CssClass="btn btn-primary" runat="server" Text="Editar" CommandName="detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                            </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            </asp:GridView> 
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlEstado" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlRol" EventName="SelectedIndexChanged" />
                             <asp:AsyncPostBackTrigger ControlID="btnTodosEstados" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>       
           
    </div>


</asp:Content>
