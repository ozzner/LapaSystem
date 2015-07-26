<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Administrador.Master" AutoEventWireup="true" CodeBehind="EditarParametro.aspx.cs" Inherits="LimsWeb.iAdministrador.EditarParametro" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
    function irConfig(url) {
        window.open(url, 'ventana1', 'top=0,left=200,height=610,width=405,scrollbars=1,resizable=1,location=no');
    }
</script>

<style>

    .fsDatos {
    width:40%;
    border:1px solid green;
    border-radius:6px;
    border-color:gray;
    padding:20px 0px 20px 20px;
    padding-top:-10px;
    display:inline-block;
    height:400px;
    }

    .fsDatos legend {
    font-size:17px;
    font-family:Calibri;
        
    text-align:center;
    }

    .tabla tr td {
    height:25px;
    width:155px;
    }

    .txts {
    width:100%;
    height:22px;
    }

    
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdministrador" runat="server">

    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
  <div class="titulo"  style="  border-bottom:1px solid blue;
                                padding-top:20px;
                                padding-bottom:4px;
                                padding-left:10px; 
                                width:1080px;
                                margin:auto;">
        <asp:label id="lblParametro" text ="[Parametro]" style="font-family:Verdana;font-size:14px;" runat="server" ></asp:label>
    </div>


   
    
        
 <asp:Button runat="server" Text="Configuración" CssClass="btn btn-primary" ID="Config" OnClientClick="irConfig('vEditarParametro.aspx')"  style="width:150px;margin-top:5px; padding-top:3px;padding-bottom:3px;opacity:1;border-radius:0px;margin-left:18px;margin-right:-4px;"/>
        
    <div style="background:none; width:1000px;height:500px;margin:20px auto;">

        <asp:Chart ID="cMuestras" BackColor="#d9d9d9" runat="server" Width="1000px" Height="500px">
            <Series>
                <asp:Series Name="Series1" ChartType="FastLine"></asp:Series>
                <asp:Series Name="Series2" ChartType="Point"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

    </div>

    <asp:series Name="Series2"></asp:series>

</asp:Content>
