<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="ReporteVentasporUsuario.aspx.cs" Inherits="ProyectoRestaurante.ReporteVentasporUsuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row divRedondear" style="background-color:white; padding-bottom:3%;">

        <div class="col-md-10" id="printarea">

            <style>
                 table {
    font-family: arial, sans-serif;
    border-collapse: collapse;
    width: 100%;
	}

	th {
    border: 1px solid black;
    text-align: center;
    padding: 8px;
    background-color: black;
    color:white;
	}

	td {
    border: 1px solid black;
    text-align: center;
    padding: 8px;

	}

	tr:nth-child(even) {
	    background-color: #BDBDBD;
	}
            </style>
            <center><h3>Reporte de Ventas por Usuario</h3></center>

             <br />
                <div class="row">

                        <div class="offset-md-1 col-md-4" style="width:49%; height:140px; float:left; margin-left:1%">

                            <asp:Image ID="imgLogo" runat="server" ImageUrl="''" style="width:140px; height:140px; margin-top:20px; display: block;margin-left: auto;margin-right: auto;"/>
                        </div>

                        <div class="col-md-7" style="width:49%; height:140px;float:left; padding-top:30px">
                             <span style="font-size:18px; font-weight:bold ; margin-left:5%">Restaurante DALEX</span>
                            <br /><br />
                            <span style="font-size:18px; font-weight:bold ; margin-left:5%">Fecha:&nbsp; &nbsp;<asp:Label ID="lblFecha" runat="server" Text=""></asp:Label></span>
                        </div>

                </div>
             
                <div class="row">
                    <br />
                     

                    <div class="col-md-10" style="width:90%; float:left; margin-left:5%; padding-top:10px">


                                      
                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <br /><br />
                            <asp:GridView CssClass="mGrid" HeaderStyle-HorizontalAlign="Center"  ID="grvListado" runat="server" AutoGenerateColumns="false" Width="100%">
                                <HeaderStyle Font-Size="Large"   BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
                            <Columns>
                            <asp:BoundField DataField="idEncabezadoFactura" HeaderText="N Factura" />
                            <asp:BoundField  DataField="fecha" HeaderText="Fecha" />
                            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                           <asp:BoundField DataField="IV" HeaderText="IVA" />
                                <asp:BoundField DataField="Total" HeaderText="Total" />
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
         
                        </ContentTemplate>
                        <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="txtBusqueda" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>


                    </div>

                    

              </div>

    </div>


        <div class="col-md-2" style="margin-top:60px">

            <center><span style="font-size:18px; font-weight:bold">Fecha Inicial</span> <br /><br /><asp:TextBox ID="txtFechaInicial" runat="server"> </asp:TextBox>
                       <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaInicial" Format="dd/MM/yyyy" PopupButtonID="imgPopup"></ajaxToolkit:CalendarExtender>
                    </center> <br /><br />
                      <center><span style="font-size:18px; font-weight:bold">Fecha Final</span> <br /><br /><asp:TextBox ID="txtFechaFinal" runat="server"></asp:TextBox>
                       <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaFinal" Format="dd/MM/yyyy" PopupButtonID="imgPopup"></ajaxToolkit:CalendarExtender>
                    </center> <br /><br />

                         <center>
                         <asp:Button ID="txtBusqueda" runat="server" Text="Buscar" style="width:120px"  OnClick="txtBusqueda_Click" CssClass="btn btn-primary" /></center>
             <br /><br /><br />
                 <center> <button onclick="PrintDoc()" class="btn btn-success" style="width:120px">Imprimir PDF</button></center>
            <br /><br /><br />
                <center> <asp:Button ID="btnFinalizar" runat="server" style="width:120px" Text="Finalizar" CssClass="btn btn-success" OnClick="btnFinalizar_Click" /></center>
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
