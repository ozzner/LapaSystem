<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Administrador.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="LimsWeb.iAdministrador.Producto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdministrador" runat="server">

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

    <div class="titulo"  style="  border-bottom:1px solid blue;
                                padding-top:20px;
                                padding-bottom:4px;
                                padding-left:10px; 
                                width:1080px;
                                margin:auto;">
        <asp:label id="lblProducto" text ="[Producto]" style="font-family:Verdana;font-size:14px;" runat="server"></asp:label>
    </div>
        
        <asp:Button runat="server" Text="Historial"  CssClass="btn btn-primary" ID="btnHistorial"                   style="width:150px;margin-top:5px; padding-top:3px;padding-bottom:3px; border-radius:0px;margin-left:30px;margin-right:-4px;margin-bottom:4px;" OnClick="btnHistorial_Click"/>
        <asp:Button runat="server" Text="Gráficas de Control"  CssClass="btn btn-primary" ID="btnInforme"           style="width:150px;margin-top:5px; padding-top:3px;padding-bottom:3px;opacity:0.7;border-radius:0px;margin-right:-4px;margin-bottom:4px;"/>
        <asp:Button runat="server" Text="Config. Parametro" CssClass="btn btn-primary"                              style="width:150px;margin-top:5px; padding-top:3px;padding-bottom:3px;border-radius:0px;margin-right:-4px;margin-bottom:4px;" ID="Config" OnClientClick="irConfig('vAsociarParametro.aspx')"/>
         <asp:Button runat="server" Text="Config. Atributo   " CssClass="btn btn-primary"                  style="width:150px;margin-top:5px; padding-top:3px;padding-bottom:3px;border-radius:0px;margin-right:-4px;margin-bottom:4px;" ID="Button1" OnClientClick="irConfigAttr('vAsociarAtributo.aspx')"/>
        <asp:Button runat="server" Text="Crear Muestra" CssClass="btn btn-primary" ID="btnCrearMuestra"             style="width:150px;margin-top:5px; padding-top:3px;padding-bottom:3px;border-radius:0px;margin-right:-4px;margin-bottom:4px;" OnClientClick="irNuevaMuestra('vCrearMuestra.aspx')"/>
        <asp:Button runat="server" Text="Vista Gráficos" CssClass="btn btn-primary" ID="btnVistas" style="width:150px;margin-top:5px; padding-top:3px;padding-bottom:3px;border-radius:0px;margin-right:-4px;margin-bottom:4px;" OnClientClick="irNuevaMuestra('vVistaGraficos.aspx')"/>
       <asp:Button runat="server" Text="Generar Reporte" CssClass="btn btn-primary" ID="btnGenerarReporte"  Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px; margin-bottom:4px;" OnClick="btnGenerarReporte_Click" />

    <style>
        .graficos {            
            width:48%;
            display:inline-block;
            height:250px;
            background:none;
            border-radius:5px;
            border:1px solid #ccc;
            float:left;
            margin-right:4px;
            margin-bottom:4px;

            }
    </style>
    <br />
    
    <div class="graficos" style="margin-left:20px">
        <asp:Chart ID="cMuestra01" BackColor="#d9d9d9" runat="server" Width="535px" style="border-radius:5px;" Height="250px">
            <Series>
                 <asp:Series Name="Series2" ChartType="FastLine" BorderWidth="3"  ></asp:Series>
                <asp:Series Name="Series1" ChartType="Point" Color="green"  ></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea BackColor="#d9d9d9"  Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>

    <div class="graficos">
         <asp:Chart ID="cMuestra02"  BackColor="217, 217, 217" runat="server" Width="535px" style="border-radius:5px;" Height="250px">
            <Series>
                <asp:Series Name="Series2" ChartType="FastLine" BorderWidth="3"  ></asp:Series>
                <asp:Series Name="Series1" ChartType="Point" Color="black"  ></asp:Series>
                <asp:Series Name="Series3" ChartType="Line" Color="black"  ></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea BackColor="#d9d9d9"  Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    <div class="graficos" style="margin-left:20px">
         <asp:Chart ID="cMuestra03" BackColor="#d9d9d9" runat="server" Width="535px" style="border-radius:5px;" Height="250px">
            <Series>
                 <asp:Series Name="Series2" ChartType="FastLine" BorderWidth="3"  ></asp:Series>
                <asp:Series Name="Series1" ChartType="Point" Color="black"  ></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea BackColor="#d9d9d9" Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    <div class="graficos">
         <asp:Chart ID="cMuestra04" BackColor="#d9d9d9" runat="server" Width="535px" style="border-radius:5px;" Height="250px">
            <Series>
                 <asp:Series Name="Series2" ChartType="FastLine" BorderWidth="3"  ></asp:Series>
                <asp:Series Name="Series1" ChartType="Point" Color="black"  ></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea BackColor="#d9d9d9"  Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>

</asp:Content>
