<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="ProyectoRestaurante.Facturacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row divRedondear" style="background-color:white; padding-bottom:3%;">
        <div class="col-md-1"></div>
        <div class="col-md-10">
            <center>
                <br /><br />
                <asp:Label ID="lblFacturacion" style="font-size:large" runat="server" Text="Facturación" Font-Bold="True" Font-Size="Larger"></asp:Label>
            </center>

            <br /><br />
            <div class="row">
                <div class="col-md-10"></div>
                <div class="col-md-2">
                    <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <asp:GridView CssClass="mGrid" HeaderStyle-HorizontalAlign="Center"  ID="grvPedido" runat="server" AutoGenerateColumns="false" DataKeyNames="idDetallePedido" Width="100%">
                        <HeaderStyle Font-Size="Large"   BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
                    <Columns>
                    <asp:BoundField  DataField="producto.nombre" HeaderText="Producto" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" />
                    </Columns>
                </asp:GridView> 
                
                <br/><br/>
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-8"></div>
                            <div class="col-md-2">
                                <asp:Label ID="Label1" style="font-size:large" runat="server" Text="IV:" Font-Bold="False" Font-Size="Larger"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblIV" style="font-size:large" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8"></div>
                            <div class="col-md-2">
                                <asp:Label ID="Label2" style="font-size:large" runat="server" Text="Subtotal:" Font-Bold="False" Font-Size="Larger"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblSubtotal" style="font-size:large" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8"></div>
                            <div class="col-md-2">
                                <asp:Label ID="Label3" style="font-size:large" runat="server" Text="Total:" Font-Bold="False" Font-Size="Larger"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblTotal" style="font-size:large" runat="server" Text="" Font-Bold="True" Font-Size="Larger"></asp:Label>
                            </div>
                        </div>

                    </div>
                </div>

                <br/>

                <div class ="row">
                    <div class="col-md-4">
                        <div class="form-group row">
                            <label runat="server" style="font-size:large" id="Label5" for="">Nombre Cliente</label>
                            <asp:TextBox ID="txtNombreCliente" Font-Size="Large" runat="server" CssClass="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtNombreCliente" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Debe ingresar el nombre del cleiente"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                    
               <br/>

               <div class="row">
                    <div class="col-md-3">
                        <div class="form-group row">
                            <asp:Label ID="Label4" runat="server" Text="Tipo Pago"></asp:Label>
                            <asp:DropDownList ID="ddlTipoPago" runat="server" OnSelectedIndexChanged="ddlTipoPago_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" ></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-9"></div>
                </div>
                
                <br/><br/>



                
                


                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                                <div class="row">
                                    <div class="row">
                                        <asp:Label ID="lblEfectivo" runat="server" Text="Efectivo" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                        <br/><br/>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <asp:Label ID="lblCantidadPagadaEfectivo" runat="server" Text="Cantidad pagada efectivo ₡"></asp:Label>
                                                <asp:TextBox ID="txtCantidadPagadaEfectivo" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-8"></div>
                                    </div>
                                </div>
                                    
                                <br />
                            
                                <div class="row">
                                    <div class="row">
                                        <asp:Label ID="lblPagoTarjeta" runat="server" Text="Tarjeta" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                        <br/><br/>
                                    <div/>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <asp:Label ID="lblNumeroTarjeta" runat="server" Text="Número Tarjeta"></asp:Label>
                                                <asp:TextBox ID="txtNumeroTarjeta" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-1"></div>

                                        <div class="col-md-6">
                                            <div class="row">
                                                 <div class="col-md-4">
                                                     <br/>
                                                     <asp:Label ID="lblFechaVencimiento" runat="server" Text="Fecha vencimeinto"></asp:Label>
                                                 </div>
                                                  <div class="col-md-3">
                                                      <div class="form-group row">
                                                        <asp:Label ID="lblMesVencimiento" runat="server" Text="Mes"></asp:Label>
                                                        <asp:TextBox ID="txtMesVencimiento" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                      </div>
                                                  </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group row">
                                                        <asp:Label ID="lblAnno" runat="server" Text="Año"></asp:Label>
                                                        <asp:TextBox ID="txtAnno" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <asp:Label ID="lblCantidadPagadaTarjeta" runat="server" Text="Cantidad pagada con tarjeta ₡"></asp:Label>
                                            <asp:TextBox ID="txtCantidadPagadaTarjeta" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>



                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <asp:Label ID="lblMensajeError" runat="server" Text="" Font-Size="Large" ForeColor="#CC0000" Font-Bold="True"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                        </div>

                        <br/><br/>

                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-2">
                                <asp:Button ID="btnFacturar" OnClick="btnFacturar_Click"  runat="server" Text="Facturar" CssClass="btn btn-success" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click"  runat="server" Text="Cancelar" CssClass="btn btn-success" />
                            </div>
                            <div class="col-md-3"></div>
                        </div>
                </ContentTemplate>
                <Triggers>
	                <asp:AsyncPostBackTrigger ControlID="ddlTipoPago" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        <div class="col-md-1"></div>
    </div>
</asp:Content>
