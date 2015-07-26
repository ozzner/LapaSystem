<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vVistaGraficos.aspx.cs" Inherits="LimsWeb.iAdministrador.vVistaGraficos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
    <title>Vista Gráficos</title>
</head>
<body style="background: #eee">
    <form id="form1" runat="server">
        <div style="background: none; padding: 20px">

            <div style="border-bottom: 1px solid gray; margin-bottom: 5px; margin-top: 0px; text-align: Center">
                <asp:Label runat="server" Text="Seleccione los parámetros que desee mostrar:" Font-Size="Large"></asp:Label>
            </div>
            <div>
                Seleccione 4 parámetros que serán mostrados en la pantalla principal. Si elige más, sólo se guardarán los 4 primeros.
            </div>
            

            <div style="background: none; height:320px;width:200px;margin:4px auto 4px auto; overflow-y:scroll">
                <asp:Repeater ID="rParametros" runat="server" OnItemDataBound="rpt_ItemDataBound">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chk" Text='<%#Eval("NomParametro") %>' />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <asp:Button runat="server" ID="btnGuardarCambios" Text="Guardar Cambios" CssClass="btn btn-primary" Width="100%" OnClick="btnGuardarCambios_Click" />
        </div>
    </form>
</body>
</html>
