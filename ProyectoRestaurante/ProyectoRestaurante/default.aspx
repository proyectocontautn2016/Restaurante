<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ProyectoRestaurante._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Restaurante</title>
    <script src="~/Scripts/jquery-3.0.0.js"></script>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="~/Scripts/bootstrap.js"></script>
</head>
<body>
    <form id="form" runat="server">  
        <div class="container" style="margin-top:15%">
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <div class="card-deck mb-3 text-center">
                        <div class="card mb-4 box-shadow">
                          <div class="card-header">
                            <h4 class="my-0 font-weight-normal">Restaurante Dalex</h4>
                          </div>
                          <div class="card-body">
                            <asp:TextBox ID="txtUsuario" CssClass="form-control input-sm chat-input" placeholder="Usuario" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtPassword" CssClass="form-control input-sm chat-input" placeholder="Contraseña" runat="server" TextMode="Password"></asp:TextBox>
                             <br/>
                              <div class="wrapper">
                                <span class="group-btn">     
                                    <asp:Button ID="login" runat="server" Text="Ingresar" CssClass="btn btn-primary pull-right"/>
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
