<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculoFormula.aspx.cs" Inherits="LimsWeb.Prueba.CalculoFormula" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Calculo de Ecuaciones</title>
    <style>
        * {
            font-family:Calibri;
            font-size:13px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<fieldset style=" width:300px; " >
    <legend>Ingresar Ecuación</legend>   
        <asp:TextBox ID="txtEquation" runat="server"></asp:TextBox>
        <asp:Button ID="btnCalcular" runat="server" Text="Calcular"
            onclick="btnCalcular_Click" />
               
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar"
            onclick="btnLimpiar_Click" />   
        <br />
        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </fieldset>

        <br /><br />

        <fieldset style=" width:300px">
    <legend>Promedio ( (A+B+C)/3  </legend>   
        <br /><asp:Label runat="server" Text="N1"></asp:Label> 
            <asp:TextBox ID="txtValor1" runat="server"></asp:TextBox><br />
        
        <asp:Label runat="server" Text="N2"></asp:Label> 
            <asp:TextBox ID="txtValor2" runat="server"></asp:TextBox><br />
        
        <asp:Label runat="server" Text="N3"></asp:Label> 
            <asp:TextBox ID="txtValor3" runat="server"></asp:TextBox><br />

        <asp:Button ID="btnCalcularPromedio" runat="server" Text="Calcular"
            onclick="btnCalcularPromedio_Click" />
               

        <br />
        <asp:Label ID="lblResultado" runat="server" Text="[Resultado]"></asp:Label>
        </fieldset>


        
    </form>
</body>
</html>
