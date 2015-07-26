<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LimsWeb.iRegistro.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../Content/css/EstiloCaptcha.css" rel="stylesheet" />
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
<script src="ScriptCaptcha.js"></script>
<script>cargarInicio();</script>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LAPA LOGIN</title>

    <style>
    h3{
    color:#47a3da;
    }


    #contenedorLogin {
    margin:80px auto;
     background-color:white;
    top: 0px;
    width: 350px;
    padding: 18px 35px 18px 35px;
       
    border: 1px solid rgba(147, 184, 189,0.8);
    -webkit-box-shadow: 0pt 2px 5px rgba(105, 108, 109, 0.7),   0px 0px 8px 5px rgba(208, 223, 226, 0.4) inset;
    -moz-box-shadow: 0pt 2px 5px rgba(105, 108, 109, 0.7),  0px 0px 8px 5px rgba(208, 223, 226, 0.4) inset;
    box-shadow: 0pt 2px 5px rgba(105, 108, 109, 0.7),   0px 0px 8px 5px rgba(208, 223, 226, 0.4) inset;
    -webkit-box-shadow: 5px;
    -moz-border-radius: 5px;
    border-radius: 5px;
    }

    * {
        font-family:Arial;
        font-size:13px;       
    }
        
    body {
    background-image: url("/images/Lapa.jpg");
    background-repeat: no-repeat;
    background-size: auto auto;
    color:#47a3da;
}

    .etqs{

    font-size:18px;
    }

    .txts {
        width:88%;
        margin-top: 4px;
        /*
          height:30px;
            */
        padding: 10px 20px 10px 20px;
        border: 1px solid rgb(178, 178, 178);
        -webkit-appearance: textfield;
        -webkit-box-sizing: content-box;
        -moz-box-sizing: content-box;
        box-sizing: content-box;
        -webkit-border-radius: 3px;
        -moz-border-radius: 3px;
        border-radius: 3px;
        -webkit-box-shadow: 0px 1px 4px 0px rgba(168, 168, 168, 0.6) inset;
        -moz-box-shadow: 0px 1px 4px 0px rgba(168, 168, 168, 0.6) inset;
        box-shadow: 0px 1px 4px 0px rgba(168, 168, 168, 0.6) inset;
        -webkit-transition: all 0.2s linear;
        -moz-transition: all 0.2s linear;
        -o-transition: all 0.2s linear;
        transition: all 0.2s linear;
        background:white;
        margin-bottom:10px;
    }

    .btns{
        background:#428bca;
        cursor:pointer;
        display:inline-block;
        border-radius:3px;
        cursor:pointer;
        transition: opacity 1s;    
        margin-top:10px;
        font-weight:bold;
        padding:4px 20px;
        color:White;
        border:0.5px solid black;  
        width:100%;
        padding: 10px 12.5px 10px 12.5px;
    }


    #contenedorLogin div{
            width:100%;
            }



    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedorLogin" style=" width:30%; padding:30px">
        
        <br />    
        <h3 style="font-size:25px; margin:auto; text-align:center; width:100%; "><%= ing %></h3>
        <br />    <br />

        <div><asp:Label  CssClass="etqs" runat="server" ID="email"></asp:Label></div>
        <asp:TextBox  CssClass="txts" runat="server" Id="txtCorreo"  autocomplete="off"></asp:TextBox>

        <div><asp:Label  CssClass="etqs" runat="server" ID="pass"></asp:Label></div>
        <asp:TextBox  CssClass="txts" runat="server" Id="txtClave" TextMode="Password"></asp:TextBox>
        <br />   

        <div>
            <table class="TablaCentrada">
                <tr>
                    <td><img id="imgCaptcha" width="200" height="80" alt="" runat="server"/></td>
                    <td><asp:TextBox ID="txtCodigo" Width="160" Height="30" MaxLength="5" Font-Size="Large"  runat="server" AutoComplete="off" style=" display:block"/>
                        <asp:LinkButton ID="lbnActualizarCaptcha" runat="server" OnClick="lbnActualizarCaptcha_Click" />
                    </td>
                </tr>
            </table>

        </div>
        <br />   

        <asp:Button runat="server" CssClass="btns" ID="btnIngresar" OnClick="btnIngresar_Click"/>
         <br /> 
        <a href="../olvidoclave.aspx"><%= forgot %></a>
         <br /> <br />
   
    </div>
    </form>
      
</body>
</html>