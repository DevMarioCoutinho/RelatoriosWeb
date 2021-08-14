<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RelatorioVenda.aspx.cs" Inherits="RelatoriosWeb.View.RelatorioVenda" %>

<!DOCTYPE html>
<html>
<head>
    <title>Relatorio de Venda</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
        <a class="navbar-brand">Relatorio Web</a>
        <ul class="navbar-nav">
            <li class="nav-item">
                <a class="nav-link disabled">Inicio</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/">Sair</a>
            </li>
        </ul>
    </nav>
    <form runat="server">
        <div class="text-center text-white pt-5">
            <asp:Button runat="server" ID="btnGerar" Text="Gerar Relatorio Excel" CssClass="btn btn-success btn-md" OnClick="btnGerar_Click"/>
        </div>
    </form>
</body>
</html>

