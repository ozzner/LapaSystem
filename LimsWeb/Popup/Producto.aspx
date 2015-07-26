<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="LimsWeb.Popups.PupUpProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        
      <asp:TextBox ID="txtProductoID" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>



           <asp:Button runat="server" class="btn btn-primary btn-sm" ID="btnGuardar" Text="Guardar"/>
            <asp:Button runat="server" class="btn btn-primary btn-sm" ID="btnCancelar" Text="Cancelar"/>

    </div>
    </form>
</body>
</html>
