<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ProyectoRestaurante._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Restaurante</title>
    <script src="~/Scripts/jquery-3.0.0.js"></script>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="~/Scripts/bootstrap.js"></script>
</head>
<body style="background-image:url(img/infoRestaurante/restaurante.jpg); background-repeat:no-repeat; background-size:cover">
    <form id="form" runat="server">  
        <div class="container" style="margin-top:15%">
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <div class="card-deck mb-3 text-center">
                        <div class="card mb-4 box-shadow">
                          <div class="card-header" style="background-color:blue">
                            <h4 class="my-0 font-weight-normal" style="color:white">Restaurante Dalex</h4>
                          </div>
                          <div class="card-body">
                            <asp:TextBox ID="txtUsuario" CssClass="form-control input-sm chat-input" placeholder="Usuario" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUsuario" ForeColor="Red" Display="Dynamic" runat="server" ValidationGroup="ingresar" ErrorMessage="El campo nombre de usuario es requerido"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtPassword" CssClass="form-control input-sm chat-input" placeholder="Contraseña" runat="server" TextMode="Password"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword" ForeColor="Red" Display="Dynamic" ValidationGroup="ingresar" runat="server" ErrorMessage="El campo contraseña es requerido"></asp:RequiredFieldValidator>
                              <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="red"></asp:Label>
                             <br/>
                              <div class="wrapper">
                                <span class="group-btn">     
                                    <asp:Button ID="login" ValidationGroup="ingresar" runat="server" Text="Ingresar" OnClick="login_Click" CssClass="btn btn-primary pull-right"/>&nbsp;&nbsp;
                                    <asp:Button ID="cancelar" runat="server" Text="Cancelar" OnClick="cancelar_Click" CssClass="btn btn-primary pull-right"/>
                                </span>
                             </div>
                          </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
