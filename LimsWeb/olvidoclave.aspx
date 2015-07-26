<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="olvidoclave.aspx.cs" Inherits="LimsWeb.olvidoclave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Olvido Contraseña</title>
    <link href="Content/css/EstilosRegistro.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="registro color" style="height: 250px; margin-top: 50px">
                <h1>Envio de credenciales </h1>
                
                <div class="linea" style="margin-top:-10px;margin-bottom:10px"></div>
                
                Porfavor ingrese su correo electronico. Se le enviará un mensaje con su usuario y clave.
            
                <asp:TextBox ID="txtCorreo" runat="server" style="width:95%; margin:10px auto; background:none;border-radius:6px;padding:10px;font-size:large"></asp:TextBox>

                <asp:Button runat="server" ID="btnEnviarMensaje" Text="Continuar" CssClass="btns color" Width="100%" OnClick="btnEnviarMensaje_Click"/>
            
            <br />
                <a href="iRegistro/Login.aspx" style="background:none">Volver</a>
            </div>
        </div>
    </form>
</body>
</html>
