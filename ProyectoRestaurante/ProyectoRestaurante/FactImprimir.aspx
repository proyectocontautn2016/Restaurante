<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="FactImprimir.aspx.cs" Inherits="ProyectoRestaurante.FactImprimir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row divRedondear" style="background-color:white; padding-bottom:3%;">

        <div class="col-md-10">
            <center><h2>Factura</h2></center>

             <br />
                <div class="row">

                        <div class="offset-md-1 col-md-4" style="height:200px">

                            <asp:Image ID="imgLogo" runat="server" ImageUrl="''" Height="150px" Width="150px" style="margin-left:40%"  />
                        </div>

                        <div class="col-md-7" style="height:200px">
                             <span style="font-size:18px; font-weight:bold ; margin-left:15%">Restaurante DALEX</span>
                            <br /><br />
                            <span style="font-size:18px; font-weight:bold; margin-left:15%">Fecha:&nbsp; &nbsp;<asp:Label ID="lblFecha" runat="server" Text=""></asp:Label></span>
                            <br /><br />
                             <span style="font-size:18px; font-weight:bold ; margin-left:15%">Numero Factura:&nbsp; &nbsp;<asp:Label ID="lblIdFactura" runat="server" Text=""></asp:Label></span>
                        </div>

                </div>

                <br /><br />
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3"> <span style="font-size:18px; font-weight:bold" >Nombre:</span></div>
                     <div class="col-md-8">  <asp:Label Font-Size="18px" ID="lblNombre" runat="server" Text=""></asp:Label></div>
          
                </div>
                <div class="row">
                    <br /><br />
                     <div class="col-md-1"></div>

                    <div class="col-md-10">
                         <asp:GridView CssClass="mGrid" HeaderStyle-HorizontalAlign="Center"  ID="grvPedido" runat="server" AutoGenerateColumns="false" DataKeyNames="idDetallePedido" Width="100%">
                                    <HeaderStyle Font-Size="Large"   BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                    <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
                                <Columns>
                                <asp:BoundField  DataField="producto.nombre" HeaderText="Producto" />
                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="precio" HeaderText="Precio" />
                                </Columns>
                            </asp:GridView> 
                        <div class="row">
                    
                                    <div class="row">
                                        <div class="col-md-8"></div>
                                        <div class="col-md-2" >
                                            <asp:Label ID="Label1" style="font-size:large" runat="server" Text="IV:" Font-Bold="False" Font-Size="Larger"></asp:Label>
                                        </div>
                                        <div class="col-md-2" >
                                            <asp:Label ID="lblIV" style="font-size:large" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-8"></div>
                                        <div class="col-md-2" >
                                            <asp:Label ID="Label2" style="font-size:large" runat="server" Text="Subtotal:" Font-Bold="False" Font-Size="Larger"></asp:Label>
                                        </div>
                                        <div class="col-md-2" >
                                            <asp:Label ID="lblSubtotal" style="font-size:large" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-8"></div>
                                        <div class="col-md-2" >
                                            <asp:Label ID="Label3" style="font-size:large" runat="server" Text="Total:" Font-Bold="False" Font-Size="Larger"></asp:Label>
                                        </div>
                                        <div class="col-md-2" >
                                            <asp:Label ID="lblTotal" style="font-size:large" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                        </div>
                                </div>
                         </div>

                    </div>
         
                
            

              </div>

    </div>


        <div class="col-md-2" style="margin-top:200px">

                 <asp:Button ID="btnImprimir" style="width:120px"  runat="server" Text="Imprimir" CssClass="btn btn-success" OnClick="btnImprimir_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <br /><br /><br /><br />
                <asp:Button ID="btnCorreo" runat="server" style="width:120px" Text="Enviar Correo" CssClass="btn btn-success" OnClick="btnCorreo_Click" />
                 <br /><br /><br /><br />
                <asp:Button ID="btnFinalizar" runat="server" style="width:120px" Text="Finalizar" CssClass="btn btn-success" OnClick="btnFinalizar_Click" />
            </div>

    </div>

</asp:Content>
