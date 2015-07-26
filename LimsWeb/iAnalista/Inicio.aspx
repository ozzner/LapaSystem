<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Analista.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="LimsWeb.iAnalista.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Content/css/inicio_analista.css" rel="stylesheet" />
    <script src="../Content/js/jquery.countdownandup.js"></script>
    <script src="../Content/js/validaciones.js"></script>
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
   
     <style>
        #ContentPlaceHolder1_btnActualizar 
        {
            float: right;
            margin: -6px 5% 0 0;
            border: 2.5px solid white;
        }
    </style>
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <div class="contenedor_main">Main contaniner</div>--%>

    <div style="background: none;">
        <div class="contProcesos" style="float: right; background: none;">
            <div class="cuadroProcesos" style="margin-left: -15px;">
                <div class="tituloProcesos">
                    EN PROCESO
                </div>

                <div class="grilla" style="height: 200px; overflow-y: auto; width: 90%; background: none; margin-top: 20px;">
                    <asp:GridView ID="gvEnProceso" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="gvCabecera" Width="100%" CssClass="gvGeneral" RowStyle-CssClass="gvFilas" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="white" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="Id.MuestraDetalle" DataField="MuestraDetalleID" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="MuestraDetalleID" Visible="false">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                                <ItemStyle Width="50px" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="Muestra" DataField="CodigoMuestra" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="CodigoMuestra">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                                <ItemStyle Width="100px" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="Parametro/Atributo" DataField="NomParametro" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="NomParametro">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                            </asp:BoundField>

                            <asp:BoundField HeaderText="Formula" DataField="Formula" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="Formula" Visible="false">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                                <ItemStyle Width="100px" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="TipoParametroID" DataField="TipoParametroID" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="TipoParametroID" Visible="False">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                                <ItemStyle Width="150px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="FechaFinEstimado" Visible="false" />

                            <asp:TemplateField HeaderText="Opciones">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEliminar" runat="server" Width="16px" ImageUrl="../Content/img/view_details_64.png"
                                        CommandArgument='<%# Eval("MuestraDetalleID")  + "{" + Eval("TipoParametroID")  + "{" + Eval("NomParametro") + "{" + Eval("CodigoMuestra") + "{" + Eval("Formula") + "{" + Eval("FechaFinEstimado") %>'
                                        OnCommand="btnPasarAEnProceso_Command" ToolTip="Detalles" ImageAlign="Baseline" />&nbsp;&nbsp;&nbsp;
                                    <asp:ImageButton ID="btnVolver" runat="server" Width="16px" ImageUrl="../Content/img/return.png"
                                        CommandArgument='<%# Eval("MuestraDetalleID") %>'
                                        OnCommand="btnVolverAEnCola_Command" ToolTip="Volver a Pendiente" ImageAlign="Baseline" />
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                                <HeaderStyle CssClass="gvCabecera" HorizontalAlign="Center" />
                            </asp:TemplateField>

                        </Columns>

                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />

                        <RowStyle CssClass="gvFilas" BackColor="#F7F6F3" ForeColor="#333333" Height="25px"></RowStyle>
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>

            </div>
            <div class="cuadroProcesos">
                <div class="tituloProcesos">
                    MUESTRAS TERMINADAS
                </div>


                <div class="grilla" style="height: 210px; overflow-y: auto; width: 90%; background: none; margin-top: 10px">
                    <asp:GridView ID="gvTerminados" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="gvCabecera" Width="100%" CssClass="gvGeneral" RowStyle-CssClass="gvFilas" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="white" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="Id.MuestraDetalle" DataField="MuestraDetalleID" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="MuestraDetalleID" Visible="false">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                                <ItemStyle Width="50px" />
                            </asp:BoundField>


                            <asp:BoundField HeaderText="Muestra" DataField="CodigoMuestra" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="CodigoMuestra">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                                <ItemStyle Width="200px" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="Parametro/Atributo" DataField="NomParametro" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="NomParametro">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                                <ItemStyle Width="150px" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="Producto" DataField="NomProducto" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="NomProducto">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                                <ItemStyle Width="100px" />
                            </asp:BoundField>

                            <%--<asp:BoundField HeaderText="Resultado" DataField="Resultado" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="Resultado">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                                <ItemStyle Width="150px" />
                            </asp:BoundField>--%>
                            <asp:TemplateField  HeaderText="Resultado" HeaderStyle-CssClass="gvCabecera"
                                SortExpression="Resultado">
                                <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                                <ItemTemplate>
                                    <%# Eval("Resultado").ToString() + " " + Eval("UnidadMedida").ToString() %>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                        </Columns>

                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />

                        <RowStyle CssClass="gvFilas" BackColor="#F7F6F3" ForeColor="#333333" Height="25px"></RowStyle>
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>

            </div>


            <div style="box-shadow: 2px 2px 5px 2px rgba(188,188,188,0.6); border: 1px solid #eee; background: none; width: 95.5%; margin-left: 2%; height: 260px; margin: 2%; margin-left: 0px; display: inline-block;">
                <div class="tituloProcesos">
                    REGISTRO DE RESULTADO
                </div>

                <div class="main_detalle">
                    <div class="opc_detalle">DETALLE DEL PROCESO</div>

                    <div class="box_detalle">


                        <div class="txt_muestra">

                            <div class="labels">
                                <div class="lbl_parametros"></div>
                                <asp:Label runat="server" Text='Muestra'></asp:Label><br/>
                                <div class="lbl_parametros"></div>
                                <asp:Label ID="para_atri" runat="server" Text='Parametros'></asp:Label>
                            </div>

                            <div class="labels">
                                <asp:TextBox CssClass="textbox" runat="server" AutoComplete = "off" ID="txtMuestraa" ReadOnly></asp:TextBox>
                                <div class="lbl_parametros"></div>
                                <asp:TextBox CssClass="textbox" runat="server" AutoComplete = "off" ID="txtParametroo" ReadOnly></asp:TextBox>
                            </div>

                        </div>



                        <%--    <div class="txt_muestra">
                       
                    </div>--%>


                        <div class="scroll_detalle" id="scrollProcesoDetalle" runat="server">

                            <asp:Repeater ID="repResultado" runat="server">
                                <ItemTemplate>
                                    <div class="scroll_label">
                                        <asp:Label runat="server" CssClass="lbl_titulo" ID="lblTitulo" Text='<%#Eval("Nombre") %>'></asp:Label>
                                        <asp:TextBox CssClass="textbox" AutoComplete = "off" runat="server" ID="txtResultado" Width="100%"></asp:TextBox>
                                   <%-- <asp:RequiredFieldValidator ID="rfvResultado" ValidationGroup="valores" runat="server" ErrorMessage="*" ForeColor="red" ControlToValidate="txtResultado"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                           
                        </div>

                    </div>
                </div>

                <div class="main_equipo">
                    <div class="content_timer">

                        <div class="opc_atributo">
                            <asp:Label runat="server" class="lbl_atributo" ID="lblEqpUtilizados" Text="OPCIONES"></asp:Label>
                        </div>

                        <span class="tiempo_restante">TIEMPO RESTANTE</span>
                    </div>
                      <%--<label id="MyTimer" class="timer_number" runat="server">23:09</label>--%>
                       <asp:TextBox runat="server" ID="txtTimeFin" CssClass="hide_evidence"></asp:TextBox>
                       <div id="MyTimer"></div>

                    <div class="box_equipo">
                        <div class="opc_equipo">
                            <asp:CheckBoxList ID="chkEquipoUsado" CssClass="radioButton_style" runat="server"></asp:CheckBoxList>
                        </div>
                        <div class="lista_detalle">
                            <asp:RadioButtonList ID="repOpcion" CssClass="radioButton_style" runat="server"></asp:RadioButtonList>
                        </div>
                    </div>



                    <div id="btnTerminar">
                        <asp:Button runat="server" ID="btnTerminar" class="btnCerrar" ValidationGroup="valores" Text="Terminar"  OnClick="btnTerminar_Click" OnClientClick="javascript:return confirm('¿Esta seguro de registrar los datos ingresados?');" />
                    </div>
                </div>

                <div style="display: inline-block; width: 117px">

                    <div style="visibility: hidden">
                        <div style="display: inline-block; width: 117px">
                            <asp:Label runat="server" Text='MuestraDetalle'></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtMuestraDetalleID" Style="margin-top: 4px"></asp:TextBox>
                        <div style="display: inline-block; width: 117px">
                            <asp:Label runat="server" Text='Formula'></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtFormula" Style="margin-top: 4px"></asp:TextBox>

                        <div style="display: inline-block; width: 117px">
                            <asp:Label runat="server" Text='TipoParametro'></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtTipoParametroID" Style="margin-top: 4px"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div style="background: none; border: 1px solid gray; box-shadow: 2px 2px 5px 2px rgba(188,188,188,0.6); border: 1px solid #eee; width: 400px; float: left; height: 400px; margin: 10px 0px 10px 10px; display: inline-block">
            <div class="tituloProcesos">
                <span>TAREAS PENDIENTES</span>
                <asp:Button runat="server" ID="btnActualizar" CssClass="btn btn-primary btn-sm" Text="Actualizar Tareas" OnClick="btnActualizar_Click" />
            </div>

            <div class="grilla" style="height: 310px; overflow-y: auto; width: 90%; background: none; margin-top: 20px">
                <asp:GridView ID="gvMuestra" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="gvCabecera" Width="100%" CssClass="gvGeneral" RowStyle-CssClass="gvFilas" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="white" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField HeaderText="Id.MuestraDetalle" DataField="MuestraDetalleID" HeaderStyle-CssClass="gvCabecera"
                            SortExpression="MuestraDetalleID" Visible="false">
                            <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                            <ItemStyle Width="50px" />
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Muestra" DataField="CodigoMuestra" HeaderStyle-CssClass="gvCabecera"
                            SortExpression="CodigoMuestra">
                            <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                            <ItemStyle Width="100px" />
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Parametro/Atributo" DataField="NomParametro" HeaderStyle-CssClass="gvCabecera"
                            SortExpression="NomParametro">
                            <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" Width="16px" ImageUrl="../Content/img/derecha.png"
                                    CommandArgument='<%# Eval("MuestraDetalleID") %>'
                                    OnCommand="btnPasarATerminado_Command" ToolTip="Escoger Muestra" ImageAlign="Baseline" />&nbsp;&nbsp;
                                <asp:ImageButton ID="ImageButton2" runat="server" Width="16px" ImageUrl="../Content/img/view_details_64.png"
                                    CommandArgument='<%# Eval("FechaRegistro")  + "{" + Eval("NomProducto") + "{" + Eval("Prioridad") %>'
                                    OnCommand="btnLlenarMD_Command" ToolTip="Detalle Muestra" ImageAlign="Baseline" />
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                            <HeaderStyle CssClass="gvCabecera" HorizontalAlign="Center" />
                        </asp:TemplateField>

                    </Columns>

                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />

                    <RowStyle CssClass="gvFilas" BackColor="#F7F6F3" ForeColor="#333333" Height="25px"></RowStyle>
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>

            </div>
        </div>
        <div style="box-shadow: 2px 2px 5px 2px rgba(188,188,188,0.6); border: 1px solid #eee; background: none; width: 400px; margin-left: 10px; height: 158px; display: inline-block;">
                <div class="tituloProcesos">DETALLES DE MUESTRA</div><br />
                <div class="txt_muestra" style="margin-left:10px;">
                    <div class="labels">
                        <div class="lbl_parametros"></div>
                        <asp:Label runat="server" Text='Producto'></asp:Label><br/>
                        <div class="lbl_parametros"></div>
                        <asp:Label runat="server" Text='Prioridad'></asp:Label>
                        <div class="lbl_parametros"></div>
                        <asp:Label runat="server" Text='Fecha Creación'></asp:Label>
                    </div>
                    <div class="labels">
                        <asp:TextBox CssClass="textbox" runat="server" AutoComplete = "off" ID="prodMD" ReadOnly></asp:TextBox>
                        <div class="lbl_parametros"></div>
                        <asp:TextBox CssClass="textbox" runat="server" AutoComplete = "off" ID="prioMD" ReadOnly></asp:TextBox>
                        <div class="lbl_parametros"></div>
                        <asp:TextBox CssClass="textbox" runat="server" AutoComplete = "off" ID="fechMD" ReadOnly></asp:TextBox>
                    </div>
                </div>
        </div>
</asp:Content>