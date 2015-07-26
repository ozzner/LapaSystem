<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vAsociarProductoCliente.aspx.cs" Inherits="LimsWeb.iAdministrador.vAsociarProductoCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../Content/js/jquery-1.8.2.js"></script>
    <script src="../Content/js/bootstrap.min.js"></script>
    <link href="../Content/css/EstilosPopup.css" rel="stylesheet" />
    <script src="../Content/js/validaciones.js"></script>
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />
    <link href="../Content/css/mpage_analista.css" rel="stylesheet" />
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />

    <script>
        $(document).ready(function () {
            window.opener.location.reload();
        });

    </script>
        <style>
        * {
           
            font-family:Calibri;
        }
        .gvGeneral {
            margin:0;           
        }
        .gvCabecera {
            font-weight:lighter;
            color:white;
            text-align:center;  
            background:#428bca;
        }
        .gvFilas {
            text-align:center;
        }

        .grilla {
            width:100%;
            margin:0 auto;
        }

        .tab {
            width: 95%;
            margin: 0 auto;
        }

        .grupoBotones {
            margin-top:20px;
            margin-left:20px;   
        }

    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Productos</title>
</head>
<body style="background: #eee;">
    <form id="form1" runat="server">
        <div class="titulo" style="border-bottom: 1px solid blue; padding-top: 20px; padding-bottom: 4px; padding-left: 10px; width: 98%; margin: auto;">
            <asp:Label ID="lblLaboratorio" Text="[Laboratorio]" Style="font-family: Verdana; font-size: 14px;" runat="server"></asp:Label>
        </div>

        <div style="background: none; width: 608px; margin: 20px auto;">

            <table>
                <tr>
                    <td style="width: 50px">Producto
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlProducto" Width="140px" Style="margin-right: 10px"></asp:DropDownList>
                    </td>
                    <td style="width: 50px">Cliente
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlCliente" Width="140px"></asp:DropDownList>
                    </td>
                    <td style="width: 140px">
                        <asp:Button runat="server" ID="btnAgregar" Text="Agregar" CssClass="btn btn-primary" Style="width: 100%; padding: 1px 10px; margin-left: 10px" OnClick="btnAgregar_Click" />
                    </td>
                </tr>

            </table>
            <br />

            <div class="grilla" style="height: 300px; overflow-y: auto;">
                <asp:GridView ID="gvProdLab" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="gvCabecera" Width="100%" CssClass="gvGeneral" RowStyle-CssClass="gvFilas" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ProdLabID" HeaderStyle-CssClass="gvCabecera"
                            SortExpression="ProductoID" Visible="true">
                            <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                            <ItemStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Producto" DataField="NombreProducto" HeaderStyle-CssClass="gvCabecera"
                            SortExpression="NomProducto">
                            <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                            <ItemStyle Width="200px" />
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Cliente" DataField="NomCliente" HeaderStyle-CssClass="gvCabecera"
                            SortExpression="NomCliente">
                            <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        </asp:BoundField>


                        <asp:TemplateField HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEliminar" runat="server" Width="16px" ImageUrl="../Content/img/Eliminar.png"
                                    CommandArgument='<%# Eval("ProdLabID") %>' OnClientClick="javascript:return confirm('¿Confirma Eliminacion del registro?');"
                                    OnCommand="btnEliminar_Command" ToolTip="Eliminar" ImageAlign="Baseline" />
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



        </div>
    </form>
</body>
</html>
