<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmacion.aspx.cs" Inherits="LimsWeb.Confirmacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Content/css/EstilosRegistro.css" rel="stylesheet" />
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />

    <title><%= confirm %></title>

    

</head>
<body onload="CargaInicio()">
    <form id="form1" runat="server">
     
        <div class="validacion color" style="height:270px;">    
            <h1> <%= validate %> </h1>
            <div class="linea"></div>
               <br />

            <div id="informacion" class="color">
            <%= please_insert %>
                
            </div>
            <br />
            <%= code_validate %>
            <br />
            <asp:TextBox runat="server" ID="txtSerial"  autocomplete="off" placeholder="" CssClass="txts"></asp:TextBox>
             <br />


           
           
           
             <br />

            <asp:Button runat="server" ID="btnVerificar" CssClass="btns" OnClick="btnVerificar_Click"  />
            
       <br />       <br />          
        </div>

    </form>

 

</body>
</html>


