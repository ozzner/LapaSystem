<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vCrearMuestra.aspx.cs" Inherits="LimsWeb.iAdministrador.vCrearMuestra" %>


<!DOCTYPE html>
<html>
<head runat="server">

    <style>
        .txtChico {
            display: inline-block;
            width: 100px;
            margin-top: 3px;
        }

        .txts {
            display: inline-block;
            width: 130px;
            margin-top: 3px;
        }

        .etqs {
            display: inline-block;
            width: 70px;
            margin-left: 6px;
        }
    </style>
        <script src="../Content/js/jquery-1.8.2.js"></script>
    <script src="../Content/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            window.opener.location.reload();
        });
    </script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Nueva Muestra</title>
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />

</head>
<body style="background: #eee">

    <form id="form1" runat="server">
        <div>
            <div style="border-bottom: 1px solid gray; margin-left: 15px; margin-top: 5px; font-weight: bold; font-size: 15px">
                <asp:Label runat="server" ID="lblRuta" Text="[Ruta]"></asp:Label>
            </div>
            <div style="padding: 15px; margin: 20px auto; background: none; width: 510px;">
                <div class="etqs" style="margin-bottom: 20px; font-weight: bold; font-size: 15px">
                    <asp:Label runat="server" Text="Muestra"></asp:Label>
                </div>
                <asp:TextBox runat="server" Style="display: inline-block; width: 200px; padding: 2px 10px; font-size: 14px; background: #e3ffa7" CssClass="txts" ID="txtMuestra" placeholder="Ingrese codigo muestra"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMuestraID" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMuestra"></asp:RequiredFieldValidator>
                <br />

                <asp:Repeater ID="rFormulario" runat="server">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chk" Checked CssClass="chks" />

                        <div class="etqs">
                            <asp:Label runat="server" Text="Parametro"></asp:Label>
                        </div>

                        <asp:TextBox runat="server" CssClass="txts" ID="txtParametro" Text='<%#Eval("NomParametro") %>' BackColor="LightGray" ReadOnly></asp:TextBox>

                        <div class="etqs">
                            <asp:Label runat="server" Text="Prioridad"></asp:Label>
                        </div>

                        <asp:RadioButton runat="server" ID="rbBajo" Text="Bajo" GroupName="prioridad" />
                        <asp:RadioButton runat="server" ID="rbMedio" Checked Text="Medio" GroupName="prioridad" />
                        <asp:RadioButton runat="server" ID="rbAlto" Text="Alto" GroupName="prioridad" />

                        <br />


                    </ItemTemplate>


                </asp:Repeater>



                <asp:Repeater ID="repAtributo" runat="server">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chk" Checked CssClass="chks" />

                        <div class="etqs">
                            <asp:Label runat="server" Text="Atributo"></asp:Label>
                        </div>

                        <asp:TextBox runat="server" CssClass="txts" ID="txtParametro" Text='<%#Eval("NomAtributo") %>' BackColor="LightGray" ReadOnly></asp:TextBox>

                        <div class="etqs">
                            <asp:Label runat="server" Text="Prioridad"></asp:Label>
                        </div>

                        <asp:RadioButton runat="server" ID="rbBajo" Text="Bajo" GroupName="prioridad" />
                        <asp:RadioButton runat="server" ID="rbMedio" Checked Text="Medio" GroupName="prioridad" />
                        <asp:RadioButton runat="server" ID="rbAlto" Text="Alto" GroupName="prioridad" />

                        <br />


                    </ItemTemplate>


                </asp:Repeater>







                <br />
                <asp:Button runat="server" Text="Crear Muestra" CssClass="btn btn-primary" Style="width: 100%; border-radius: 0px;" ID="btnCrearLimpiar" OnClick="btnCrearLimpiar_Click" />
             <%--   <asp:Button runat="server" Text="Salir" CssClass="btn btn-primary" Style="width: 100%; border-radius: 0px;" ID="btnSalir" OnClick="btnSalir_Click" />--%>

            </div>








        </div>



    </form>
</body>
</html>
