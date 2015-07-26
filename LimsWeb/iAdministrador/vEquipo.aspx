<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vEquipo.aspx.cs" Inherits="LimsWeb.iAdministrador.vEquipo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Equipos</title>

    <link href="../Content/css/bootstrap.css" rel="stylesheet" />
    <style>
        * {
            font-family: Calibri;
            font-size: 14px;
        }

        .txts {
            width: 130px;
        }
    </style>
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
</head>
<body style="background: #eee">
    <form id="form1" runat="server">

        <div style="background: none; width: 340px; display: inline-block; float:left;">
            <div style="background: none; display: inline-block; width: 340px; height: 500px; padding: 20px">
                <table>
                    <tr>
                        <td class="txts">
                            <asp:Label runat="server" Text="Nombre del equipo: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtNomEquipo" autocomplete="off"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNomEquipo" runat="server" ErrorMessage="*" ValidationGroup="ValidarEQP" ForeColor="Red" ControlToValidate="txtNomEquipo"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Marca: "></asp:Label>
                            
                        </td>

                        <td>
                            <asp:TextBox runat="server" ID="txtMarca" placeholder=" " autocomplete="off"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="ValidarEQP" ForeColor="Red" ControlToValidate="txtMarca"></asp:RequiredFieldValidator>
                        </td>


                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Modelo: "></asp:Label>
                            
                        </td>

                        <td>
                            <asp:TextBox runat="server" ID="txtModelo" placeholder=" " autocomplete="off"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNumSerie" runat="server" ErrorMessage="*" ValidationGroup="ValidarEQP" ForeColor="Red" ControlToValidate="txtModelo"></asp:RequiredFieldValidator>
                        </td>


                    </tr>
                </table>

                <asp:Button runat="server" ValidationGroup="ValidarEQP" Style="padding: 3px 10px; margin: 5px 0px 0px 0px; width: 100%" Text="Registrar Equipo" CssClass="btn btn-primary" ID="btnRegistrar" OnClick="btnRegistrar_Click" />
                <asp:Button runat="server" Style="padding: 3px 10px; margin: 2px 0px 5px; width: 100%" Text="Quitar Seleccionado" CssClass="btn btn-primary" ID="btnQuitarSeleccionado" OnClick="QuitarSeleccionado_Click" />

                <br />

                <asp:ListBox ID="lbEquipos" AutoPostBack="true" Style="width: 300px; height: 330px" runat="server" OnSelectedIndexChanged="lbEquipos_SelectedIndexChanged"></asp:ListBox>
            </div>
        </div>



        <div style="background: none; width: 340px; height: 500px; float: right;">

            <div style="background: none; height: 40px; width: 90%; text-align: center; line-height: 55px; margin: 0px auto; font-size: large; border-bottom: 1px solid gray; margin-right: 20px">
                Parametros Asociados
            </div>
            <div style="margin-top: 10px">
                <asp:Label runat="server" Style="margin-top: 10px" ID="lbNomEquipo" Text="[Nombre del Equipo]" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>

            <table>
                <tr>
                    <td>
                        <div style="margin-left: 10px; margin-bottom: 10px">
                            <asp:Label runat="server" Style="margin-top: 10px" Text="Parametro" Font-Size="Medium"> </asp:Label>
                        </div>

                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlParametros" Style="margin-left: 10px; margin-bottom: 10px" Width="150px"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnIngresarParametro" CssClass="btn btn-primary" Text="Ingresar" Style="margin-left: 10px; padding: 1px 10px; margin-bottom: 10px" OnClick="btnIngresarParametro_Click" />
                    </td>
                </tr>
            </table>

            <asp:Button runat="server" Style="padding: 3px 10px; margin: 0px 0px 5px 0px; width: 90%; margin-left:13px" Text="Quitar Seleccionado" CssClass="btn btn-primary" ID="QuitarParamSeleccionado" OnClick="QuitarParamSeleccionado_Click"  />

            <div style="background: none; height:330px; margin-left:15px">
                <asp:ListBox ID="lbParametro" AutoPostBack="false" Style="width: 300px; height: 330px" runat="server"></asp:ListBox>
            </div>


            <%--<asp:Button runat="server" Text="Guardar Parametros" CssClass="btn btn-primary" Style="width: 90%; margin: 10px auto; margin-left: 12px" />--%>
        </div>
    </form>
</body>
</html>
