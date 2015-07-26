<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Administrador.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="LimsWeb.iAdministrador.Reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
    <script>

        function irConfigAttr(url) {
            window.open(url, 'ventana1', 'top=0,left=300,height=510,width=1000,scrollbars=1,resizable=1,location=no');
        }

        function irFileUpload(url) {
            window.open(url, 'ventana1', 'top=0,left=500,height=500,width=550,scrollbars=1,resizable=1,location=no');
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
        Tipos de reporte:
        <asp:Button runat="server" ID="cambiarLogo" Text="Cambiar Logo" CssClass="btn btn-primary" Style="width: 100px; float: right; display: inline; padding-right:91px;" OnClientClick="irFileUpload('vSubirLogo.aspx')" />
        <br />
        <br />

        <div style="font-size: 15px; margin-bottom: 4px">Reportes Estadísticos</div>
        <asp:Button runat="server" ID="btnRepParametro" Text="Reporte de Parámetros(Estadístico)" Style="width: 100%; height: 50px; margin-bottom: 4px" class="btn btn-primary" OnClick="btnRepParametro_Click" />

        <asp:Button runat="server" ID="btnRepAtributo" Text="Reporte de Atributos(Estadístico)" Style="width: 100%; height: 50px; margin-bottom: 4px" class="btn btn-primary" OnClick="btnRepAtributo_Click" />

        <br />
        <br />
        <div style="font-size: 15px; margin-bottom: 4px">Reportes de Status</div>
        <asp:Button runat="server" ID="btnRepProducto" Text="Reporte de Parámetros(Status)" Style="width: 100%; height: 50px; margin-bottom: 4px" class="btn btn-primary" OnClick="btnRepProducto_Click" />

        <asp:Button runat="server" ID="btnRepProductoAttr" Text="Reporte de Atributo(Status)" Style="width: 100%; height: 50px; margin-bottom: 4px" class="btn btn-primary" OnClick="btnRepProductoAttr_Click" />


    </div>

</asp:Content>
