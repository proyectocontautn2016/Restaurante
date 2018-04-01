<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="FactImprimir.aspx.cs" Inherits="ProyectoRestaurante.FactImprimir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row divRedondear" style="background-color:white; padding-bottom:3%;">

        <div class="col-md-10" id="printarea">

            <style>
                 .mGrid {  
            width: 100%;  
            background-color: black;  
            margin: 5px 0 10px 0;  
            border: solid 1px #525252;  
            border-collapse: collapse;  
        }  
  
            .mGrid td {  
                padding: 2px;  
                border: solid 1px #c1c1c1;  
                color: black;  
                text-align:center;
                font-size:medium;
                font-weight:bold;
                background-color: #D8D8D8 
            }  
  
            .mGrid th {  
                padding: 4px 2px;  
                color: #fff;  
                background: #424242 url(grd_head.png) repeat-x top;  
                border-left: solid 1px #525252;  
                font-size: large;  
                text-align:center
            }  
  
            .mGrid .alt {  
                background: #fcfcfc url(grd_alt.png) repeat-x top;  
            }  
  
            .mGrid .pgr {  
                background: #424242 url(grd_pgr.png) repeat-x top;  
            }  
  
                .mGrid .pgr table {  
                    margin: 5px 0;  
                }  
  
                .mGrid .pgr td {  
                    border-width: 0;  
                    padding: 0 6px;  
                    border-left: solid 1px #666;  
                    font-weight: bold;  
                    color: #fff;  
                    line-height: 12px;  
                }  
  
                .mGrid .pgr a {  
                    color: #666;  
                    text-decoration: none;  
                }  
  
            .mGrid .pgr a:hover {  
                color: #000;  
                text-decoration: none;  
            }  
            </style>
            <center><h2>Factura</h2></center>

             <br />
                <div class="row">

                        <div class="offset-md-1 col-md-4" style="width:49%; height:190px; float:left; margin-left:1%">

                            <asp:Image ID="imgLogo" runat="server" ImageUrl="''" style="width:150px; height:150px; margin-top:20px; display: block;margin-left: auto;margin-right: auto;"/>
                        </div>

                        <div class="col-md-7" style="width:49%; height:160px;float:left; padding-top:30px">
                             <span style="font-size:18px; font-weight:bold ; margin-left:5%">Restaurante DALEX</span>
                            <br /><br />
                            <span style="font-size:18px; font-weight:bold ; margin-left:5%">Fecha:&nbsp; &nbsp;<asp:Label ID="lblFecha" runat="server" Text=""></asp:Label></span>
                            <br /><br />
                             <span style="font-size:18px; font-weight:bold ; margin-left:5%">Numero Factura:&nbsp; &nbsp;<asp:Label ID="lblIdFactura" runat="server" Text=""></asp:Label></span>
                        </div>

                </div>

                <br /><br />
                <div class="row">
                    <div class="col-md-3" style="width:49%; height:50px; float:left; margin-left:1%; padding-top:10px">
                         <span style="font-size:18px; font-weight:bold ; margin-left:50%">Nombre:</span></div>
                     <div class="col-md-8" style="width:49%; height:50px;float:left; padding-top:10px">  <asp:Label style="font-size:18px; font-weight:bold" ID="lblNombre" runat="server" Text=""></asp:Label></div>
          
                </div>
                <div class="row">
                    <br /><br />
                     

                    <div class="col-md-10" style="width:90%; height:250px; float:left; margin-left:5%; padding-top:10px">
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
                    
                                    
                                        
                                        <div style="width:23%; height:30px; float:left; margin-left:52%; padding-top:10px" >
                                            <asp:Label ID="Label1" style="font-size:18px; font-weight:bold ; margin-left:30%" runat="server" Text="IV:"></asp:Label>
                                        </div>
                                        <div style="width:23%; height:30px; float:left; margin-left:1%; padding-top:10px">
                                            <asp:Label ID="lblIV"  runat="server" Text="" style="font-size:18px; font-weight:bold; margin-left:45%"></asp:Label>
                                        </div>
                                    
                                    
                                   
                                        <div style="width:23%; height:30px; float:left; margin-left:52%; padding-top:10px">
                                           <asp:Label ID="Label2" style="font-size:18px; font-weight:bold ; margin-left:30%" runat="server" Text="Subtotal:"></asp:Label>
                                        </div>
                                        <div style="width:23%; height:30px; float:left; margin-left:1%; padding-top:10px" >
                                            <asp:Label ID="lblSubtotal" runat="server" Text="" style="font-size:18px; font-weight:bold; margin-left:45%"></asp:Label>
                                        </div>
                                  
                                  
                                        <div style="width:23%; height:30px; float:left; margin-left:52%; padding-top:10px" >
                                            <asp:Label ID="Label3" runat="server" Text="Total:" style="font-size:18px; font-weight:bold ; margin-left:30%"></asp:Label>
                                        </div>
                                        <div style="width:23%; height:30px; float:left; margin-left:1%; padding-top:10px" >
                                            <asp:Label ID="lblTotal" runat="server" Text="" style="font-size:18px; font-weight:bold; margin-left:45%"></asp:Label>
                                        </div>
                               
                         </div>

                    </div>
         
                
            

              </div>

    </div>


        <div class="col-md-2" style="margin-top:200px">

                 <button onclick="PrintDoc()" class="btn btn-success" style="width:120px">Imprimir PDF</button>
            <br /><br /><br /><br />
                <asp:Button ID="btnCorreo" runat="server" style="width:120px" Text="Enviar Correo" CssClass="btn btn-success" OnClick="btnCorreo_Click" />
                 <br /><br /><br /><br />
                <asp:Button ID="btnFinalizar" runat="server" style="width:120px" Text="Finalizar" CssClass="btn btn-success" OnClick="btnFinalizar_Click" />
            </div>

    </div>

<script>
    function PrintDoc() {

        var toPrint = document.getElementById('printarea');

        var popupWin = window.open('', '_blank', 'width=650px,height=550px,location=no,left=200px');

        popupWin.document.open();

       popupWin.document.write('<html><title>Factura N </title><link rel="stylesheet" type="text/css" href="print.css" /></head><body onload="window.print()">')

        popupWin.document.write(toPrint.innerHTML);

        popupWin.document.write('</html>');

        popupWin.document.close();

    }
</script>

</asp:Content>
