<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vEditarParametro.aspx.cs" Inherits="LimsWeb.iAdministrador.vEditarParametro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />
    <script src="../Content/js/validaciones.js"></script>
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
<style>
    * {
        font-size:13px;
    }
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

    .txts, .ddls{
    width:100%;
    height:22px;
    }

    .txtTiempo {
        width:51px;
    }
    
</style>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

  <div class="titulo"  style="  border-bottom:1px solid blue;
                                padding-top:20px;
                                padding-bottom:4px;
                                padding-left:10px; 
                                width:98%;
                                margin:auto;">
        <asp:label id="lblParametro" text ="[Parametro]" style="font-family:Verdana;font-size:14px;" runat="server"></asp:label>
    </div>


    <div style="border:1px solid none; margin:30px auto 0px auto; width:85%; height:400px; ">
    
        

   <fieldset >
    <legend>Características</legend>
            <table class="tabla">
            
            <tr>
                <td>
                    Tiempo Estimado
                </td>
                <td>
                    <asp:TextBox  id="txtHoras" TextMode="Number" OnKeyPress="ValidarSoloNumeros()" MaxLength="2" placeholder="hh" CssClass="txtTiempo"  runat="server"  ></asp:TextBox>:
                    <asp:TextBox  id="txtMinutos" TextMode="Number" OnKeyPress="ValidarSoloNumeros()" MaxLength="2" placeholder="mm" CssClass="txtTiempo"  runat="server"  ></asp:TextBox>:
                    <asp:TextBox  id="txtSegundos" TextMode="Number" OnKeyPress="ValidarSoloNumeros()" MaxLength="2" placeholder="ss" CssClass="txtTiempo"  runat="server"  ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Unidad de Medida
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlUM" CssClass="ddls"></asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td>
                    Tipo de Parametro
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlTipoParametro"  CssClass="ddls" ></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Formula
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlFormula"  CssClass="ddls" ></asp:DropDownList>
                </td>
            </tr>
                
            <tr>
                <td>
                    Calculado
                </td>
                <td>
                    <asp:TextBox runat="server" id="txtCalculado" ></asp:TextBox>
                </td>
            </tr>

                <tr>
                <td>
                    Min.Advertencia
                </td>
                <td>
                    <asp:TextBox   id="txtMinAdvertencia" CssClass="txts"  runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Max.Advertencia
                </td>
                <td>
                    <asp:TextBox  id="txtMaxAdvertencia" CssClass="txts" runat="server"  ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Promedio
                </td>
                <td>
                    
                    <asp:TextBox  id="txtPromedio" CssClass="txts" runat="server"  ></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    Min.Accion
                </td>
                <td>
                    
                    <asp:TextBox  id="txtMinAccion" CssClass="txts" runat="server"  ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Max.Accion
                </td>
                <td>
                    
                    <asp:TextBox  id="txtMaxAccion" CssClass="txts" runat="server"  ></asp:TextBox>
                </td>
            </tr>

        </table>
       <br />
       </fieldset>
    
    <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-primary" text="Guardar" style="width:98%; margin:7px auto;" OnClick="btnGuardar_Click"/>
    
    </div>
    </form>
</body>
</html>
