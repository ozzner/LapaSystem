<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Administrador.Master" AutoEventWireup="true" CodeBehind="RepMantenimientos.aspx.cs" Inherits="LimsWeb.iAdministrador.RepMantenimientos" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
    <script>
        function irConfig(url) {
            window.open(url, 'ventanaCOnfigProducto', 'top=0,left=200,height=500,width=700,scrollbars=1,resizable=1,location=no');
        }
        function AgregarProducto(url) {
            window.open(url, 'AgregarProducto', 'top=0,left=200,height=610,width=725,scrollbars=1,resizable=1,location=no');
        }
        function irMantenimiento(url) {
            window.open(url, 'irMantenimiento', 'top=0,left=200,height=540,width=1050,scrollbars=1,resizable=1,location=no');
        }
        function irCalibracion(url) {
            window.open(url, 'irCalibracion', 'top=0,left=200,height=610,width=1025,scrollbars=1,resizable=1,location=no');
        }
    </script>
    <style>
        .graficos {
            width: 48%;
            display: inline-block;
            height: 250px;
            background: none;
            border-radius: 5px;
            border: 1px solid #ccc;
            float: left;
            margin-right: 4px;
            margin-bottom: 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdministrador" runat="server">
    <div class="tituloInfo">
        <asp:Label ID="lblLaboratorio" Text="[Laboratorio]" Style="font-family: Verdana; font-size: 14px;" runat="server"></asp:Label>
    </div>


    <asp:Button runat="server" Text="Agregar Producto" CssClass="btn btn-primary" ID="Config" OnClientClick="AgregarProducto('vAsociarProductoCliente.aspx')" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-left: 18px; margin-right: -4px" />
    <asp:Button runat="server" Text="Equipos" CssClass="btn btn-primary" ID="btnConfingEquipos" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" OnClientClick="irConfig('vEquipo.aspx')" />
    <asp:Button runat="server" Text="Conf. Mantenimientos" CssClass="btn btn-primary" ID="Button1" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px; width: 170px" OnClientClick="irMantenimiento('vMantenimiento.aspx')" />
    <asp:Button runat="server" Text="Con. Calibraciones" CssClass="btn btn-primary" ID="Button2" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px; width: 170px" OnClientClick="irCalibracion('vCalibracion.aspx')" />
    <asp:Button runat="server" Text="Generar Reporte" CssClass="btn btn-primary" ID="btnGenerarReporte" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" OnClick="btnGenerarReporte_Click" />


     <div style="padding: 20px; border-radius: 5px; font-size: 16px; background: #ddd; width: 95%; margin: 5px auto 0px auto; height: 530px">
     
      <asp:ScriptManager ID="smMantenimientos" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="repvMantenimientos" runat="server"  ForeColor="Transparent"  Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="500px" Width="100%">
            <LocalReport ReportPath="iAdministrador\RepMantenimiento.rdlc">
            </LocalReport>
    
        </rsweb:ReportViewer>
    </div>
</asp:Content>
