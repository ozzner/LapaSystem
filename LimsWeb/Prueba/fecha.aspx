<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fecha.aspx.cs" Inherits="LimsWeb.Prueba.fecha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Fecha</title>
    <script src="jquery-ui-1.11.2.custom/jquery-ui.js"></script>
    <link href="jquery-ui-1.11.2.custom/jquery-ui.css" rel="stylesheet" />
    <link href="jquery-ui-1.11.2.custom/jquery-ui.min.css" rel="stylesheet" />
    <script src="jquery-ui-1.11.2.custom/jquery-ui.min.js"></script>

    <script>
        $(function () {
            $("#txtFecha").datepicker();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Fecha :
            <asp:TextBox runat="server" ID="txtFecha"></asp:TextBox>
        </div>


    </form>
</body>
</html>
