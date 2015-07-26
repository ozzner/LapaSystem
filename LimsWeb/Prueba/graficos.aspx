<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="graficos.aspx.cs" Inherits="LimsWeb.Prueba.graficos" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2">
            <Series>
                <asp:Series Name="Series1" ChartType="Line" XValueMember="CodigoMuestra" YValueMembers="Resultado" YValuesPerPoint="2"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SistemaWebConnectionString %>" SelectCommand="
select M.CodigoMuestra,ProdParaID, Resultado from Muestra_Detalle MD
inner join Muestra M on M.MuestraID = MD.MuestraID
where ProdParaID=50

"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
