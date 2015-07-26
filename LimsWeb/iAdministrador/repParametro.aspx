<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Administrador.Master" AutoEventWireup="true" CodeBehind="repParametro.aspx.cs" Inherits="LimsWeb.iAdministrador.repParametro" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
<%--    <script src="../Content/js/bootstrap.js"></script>
  
    <script src="../Content/js/jquery-1.10.2.js"></script>--%>
    <%--<script src="../Content/js/jquery-ui-1.10.4.min.js"></script>--%>
    <%--<link href="../Content/css/bootstrap.css" rel="stylesheet" />--%>
<%--    <link href="../Content/css/jquery-ui.css" rel="stylesheet" />
      <script src="../Content/js/jquery-ui-1.10.4.js"></script>--%>


    <script>
        function irConfigAttr(url) {
            window.open(url, 'ventana1', 'top=0,left=300,height=510,width=1000,scrollbars=1,resizable=1,location=no');
        }

        function irConfig(url) {
            window.open(url, 'ventana22', 'top=0,left=300,height=510,width=1000,scrollbars=1,resizable=1,location=no');
        }

        function irNuevaMuestra(url) {
            window.open(url, 'ventana33', 'top=0,left=300,height=490,width=550,scrollbars=1,resizable=1,location=no');
        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdministrador" runat="server">

     <script type="text/javascript">
         $(function () {
             $('#cphAdministrador_txtFecInicio').datepicker();
             $('#cphAdministrador_txtFecFin').datepicker();
         });
    </script>



    <div class="titulo" style="border-bottom: 1px solid blue; padding-top: 20px; padding-bottom: 4px; padding-left: 10px; width: 1080px; margin: auto;">
        <asp:Label ID="lblProducto" Text="[Producto]" Style="font-family: Verdana; font-size: 14px;" runat="server"></asp:Label>
    </div>

    <asp:Button runat="server" Text="Historial" CssClass="btn btn-primary" ID="btnHistorial" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-left: 30px; margin-right: -4px" OnClick="btnHistorial_Click" />
    <asp:Button runat="server" Text="Gráficas de Control" CssClass="btn btn-primary" ID="btnInforme" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" OnClick="btnInforme_Click" />
    <asp:Button runat="server" Text="Config. Parametro" CssClass="btn btn-primary" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" ID="Config" OnClientClick="irConfig('vAsociarParametro.aspx')" />
    <asp:Button runat="server" Text="Config. Atributo   " CssClass="btn btn-primary" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" ID="Button1" OnClientClick="irConfigAttr('vAsociarAtributo.aspx')" />
    <asp:Button runat="server" Text="Crear Muestra" CssClass="btn btn-primary" ID="btnCrearMuestra" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" OnClientClick="irNuevaMuestra('vCrearMuestra.aspx')" />
    <asp:Button runat="server" Text="Vista Gráficos" CssClass="btn btn-primary" ID="btnVistas" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" OnClientClick="irNuevaMuestra('vVistaGraficos.aspx')" />
    <asp:Button runat="server" Text="Generar Reporte" CssClass="btn btn-primary" ID="Button2" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; opacity: 0.7; margin-right: -4px;" OnClick="btnIrGenerarReporte_Click" />

    <br />

    <div style="padding: 20px; border-radius: 5px; font-size: 16px; background: #ddd; width: 94.2%; margin: 5px auto 0px 30px; height: 530px">
        <div>Seleccione Parametro</div>
        <div style="height: 120px; width: 160px; background: none; overflow-y: auto; display: inline-block;">
            <asp:RadioButtonList ID="cblParametros" runat="server" Style="margin-left: 30px"></asp:RadioButtonList>
        </div>

        <div style="width: 550px; height: 201px; display: inline-block; background: none; float: right; margin-top: -30px; margin-right: 20px; border: 1px solid #eee">
        <a href="<%= enlace_4 %>" target="_blank"> <img src="<%= url_4 %>" style="height:201px; width:550px"/></a>
        </div>

        <%--        <asp:RadioButtonList ID="rbPendientes" runat="server" Style="width: 150px; background: none; display: inline-block; float: right; margin-right: 80px">
            <asp:ListItem Value="2" Selected>En Proceso</asp:ListItem>
            <asp:ListItem Value="3">Finalizado</asp:ListItem>
        </asp:RadioButtonList>--%>
        <br />
        <div style="display: inline-block; width: 80px; margin-left: 15px;">Fecha Inicio</div>
        <asp:TextBox ID="txtFecInicio" autocomplete="off"  runat="server" Style="height: 25px; font-size: 13px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFecInicio" ValidationGroup="ABC" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFecInicio"></asp:RequiredFieldValidator>
        <br />
        <div style="display: inline-block; width: 80px; margin-left: 15px;">Fecha Fin</div>
        <asp:TextBox ID="txtFecFin"  autocomplete="off"  runat="server" Style="height: 25px; font-size: 13px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFecFin" ValidationGroup="ABC" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFecFin"></asp:RequiredFieldValidator><br /><br />

        <asp:Button ID="btnGenerarReporte" OnClick="btnGenerarReporte_Click" ValidationGroup="ABC" runat="server" Text="Generar Reporte" CssClass="btn btn-primary" Style="margin: 5px 0 5px 10px;" />
        <button type="button" class="btn btn-primary" onclick="javascript:window.location.href='Reportes.aspx';" style="margin-top: 5px; margin-bottom: 5px">Volver a Tipos de Reporte</button>
        <br />
        <asp:ScriptManager ID="smParametros" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="repvParametro"  ForeColor="Transparent" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="250px" Width="100%">
            <LocalReport ReportPath="iAdministradors\repParametro.rdlc">
            </LocalReport>

        </rsweb:ReportViewer>

    </div>


</asp:Content>
