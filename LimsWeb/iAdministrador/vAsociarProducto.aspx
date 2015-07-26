<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vAsociarProducto.aspx.cs" Inherits="LimsWeb.iAdministrador.vAsociarProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
        <script src="../Content/js/jquery-1.8.2.js"></script>
    <script src="../Content/js/bootstrap.min.js"></script>
    <link href="../Content/css/EstilosPopup.css" rel="stylesheet" />
    <script src="../Content/js/validaciones.js"></script>
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />


     <script>
           $(document).ready(function () {
               window.opener.location.reload();
           });

    </script>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Productos</title>
</head>
<body style="background:#eee">
    <form id="form1" runat="server">
        <div class="titulo"  style="  border-bottom:1px solid blue;
                                      padding-top:20px;
                                      padding-bottom:4px;
                                      padding-left:10px; 
                                      width:98%;
                                      margin:auto;">
            <asp:label id="lblLaboratorio" text ="[Laboratorio]" style="font-family:Verdana;font-size:14px;" runat="server"></asp:label>
        </div>
    
        <div style="background:none; width:468px;margin:20px auto; ">
            <asp:label runat="server" style="display:inline-block;" ID="lbl01"  Text="TODOS LOS PRODUCTOS"></asp:label>
            <asp:label runat="server" style="display:inline-block; float:right; margin-right:115px" ID="Lbl02" Text="AGREGADOS"></asp:label><br />

            <asp:ListBox ID="lbProductos" CssClass="listBox" Height="350px" Width="200px" runat="server" AutoPostBack="false"></asp:ListBox>
            <asp:ListBox ID="lbAgregados" CssClass="listBox" style="float:right;" Height="350px" Width="200px" runat="server"></asp:ListBox>
            <div style="width:60px; height:100px; background:none; display:inline-block; float:right; margin-right:4px;margin-top:100px;">

                <asp:ImageButton ID="btnAgregar"  runat="server" ImageUrl="~/Content/img/derecha.png" Width="60px" OnClick="btnAgregar_Click" />
                <asp:ImageButton ID="btnQuitar" runat="server" ImageUrl="~/Content/img/izquierda.png" Width="60px" OnClick="btnQuitar_Click" OnClientClick="javascript:return confirm('¿Está seguro que desea quitar el producto de este laboratorio?');" />
            </div>
        </div>
    </form>
</body>
</html>