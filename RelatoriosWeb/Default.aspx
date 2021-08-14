<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RelatoriosWeb.Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
    <link href="static/css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="static/javascript/bootstrap.min.js"></script>
    <script src="static/javascript/jquery.min.js"></script>
</head>
<body>
    <div id="login">
        <h3 class="text-center text-white pt-5">Page Login</h3>
        <div class="container">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-box" class="col-md-12">
                        <form id="loginform" class="form" runat="server">
                            <h3 class="text-center text-dark">Login</h3>
                            <div class="form-group">
                                <label for="username" class="text-dark">Usuario:</label><br>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" MaxLength="15" placeholder="Digite o Usuario..."></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="password" class="text-dark">Senha:</label><br>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" MaxLength="10" placeholder="Digite a Senha..."></asp:TextBox>                               
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnLogin" runat="server" Text="Entrar" CssClass="btn btn-success btn-md" OnClick="btnLogin_Click1" />
                            </div>
                            <div>
                                <asp:Label ID="txtErro" runat="server"></asp:Label>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
