<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Atributo.aspx.cs" Inherits="LimsWeb.Atributo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/css/EstilosPopup.css" rel="stylesheet" />


</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="gvAtributo" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="gvCabecera"   CssClass="gvGeneral" RowStyle-CssClass ="gvFilas">
            <Columns>                
                <asp:BoundField DataField="AtributoID" HeaderText="ID">
                    <ItemStyle Width="50px" />
                </asp:BoundField>

                <asp:BoundField DataField="NomAtributo" HeaderText="Nombre" > <ItemStyle Width="200px" /> </asp:BoundField>
                <asp:BoundField DataField="UsuarioID" HeaderText="UsuarioID" > <ItemStyle Width="50px" /> </asp:BoundField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
