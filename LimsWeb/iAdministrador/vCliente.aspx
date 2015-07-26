<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vCliente.aspx.cs" Inherits="LimsWeb.iAdministrador.vCliente" %>

<!DOCTYPE html>
<link href="../Content/css/main_fonts.css" rel="stylesheet" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />
    <title>Clientes</title>
    <style>
        * {
            font-family: Calibri;
        }

        .gvGeneral {
            margin: 0;
        }

        .gvCabecera {
            font-weight: lighter;
            color: white;
            text-align: center;
            background: #428bca;
        }

        .gvFilas {
            text-align: center;
        }

        .grilla {
            width: 100%;
            margin: 0 auto;
        }

        .tab {
            width: 95%;
            margin: 0 auto;
        }

        .grupoBotones {
            margin-top: 20px;
            margin-left: 20px;
        }

        .txts {
            margin-bottom: 4px;
            margin-right: 10px;
        }

        .tds {
            width: 70px;
        }
    </style>

</head>
<body style="background: #eee">
    <form id="form1" runat="server">

        <div style="background: none; width: 340px; display: inline-block; float: left;">
            <div style="background: none; display: inline-block; width: 340px; height: 500px; padding: 20px">
                <table>
                    <tr>
                        <td class="txts">
                            <asp:Label runat="server" Text="Cliente "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtNomCliente" autocomplete="off"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNomCLiente" runat="server" ErrorMessage="*" ValidationGroup="ValidarEQP" ForeColor="Red" ControlToValidate="txtNomCliente"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                </table>

                <asp:Button runat="server" ValidationGroup="ValidarEQP" Style="padding: 3px 10px; margin: 5px 0px 0px 0px; width: 100%" Text="Registrar Cliente" CssClass="btn btn-primary" ID="btnRegistrar" OnClick="btnRegistrar_Click" />
                <asp:Button runat="server" Style="padding: 3px 10px; margin: 2px 0px 5px; width: 100%" Text="Quitar Seleccionado" CssClass="btn btn-primary" ID="btnQuitarSeleccionado" OnClick="QuitarSeleccionado_Click" />

                <br />

                <asp:ListBox ID="lbClientes" AutoPostBack="true" Style="width: 300px; height: 350px" runat="server" OnSelectedIndexChanged="lbClientes_SelectedIndexChanged"></asp:ListBox>
            </div>
        </div>



        <div style="background: none; padding: 0px 10px 10px 10px; width: 700px; border-radius: 4px; border: 1px solid gray; height: 440px;; float: right; margin:10px">

            <div style="background: none; height: 40px; width: 100%; text-align: left; line-height: 55px; margin: 0px auto; font-size: large; border-bottom: 1px solid gray; margin-right: 20px">
                Detalles del Cliente
            </div>
            <div style="margin-top: 10px; margin-bottom: 10px">
                <asp:Label runat="server" Style="margin-top: 10px" ID="lbNomEquipo" Text="[Seleccione un cliente]" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </div>

            <table>
                <tr>
                    <td style="width: 80px">
                        <asp:Label runat="server" Style="margin-top: 10px" Text="Nombre" Font-Size="Medium"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNombre" class="txts" autocomplete="off" Width="105px"></asp:TextBox>
                    </td>

                    <td>
                        <asp:Label runat="server" Style="margin-top: 10px" class="txts" Text="RUC" Font-Size="Medium"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRuc" class="txts" autocomplete="off"></asp:TextBox>
                    </td>

                    <td>
                        <asp:Label runat="server" Style="margin-top: 10px" class="txts" Text="Rz. Social" Font-Size="Medium"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRazonSocial" class="txts" autocomplete="off"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td style="width: 80px">
                        <asp:Label runat="server" Style="margin-top: 10px" class="txts" Text="País" Font-Size="Medium"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlPais" class="txts">
                            <asp:ListItem Value="AF">Afghanistan</asp:ListItem>
                            <asp:ListItem Value="AL">Albania</asp:ListItem>
                            <asp:ListItem Value="DZ">Algeria</asp:ListItem>
                            <asp:ListItem Value="AR">Argentina</asp:ListItem>
                            <asp:ListItem Value="AM">Armenia</asp:ListItem>
                            <asp:ListItem Value="AW">Aruba</asp:ListItem>
                            <asp:ListItem Value="AU">Australia</asp:ListItem>
                            <asp:ListItem Value="AT">Austria</asp:ListItem>
                            <asp:ListItem Value="BR">Brazil</asp:ListItem>
                            <asp:ListItem Value="CA">Canada</asp:ListItem>
                            <asp:ListItem Value="CL">Chile</asp:ListItem>
                            <asp:ListItem Value="CN">China</asp:ListItem>
                            <asp:ListItem Value="CO">Colombia</asp:ListItem>
                            <asp:ListItem Value="CR">Costa Rica</asp:ListItem>
                            <asp:ListItem Value="CU">Cuba</asp:ListItem>
                            <asp:ListItem Value="EC">Ecuador</asp:ListItem>
                            <asp:ListItem Value="FR">France</asp:ListItem>
                            <asp:ListItem Value="DE">Germany</asp:ListItem>
                            <asp:ListItem Value="IT">Italy</asp:ListItem>
                            <asp:ListItem Value="JM">Jamaica</asp:ListItem>
                            <asp:ListItem Value="JP">Japan</asp:ListItem>
                            <asp:ListItem Value="MX">Mexico</asp:ListItem>
                            <asp:ListItem Value="PA">Panama</asp:ListItem>
                            <asp:ListItem Value="PY">Paraguay</asp:ListItem>
                            <asp:ListItem Selected="True" Value="PE">Peru</asp:ListItem>
                            <asp:ListItem Value="UY">Uruguay</asp:ListItem>
                            <asp:ListItem Value="VE">Venezuela</asp:ListItem>

                        </asp:DropDownList>

                    </td>

                    <td>
                        <asp:Label runat="server" Style="margin-top: 10px" class="txts" Text="Ciudad" Font-Size="Medium"> </asp:Label>
                    </td>
                    <td>
                        <%--<asp:DropDownList runat="server" ID="ddlCiudad" class="txts"></asp:DropDownList>--%>
                        <asp:TextBox runat="server" ID="txtCiudad" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCiudad" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>

                    <td>
                        <asp:Label runat="server" Style="margin-top: 10px" class="txts" Text="Dirección" Font-Size="Medium"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDireccion" class="txts" autocomplete="off"></asp:TextBox>
                    </td>
                </tr>

            </table>
                <asp:Button runat="server" ID="btnGuardarCambios" Text="Actualizar detalles del contacto" Style="width: 100%; margin-top: 4px" CssClass="btn btn-primary" OnClick="btnGuardarCambios_Click" />


            <div style="background: none; height: 40px; width: 100%; text-align: left; line-height: 55px; margin: 0px auto; font-size: medium; border-bottom: 1px solid gray; margin-right: 20px; margin-bottom: 5px;">
                Contactos
            </div>

            <table>
                <tr>
                    <td class="tds">
                        <asp:Label runat="server" Style="margin-top: 10px" Text="Nombre" Font-Size="Medium"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNomContacto" CssClass="txts" Width="130px" autocomplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvContacto" ControlToValidate="txtNomContacto" ValidationGroup="ABC"  runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                    </tr>
                <tr>

                    <td class="tds">
                        <asp:Label runat="server" Style="margin-top: 10px" Text="Telefono" Font-Size="Medium"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTelefono" CssClass="txts" Width="130px" autocomplete="off"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ErrorMessage="*" ValidationGroup="ABC" ForeColor="Red" ControlToValidate="txtTelefono"></asp:RequiredFieldValidator>
                     </td>

                    <td class="tds">
                        <asp:Label runat="server" Style="margin-top: 10px" Text="Correo" Font-Size="Medium"> </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCorreo" CssClass="txts" Width="192px" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ErrorMessage="*" ValidationGroup="ABC"   ForeColor="Red" ControlToValidate="txtCorreo"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-primary" ValidationGroup="ABC"  Text="Agregar" Style="margin-left: 10px; padding: 1px 10px;" OnClick="btnAgregar_Click" Width="141px"></asp:Button>
                    </td>
                </tr>

            </table>
          
            

            <div style="margin-top: 10px; width: 100%; height: 120px; background: #ddd;">


                <div class="grilla" style="height: 150px; background:none; overflow-y: auto;">
                    <asp:GridView ID="gvContactos" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="gvCabecera" Width="100%" CssClass="gvGeneral" RowStyle-CssClass="gvFilas" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="Nombre" DataField="NombreContacto" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="NombreContacto" Visible="true">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
        
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Telefono" DataField="TelefonoContacto" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="TelefonoContacto">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                          
                            </asp:BoundField>
                            
                            <asp:BoundField HeaderText="Email" DataField="EmailContacto" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="EmailContacto">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                            </asp:BoundField>
                                    
                            <%--OnCommand="btnEliminar_Command"--%>
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEliminar" runat="server" Width="16px" ImageUrl="../Content/img/Eliminar.png"
                                        CommandArgument='<%# Eval("NombreContacto") %>' OnClientClick="javascript:return confirm('¿Confirma Eliminacion del registro?');"
                                         ToolTip="Eliminar" ImageAlign="Baseline" />
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                                <HeaderStyle CssClass="gvCabecera" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />

                        <RowStyle CssClass="gvFilas" BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>



            </div>

          <%--<table>
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
                        <asp:Button runat="server" ID="btnIngresarParametro" CssClass="btn btn-primary" Text="Ingresar" Style="margin-left: 10px; padding: 1px 10px; margin-bottom: 10px"  />
                    </td>
                </tr>
            </table>

            <asp:Button runat="server" Style="padding: 3px 10px; margin-left:13px; margin-right: 0px; margin-top: 0px; margin-bottom: 5px;" Text="Quitar Seleccionado" CssClass="btn btn-primary" ID="QuitarParamSeleccionado"  Height="31px"  />

            <div style="background: none; height:330px; margin-left:15px">
                <asp:ListBox ID="lbParametro" AutoPostBack="false" Style="width: 300px; height: 330px" runat="server"></asp:ListBox>
            </div>--%>


            <%--<asp:Button runat="server" Text="Guardar Parametros" CssClass="btn btn-primary" Style="width: 90%; margin: 10px auto; margin-left: 12px" />--%>
        </div>
    </form>
</body>
</html>
