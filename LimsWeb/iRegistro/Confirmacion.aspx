<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmacion.aspx.cs" Inherits="LimsWeb.Confirmacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Content/css/EstilosRegistro.css" rel="stylesheet" />
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />

    <title>Confirmación</title>

    

</head>
<body onload="CargaInicio()">
    <form id="form1" runat="server">
     
        <div class="validacion color" style="height:270px;">    
            <h1> VALIDACION </h1>
            <div class="linea"></div>
               <br />

            <div id="informacion" class="color">
            Porfavor ingrese el codigo de activación para poder continuar con el registro.    
            </div>
            <br />
            Codigo de validación
            <br />
            <asp:TextBox runat="server" ID="txtSerial"  autocomplete="off" placeholder="Ingrese aquí su codigo de activación" CssClass="txts"></asp:TextBox>
             <br />


           
           
           
             <br />

            <asp:Button runat="server" ID="btnVerificar" Text="Verificar" CssClass="btns" OnClick="btnVerificar_Click"  />
            
       <br />       <br />          
        </div>

    </form>

 

</body>
</html>


