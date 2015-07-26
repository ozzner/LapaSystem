<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Administrador.Master" AutoEventWireup="true" CodeBehind="AsociarProducto.aspx.cs" Inherits="LimsWeb.iAdministrador.AsociarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function irConfig(url) {
            window.open(url, 'ventanaCOnfigProducto', 'top=0,left=200,height=500,width=700,scrollbars=1,resizable=1,location=no');
        }
        function AgregarProducto(url) {
            window.open(url, 'AgregarProducto', 'top=0,left=200,height=610,width=725,scrollbars=1,resizable=1,location=no');
        }
        function irMantenimiento(url) {
            window.open(url, 'irMantenimiento', 'top=0,left=200,height=540,width=1050,scrollbars=1,resizable=1,location=no');
        }
        function irCalibracion(url) {
            window.open(url, 'irCalibracion', 'top=0,left=200,height=610,width=1025,scrollbars=1,resizable=1,location=no');
        }
    </script>
    <style>
        .graficos {
            width: 48%;
            display: inline-block;
            height: 250px;
            background: none;
            border-radius: 5px;
            border: 1px solid #ccc;
            float: left;
            margin-right: 4px;
            margin-bottom: 4px;
        }
        
        .tituloInfo {
            border-bottom: 1px solid gray;
            padding: 10px 0px;
            text-align: left;
            padding-left: 20px;
            font-weight: bold;
            opacity: 0.7;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdministrador" runat="server">

    <div class="titulo" style="border-bottom: 1px solid blue; padding-top: 20px; padding-bottom: 4px; padding-left: 10px; width: 1080px; margin: auto;">
        <asp:Label ID="lblLaboratorio" Text="[Laboratorio]" Style="font-family: Verdana; font-size: 14px;" runat="server"></asp:Label>
    </div>


    <% if(Boolean.Parse(Session["Servicio"].ToString()) == true){ %>
        <asp:Button runat="server" Text="Agregar Producto" CssClass="btn btn-primary" ID="Button3" OnClientClick="AgregarProducto('vAsociarProductoCliente.aspx')" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-left: 18px; margin-right: -4px" />
    <% } else { %>
        <asp:Button runat="server" Text="Agregar Producto" CssClass="btn btn-primary" ID="Config" OnClientClick="AgregarProducto('vAsociarProducto.aspx')" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-left: 18px; margin-right: -4px" />
    <% } %>
    <asp:Button runat="server" Text="Equipos" CssClass="btn btn-primary" ID="btnConfingEquipos" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" OnClientClick="irConfig('vEquipo.aspx')" />
    <asp:Button runat="server" Text="Conf. Mantenimientos" CssClass="btn btn-primary" ID="Button1" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px; width: 170px" OnClientClick="irMantenimiento('vMantenimiento.aspx')" />
    <asp:Button runat="server" Text="Con. Calibraciones" CssClass="btn btn-primary" ID="Button2" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px; width: 170px" OnClientClick="irCalibracion('vCalibracion.aspx')" />
    <asp:Button runat="server" Text="Generar Reporte" CssClass="btn btn-primary" ID="btnGenerarReporte" Style="width: 150px; margin-top: 5px; padding-top: 3px; padding-bottom: 3px; border-radius: 0px; margin-right: -4px;" OnClick="btnGenerarReporte_Click" />

    <br />
    <br />

    <div class="graficos" style="margin-left: 20px; width: 380px">
        <link href="../Content/css/main_fonts.css" rel="stylesheet" />
        <div class="tituloInfo">PRODUCTOS </div>
     
        <div class="grilla" style="margin: auto; background: green; width: 350px;margin-top:10px">

            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false" HeaderStyle-Height="30px" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>

                    <asp:BoundField HeaderText="Producto" DataField="NombreProducto" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="NombreProducto">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="100px" />
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Descripción" DataField="DescProducto" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="DescProducto">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="250px" />
                    </asp:BoundField>

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
    <div class="graficos" style="width: 390px">
     
        <div class="tituloInfo">PARAMETROS </div>

        <div class="grilla" style="margin: auto; background: none; width: 345px;margin-top:10px">
            <asp:GridView ID="gvParametro" runat="server" AutoGenerateColumns="false" HeaderStyle-Height="30px" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>

                    <asp:BoundField HeaderText="Nombre" DataField="NomParametro" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="NomParametro">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="150px" />
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Pertenece a" DataField="NomProducto" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="NomProducto">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="200px" />
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Unidad de Medida" DataField="NomUM" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="NomUM">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="300px" />
                    </asp:BoundField>

                    <%--<asp:BoundField HeaderText="Tiempo Estimado" DataField="TiempoEstimado" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="TiempoEstimado">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="300px" />
                    </asp:BoundField>--%>

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



    <div class="graficos" style="width: 297px;">
   
        <div class="tituloInfo">ATRIBUTOS </div>

        <div class="grilla" style="margin-left: 15px; background: none; width: 100%;margin-top:10px">
            <asp:GridView ID="gvAtributos" runat="server" Width="89%" AutoGenerateColumns="false" HeaderStyle-Height="30px" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>

                    <%--<asp:BoundField HeaderText="ProdAtriID" DataField="ProdAtriID" Visible="false" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="NomParametro">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="150px" />
                    </asp:BoundField>--%>

                    <asp:BoundField HeaderText="Nombre" DataField="NomAtributo" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="NomAtributo">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="200px" />
                    </asp:BoundField>

                    <%--                <asp:BoundField HeaderText="Unidad de Medida" DataField="NomUM" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="NomUM">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="300px" />
                </asp:BoundField>--%>

                    <%--          <asp:BoundField HeaderText="Tiempo Estimado" DataField="TiempoEstimado" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="TiempoEstimado">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="300px" />
                </asp:BoundField>--%>
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
    <div class="graficos" style="margin-left: 20px">

        <div class="tituloInfo">MANTENIMIENTOS PENDIENTES </div>

        <div class="grilla" style="height: 200px; background: none; width: 95%; overflow-y: auto;margin-top:10px">
            <asp:GridView ID="gvManteminiento" runat="server" AutoGenerateColumns="false" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>

                    <%--           <asp:BoundField HeaderText=" _Id" DataField="MantenimientoID" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="MantenimientoID">
                    <HeaderStyle CssClass="gvCabecera" Height="25px" ></HeaderStyle>
                    <ItemStyle Width="10px" />
                </asp:BoundField>--%>

                    <asp:BoundField HeaderText="Nombre" DataField="NombreEquipo" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="NombreEquipo">
                        <HeaderStyle CssClass="gvCabecera" Height="25px"></HeaderStyle>
                        <ItemStyle Width="250px" />
                    </asp:BoundField>



                    <%--                <asp:BoundField HeaderText="Estado" DataField="NomEstado" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="Estado">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="100px" />
                </asp:BoundField>--%>

                    <asp:BoundField HeaderText="Fecha Programada" DataField="FechaProgramacionAux" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="FechaProgramacion">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="150px" />
                    </asp:BoundField>

                    <%--     <asp:BoundField HeaderText="Fecha Realizado" DataField="FechaRealizadoAux" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="FechaRealizado">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="200px" />
                </asp:BoundField>--%>


                    <asp:BoundField HeaderText="Operador" DataField="Operador" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="Operador">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="150px" />
                    </asp:BoundField>


                    <%--   <asp:BoundField HeaderText="Observaciones" DataField="Observacion" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="Observaciones">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="300px" />
                </asp:BoundField>--%>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />

                <RowStyle CssClass="gvFilas" BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small"></RowStyle>
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

            </asp:GridView>
        </div>
    </div>
    <div class="graficos">

        <div class="tituloInfo">CALIBRACIONES PENDIENTES </div>

        <div class="grilla" style="height: 200px; background: none; width: 95%; overflow-y: auto;margin-top:10px">
            <asp:GridView ID="gvCalibracion" runat="server" AutoGenerateColumns="false" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>

                    <%--           <asp:BoundField HeaderText=" _Id" DataField="MantenimientoID" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="MantenimientoID">
                    <HeaderStyle CssClass="gvCabecera" Height="25px" ></HeaderStyle>
                    <ItemStyle Width="10px" />
                </asp:BoundField>--%>

                    <asp:BoundField HeaderText="Nombre" DataField="NombreEquipo" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="NombreEquipo">
                        <HeaderStyle CssClass="gvCabecera" Height="25px"></HeaderStyle>
                        <ItemStyle Width="250px" />
                    </asp:BoundField>



                    <%--                <asp:BoundField HeaderText="Estado" DataField="NomEstado" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="Estado">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="100px" />
                </asp:BoundField>--%>

                    <asp:BoundField HeaderText="Fecha Programada" DataField="FechaProgramacionAux" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="FechaProgramacion">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="150px" />
                    </asp:BoundField>

                    <%--     <asp:BoundField HeaderText="Fecha Realizado" DataField="FechaRealizadoAux" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="FechaRealizado">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="200px" />
                </asp:BoundField>--%>


                    <asp:BoundField HeaderText="Operador" DataField="Operador" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="Operador">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="150px" />
                    </asp:BoundField>


                    <%--   <asp:BoundField HeaderText="Observaciones" DataField="Observacion" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="Observaciones">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="300px" />
                </asp:BoundField>--%>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />

                <RowStyle CssClass="gvFilas" BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small"></RowStyle>
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

            </asp:GridView>
        </div>

    </div>

</asp:Content>
