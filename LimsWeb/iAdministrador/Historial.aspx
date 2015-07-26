<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Administrador.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="LimsWeb.iAdministrador.AsociarParametro" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
    <script src="../Content/js/jquery-1.8.2.js"></script>
    <script src="../Content/js/jquery-1.8.2.min.js"></script>
    <script src="../Content/js/jquery-ui-1.8.24.js"></script>
    <script src="../Content/js/bootstrap.min.js"></script>
    <script src="../Content/js/jquery-ui-1.8.24.js"></script>
    <script src="../Content/js/jquery-ui-1.8.24.min.js"></script>

    <script>
        $(document).ready(function () {
            window.opener.location.reload();
        });

        function irConfigAttr(url) {
            window.open(url, 'ventana12', 'top=0,left=300,height=510,width=1000,scrollbars=1,resizable=1,location=no');
        }

        function irConfig(url) {
            window.open(url, 'ventana11', 'top=0,left=300,height=510,width=1000,scrollbars=1,resizable=1,location=no');
        }

        function irNuevaMuestra(url) {
            if ($("#cphAdministrador_qtProductos").val() == 0 && $("#cphAdministrador_qtAtributos").val()) {
                alert("Este producto no tiene parámetros ni atributos asociados. Debe asociar, como mínimo, un parámetro o atributo para crear muestras.");
            } else {
                window.open(url, 'ventana33', 'top=0,left=300,height=490,width=550,scrollbars=1,resizable=1,location=no');
            }
        }

        function irVistaGraficos(url) {
            if ($("#cphAdministrador_qtProductos").val() == 0 && $("#cphAdministrador_qtAtributos").val()) {
                alert("Este producto no tiene parámetros asociados. Debe asociar, como mínimo, un parámetro.");
            } else {
                window.open(url, 'ventana33', 'top=0,left=300,height=490,width=550,scrollbars=1,resizable=1,location=no');
            }
        }

        function irGenerarReportes(url) {
            if ($("#cphAdministrador_qtProductos").val() == 0 && $("#cphAdministrador_qtAtributos").val()) {
                alert("Este producto no tiene parámetros ni atributos asociados. Debe asociar, como mínimo, un parámetro o un atributo.");
            } else {
                window.open(url, 'ventana33', 'top=0,left=300,height=490,width=550,scrollbars=1,resizable=1,location=no');
            }
        }
    </script>

    <style>
        #ContenedorInfo {
            width: 93%;
            margin: 10px auto;
            border: 1px solid gray;
            border-radius: 4px;
            padding: 10px;
        }

        .etiquetas {
            margin-left: 6px;
            width: 90px;
            display: inline-block;
            /*background:orange;*/
            width: 100px;
        }

        .txtRO {
            width: 90px;
            display: inline-block;
            margin-top: 3px;
            background: #dedee2;
        }

        .inmovil {
            font-weight: bold;
            position: absolute;
            background-color: White;
            margin-top: -32px;
            width: 94% !important;
        }

        .gvCabecera {
            height: 30px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdministrador" runat="server">

    <div class="titulo" style="border-bottom: 1px solid blue; padding-top: 20px; padding-bottom: 4px; padding-left: 10px; width: 1080px; margin: auto;">
        <asp:Label ID="lblProducto" Text="[Producto]" Style="font-family: Verdana; font-size: 14px;" runat="server"></asp:Label>
    </div>

    <asp:Button runat="server" Text="Historial" CssClass="btn btn-primary" ID="btnHistorial" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; opacity: 0.7; border-radius: 0px; margin-left: 30px; margin-right: -4px;" />
    <asp:Button runat="server" Text="Gráficas de Control" CssClass="btn btn-primary" ID="btnInforme" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" OnClick="btnInforme_Click" />
    <asp:Button runat="server" Text="Config. Parametro   " CssClass="btn btn-primary" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" ID="Config" OnClientClick="irConfig('vAsociarParametro.aspx')" />
    <asp:Button runat="server" Text="Config. Atributo   " CssClass="btn btn-primary" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" ID="Button1" OnClientClick="irConfigAttr('vAsociarAtributo.aspx')" />
    <asp:Button runat="server" Text="Crear Muestra" CssClass="btn btn-primary" ID="btnCrearMuestra" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" OnClientClick="irNuevaMuestra('vCrearMuestra.aspx')" />
    <asp:Button runat="server" Text="Vista Gráficos" CssClass="btn btn-primary" ID="btnVistas" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" OnClientClick="irVistaGraficos('vVistaGraficos.aspx')" />
    <asp:Button runat="server" Text="Generar Reporte" CssClass="btn btn-primary" ID="btnGenerarReporte" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" OnClick="btnGenerarReporte_Click" />

    <div class="grilla" style="width: 94%; margin: 40px auto 0px 30px; height: 230px; overflow-y: auto;">
        <asp:GridView ID="gvMuestra" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="inmovil" HeaderStyle-Width="100%" Width="100%" CssClass="gvGeneral" RowStyle-CssClass="gvFilas" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
                <asp:BoundField HeaderText="Id Muestra" DataField="MuestraID" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="MuestraID" Visible="false">
                    <HeaderStyle Width="0px" CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="50px" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Id muestra" DataField="CodigoMuestra" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="CodigoMuestra">
                    <HeaderStyle Width="180px" CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="60px" CssClass="centerAlign" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Fecha de Creación" DataField="FechaRegistro" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="FechaRegistro" HtmlEncode="False" Visible="true" DataFormatString="{0:dd\/MM\/yyyy HH:mm:ss}">
                    <HeaderStyle Width="200px" CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="82px" CssClass="centerAlign" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Estado" DataField="NomEstado" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="NomEstado">
                    <HeaderStyle Width="180px" CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="48px" CssClass="centerAlign" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Creado Por" DataField="CreadoPor" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="CreadoPor" Visible="true">
                    <HeaderStyle Width="200px" CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="80px" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Fecha Terminado" DataField="FechaTerminado" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="FechaTerminado" Visible="true">
                    <HeaderStyle Width="200px" CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="65px" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="Info">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEditar" runat="server" Width="16px" ImageUrl="../Content/img/edit.png"
                            OnCommand="btnEditar_Command" ToolTip="Detalles" ImageAlign="Baseline" autopostback="true"
                            CommandArgument='<%# Eval("MuestraID") +
                                       "{" + Eval("CodigoMuestra")%>'
                            EnableTheming="false" />

                    </ItemTemplate>
                    <ItemStyle Width="40px" />


                    <HeaderStyle Width="70px" HorizontalAlign="Center" CssClass="gvCabecera" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEliminar" runat="server" Width="16px" ImageUrl="../Content/img/Eliminar.png"
                            CommandArgument='<%# Eval("MuestraID")%>'
                            OnClientClick="javascript:return confirm('¿Confirma Eliminacion del registro?');"
                            OnCommand="btnEliminar_Command" ToolTip="Eliminar" ImageAlign="Baseline" />
                    </ItemTemplate>
                    <ItemStyle Width="40px" />
                    <HeaderStyle Width="150px" HorizontalAlign="Center" CssClass="gvCabecera" />
                </asp:TemplateField>
            </Columns>


            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle Height="30px" HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />

            <RowStyle CssClass="gvFilas" VerticalAlign="Middle" BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div><br />

    <asp:Label ID="lblNombreMuestra" runat="server" Text="" Font-Size="16px" Font-Bold="true" Style="margin-left: 30px;"></asp:Label>
    <div class="grilla" style="width: 100%; margin: 35px auto 0px 30px; height: 180px; overflow-y: auto;">
        <asp:GridView ID="gvInfoMuestra" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="inmovil" CssClass="gvGeneral" RowStyle-CssClass="gvFilas" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Id Muestra Detalle" DataField="MuestraDetalleID" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="MuestraDetalleID" Visible="false">
                    <HeaderStyle CssClass="gvCabecera" BackColor="#0033CC"></HeaderStyle>
                    <ItemStyle Width="60px" />
                </asp:BoundField>

                <asp:BoundField HeaderText="MuestraID" DataField="MuestraID" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="MuestraID" Visible="false">
                    <HeaderStyle CssClass="gvCabecera" BackColor="#0033CC"></HeaderStyle>
                    <ItemStyle Width="60px" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Parametro/Atributo" DataField="NomParametro" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="NomParametro">
                    <HeaderStyle CssClass="gvCabecera" Width="150px"></HeaderStyle>
                    <ItemStyle Width="173px" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Prioridad" DataField="Prioridad" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="Prioridad" Visible="true">
                    <HeaderStyle CssClass="gvCabecera" Width="127px"></HeaderStyle>
                    <ItemStyle Width="128px" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Estado" DataField="NomEstado" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="NomEstado" Visible="true">
                    <HeaderStyle CssClass="gvCabecera" Width="100px"></HeaderStyle>
                    <ItemStyle Width="100px" />
                </asp:BoundField>

                <asp:TemplateField  HeaderText="Resultado" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="ResultadoAux">
                    <HeaderStyle CssClass="gvCabecera" Width="125px"></HeaderStyle>
                    <ItemTemplate>
                        <%# Eval("ResultadoAux").ToString() + " " + Eval("UnidadMedida").ToString() %>
                    </ItemTemplate>
                    <ItemStyle Width="128px" />
                </asp:TemplateField>

                <%--<asp:BoundField HeaderText="Resultado" DataField="ResultadoAux" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="ResultadoAux">
                    <HeaderStyle CssClass="gvCabecera" Width="125px"></HeaderStyle>
                    <ItemStyle Width="128px" />
                </asp:BoundField>--%>

                <asp:BoundField HeaderText="Fecha Inicio" DataField="FechaInicio" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="FechaInicio" Visible="true" DataFormatString="{0:dd-M-yyyy}">
                    <HeaderStyle CssClass="gvCabecera" Width="140px"></HeaderStyle>
                    <ItemStyle Width="145px" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Fecha Fin" DataField="FechaFin" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="FechaFin" Visible="true" DataFormatString="{0:g}">
                    <HeaderStyle CssClass="gvCabecera" Width="137px"></HeaderStyle>
                    <ItemStyle Width="135px" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Analista" DataField="Nombre" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="Nombre" Visible="true" DataFormatString="{0:g}">
                    <HeaderStyle CssClass="gvCabecera" Width="140px"></HeaderStyle>
                    <ItemStyle Width="135px" />
                </asp:BoundField>


                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEliminar" runat="server" Width="16px" ImageUrl="../Content/img/Eliminar.png"
                            CommandArgument='<%# Eval("MuestraDetalleID")  + "{" + Eval("MuestraID") %>' OnClientClick="javascript:return confirm('¿Confirma Eliminacion del registro?');"
                            OnCommand="btnEliminarMuestraDetalle_Command" ToolTip="Eliminar" ImageAlign="Baseline" />
                    </ItemTemplate>
                    <ItemStyle Width="105px" />
                    <HeaderStyle CssClass="gvCabecera" Width="85px"></HeaderStyle>
                </asp:TemplateField>
            </Columns>

            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle Height="30px" HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />

            <RowStyle CssClass="gvFilas" VerticalAlign="Middle" BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
    <asp:HiddenField ID="qtProductos" runat="server" />
    <asp:HiddenField ID="qtAtributos" runat="server" />
</asp:Content>
