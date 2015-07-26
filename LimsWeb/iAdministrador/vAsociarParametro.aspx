﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vAsociarParametro.aspx.cs" Inherits="LimsWeb.iAdministrador.vAsociarProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
    <script src="../Content/js/jquery-1.8.2.js"></script>
    <script src="../Content/js/bootstrap.min.js"></script>
    <link href="../Content/css/EstilosPopup.css" rel="stylesheet" />
    <script src="../Content/js/validaciones.js"></script>
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />

<style>
    * {
        font-size:13px;
        background:#eee;
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
    }

    .Cuadros {
    width:600px;
    display:inline-block;
    
    }

    #contTotal {
        width:1000px;
        background:green;
    }
    .hide_evidence {
            display: none;
        }
</style>

    <script>
        $(document).ready(function () {
          $("title").html($("#lblWinTitle").val());
      });
    </script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background:#eee;">
    <form id="form1" runat="server">
      <asp:TextBox ID="lblWinTitle" CssClass="hide_evidence" runat="server"></asp:TextBox>
        <div id="AgregarParametros" class="Cuadros" style="background:none;float:left;">
              <div class="titulo"  style="  border-bottom:1px solid blue;
                                            padding-top:20px;
                                            padding-bottom:4px;
                                            padding-left:10px; 
                                            width:97%;
                                            margin:auto;">
                    <asp:label id="lblProducto" text ="[Producto]" style="font-family:Verdana;font-size:14px;" runat="server"></asp:label>
                </div>
    
                <div style="background:none; width:468px;margin:30px auto">
                    <asp:label runat="server" style="display:inline-block;" ID="lbl01"  Text="TODOS LOS PARAMETROS"></asp:label>
                    <asp:label runat="server" style="display:inline-block; float:right; margin-right:115px" ID="Lbl02" Text="AGREGADOS"></asp:label><br />

                    <asp:ListBox ID="lbProductos" CssClass="listBox" Height="350px" Width="200px" runat="server" AutoPostBack="false"></asp:ListBox>
                    <asp:ListBox ID="lbAgregados" AutoPostBack="True" OnSelectedIndexChanged="lbAgregados_OnSelectedIndexChanged" CssClass="listBox" style="float:right;" Height="350px" Width="200px" runat="server"></asp:ListBox>
                    <div style="width:60px; height:100px; background:none; display:inline-block; float:right; margin-right:4px;margin-top:100px;">

                        <asp:ImageButton ID="btnAgregar"  runat="server" ImageUrl="~/Content/img/derecha.png" Width="60px" OnClick="btnAgregar_Click" />
                        <asp:ImageButton ID="btnQuitar" runat="server" ImageUrl="~/Content/img/izquierda.png" Width="60px" OnClick="btnQuitar_Click" OnClientClick="javascript:return confirm('Si quita el parámetro, se perderá la información configurada en el mismo. ¿Desea continuar?');" />
                    </div>
                </div>
        </div>










<div id="contTotal">
 <div id="ConfigurarParametros" class="Cuadros" style="width:400px;float:right;">


                <div class="titulo"  style="  border-bottom:1px solid blue;
                                    padding-top:20px;
                                    padding-bottom:4px;
                                    padding-left:10px; 
                                    width:98%;
                                    margin:auto;">
                <asp:label id="lblParametro" text ="[Parámetro]" style="font-family:Verdana;font-size:14px;" runat="server"></asp:label>
                </div>


                <div style="border:1px solid none; margin:30px auto 0px auto; width:85%; height:400px;margin-bottom:-15px ">
    
        

                <fieldset style="margin-top:-15px" >
                <legend>Características</legend>
                <table class="tabla">
            
                <tr>
                    <td>
                        Tiempo Estimado (min)
                    </td>
                    <td>
                        <asp:TextBox  id="txtTiempo" TextMode="Number" OnKeyPress="ValidarSoloNumeros()" CssClass="ddls" runat="server" autocomplete="off"></asp:TextBox>
                        <%--<asp:TextBox  id="TextBox1" TextMode="Number" OnKeyPress="ValidarSoloNumeros()" placeholder="hh" CssClass="txtTiempo"  runat="server" Width="40px"  ></asp:TextBox>--%>
                        <%--<asp:TextBox  id="txtMinutos" TextMode="Number" OnKeyPress="ValidarSoloNumeros()" MaxLength="2" placeholder="mm" CssClass="txtTiempo"  runat="server" Width="41px"  ></asp:TextBox>--%>
                        <%--<asp:TextBox  id="txtSegundos" TextMode="Number" OnKeyPress="ValidarSoloNumeros()" MaxLength="2" placeholder="ss" CssClass="txtTiempo"  runat="server" Width="36px"  ></asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Unidad de Medida
                    </td>
                    <td>
                        <%--<asp:DropDownList runat="server" ID="ddlUM" CssClass="ddls"></asp:DropDownList>--%>
                        <asp:TextBox  id="txtUnidadMedida" CssClass="txts" runat="server"  ></asp:TextBox>
                    </td>
                </tr>
            
                <tr>
                    <td>
                        Tipo de Parametro
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTipoParametro" AutoPostBack="true" CssClass="ddls" OnSelectedIndexChanged="ddlTipoParametro_SelectedIndexChanged" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Formula
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlFormula"  Visible="false" CssClass="ddls" ></asp:DropDownList>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        Calculado
                    </td>
                    <td>
                        <asp:TextBox runat="server" id="txtCalculado" Visible="false" autocomplete="off"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Nro.Decimales
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumDecimales" TextMode="Number" CssClass="txts" runat="server" autocomplete="off"></asp:TextBox>
                    </td>
                </tr>
                       <tr>
                    <td>
                        Min.Accion
                    </td>
                    <td>
                    
                        <asp:TextBox  id="txtMinAccion" CssClass="txts" runat="server" autocomplete="off" ></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                    <td>
                        Min.Advertencia
                    </td>
                    <td>
                        <asp:TextBox   id="txtMinAdvertencia" CssClass="txts"  runat="server" autocomplete="off"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        Promedio
                    </td>
                    <td>
                    
                        <asp:TextBox  id="txtPromedio" CssClass="txts" runat="server" autocomplete="off" ></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        Max.Advertencia
                    </td>
                    <td>
                        <asp:TextBox  id="txtMaxAdvertencia" CssClass="txts" runat="server" autocomplete="off" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Max.Accion
                    </td>
                    <td>
                        <asp:TextBox  id="txtMaxAccion" CssClass="txts" runat="server" autocomplete="off" ></asp:TextBox>
                    </td>
                </tr>

                </table>
                <br />
                </fieldset>
    
                <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-primary" text="Guardar" style="width:98%; margin:7px auto;" OnClick="btnGuardar_Click"/>
                
                </div>

  </div>
    </div>
    </form>
</body>
</html>
