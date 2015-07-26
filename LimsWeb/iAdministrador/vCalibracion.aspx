<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vCalibracion.aspx.cs" Inherits="LimsWeb.iAdministrador.vCalibracion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

      <script src="../Content/js/jquery-1.8.2.js"></script>
    <script src="../Content/js/bootstrap.min.js"></script>
    <link href="../Content/css/EstilosPopup.css" rel="stylesheet" />
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
    <script src="../Content/js/validaciones.js"></script>
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
     <script>
        function EditarProducto(lnk) {
            var row = lnk.parentNode.parentNode;
            $('#txtMantenimientoID').val(row.cells[0].innerHTML);
            //$('#txtProducto').val(row.cells[1].innerHTML);
            //$('#txtDescProducto').val(row.cells[2].innerHTML);

            $('#lblTitulo').text("Calibración Finalizada");
            $('#btnGuardar').val("Grabar");

            $('#PopUpProducto').modal('show');
        }

    </script>
<link href="../Content/css/bootstrap.css" rel="stylesheet" />
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

        .txts, .etqs {
            display:inline-block;
           
            font-size:14px;           
        }
           .etqs {
           margin-left:5px;
            width:110px;
           }  
           
           .txts {
           margin-left:5px;
            width:130px;
           }

           .btns {
           padding:3px 10px; 
           background:#428bca;
           color:white;
           border-radius:4px; 
           border:none; 
           margin-left:15px;
           transition: 0.5s all;
           cursor:pointer;
           }
           
           .btns:hover {
           opacity:0.8;
           }

    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background:#eee">
   <form id="form1" runat="server" style="margin:20px">
        <div class="etqs" style="font-weight:bold;font-size:large">
            <asp:Label runat ="server" text="CALIBRACIONES"></asp:Label>
        </div>


    <div style="background:none;display:inline-block;width:1000px;margin-top:10px ">
        <div class="etqs">
            <asp:Label runat ="server" text="Equipo"></asp:Label>
        </div>
        <asp:DropDownList  style="width:306px" runat="server" class="txts" ID="ddlEquipo"></asp:DropDownList>
        <br />

        <div class="etqs">
            <asp:Label runat ="server" text="Fecha Programada"></asp:Label>
        </div>
        <asp:TextBox runat="server" class="txts" TextMode="Date"  ID="txtFecProgramada" style="height:27px;margin-top:4px;width:130px"></asp:TextBox>
        <asp:RequiredFieldValidator  ValidationGroup="nuevosDatos" ID="rfvFecProg" ControlToValidate="txtFecProgramada" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

<%--        <div class="etqs">
            <asp:Label runat ="server" text="Fecha Realizada"></asp:Label>
        </div>
        <asp:TextBox runat="server" class="txts" TextMode="Date"  ID="txtFecRealizada"></asp:TextBox>
        <br />--%>

        <div class="etqs" style="width:100px">
            <asp:Label runat ="server" text="Patrón/estándar"></asp:Label>
        </div>
        <asp:TextBox runat="server" class="txts" ID="txtIso" autocomplete="off"></asp:TextBox>
        <asp:RequiredFieldValidator  ValidationGroup="nuevosDatos"  ID="rfvIso" ControlToValidate="txtIso" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>



         <div class="etqs" style="width:60px">
            <asp:Label runat ="server" text="Operador"></asp:Label>
        </div>
        <asp:TextBox runat="server" class="txts" ID="txtOperador" autocomplete="off"></asp:TextBox>
        <asp:RequiredFieldValidator  ValidationGroup="nuevosDatos"  ID="rfvOperador" ControlToValidate="txtOperador" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

      <%--  <div class="etqs">
            <asp:Label runat ="server" text="Observaciones"></asp:Label>
        </div>
        <asp:TextBox runat="server" class="txts" ID="txtObservaciones"></asp:TextBox>--%>
        <asp:Button runat="server"   ValidationGroup="nuevosDatos"   text="Agregar Calibración" CssClass="btns" ID="btnCrear" OnClick="btnCrear_Click"/>

        <br />

        <br />

            <div class="grilla" style="background:none;height:380px; overflow-y:auto">
                <asp:GridView ID="gvCalibracion" runat="server" AutoGenerateColumns="false" GridLines="None">
 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <Columns>

                 <asp:BoundField HeaderText=" _Id" DataField="CalibracionID" HeaderStyle-CssClass="gvCabecera" Visible="false"
                    SortExpression="CalibracionID">
                    <HeaderStyle CssClass="gvCabecera" Height="25px" ></HeaderStyle>
                    <ItemStyle Width="10px" />
                     
                </asp:BoundField> 

                <asp:BoundField HeaderText="Nombre" DataField="NombreEquipo" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="NombreEquipo">
                    <HeaderStyle CssClass="gvCabecera" Height="25px" ></HeaderStyle>
                    <ItemStyle Width="400px" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Patrón/estándar" DataField="ISO" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="Patrón/estándar">
                    <HeaderStyle CssClass="gvCabecera" Height="25px" ></HeaderStyle>
                    <ItemStyle Width="50px" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Estado" DataField="NomEstado" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="Estado">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="100px" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Fecha Programada" DataField="FechaProgramacionAux" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="FechaProgramacion">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="250px" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Fecha Realizado" DataField="FechaRealizadoAux" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="FechaRealizado">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="300px" />
                </asp:BoundField>


                <asp:BoundField HeaderText="Operador" DataField="Operador" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="Operador">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="150px" />
                </asp:BoundField>


                 <asp:BoundField HeaderText="Observaciones" DataField="Observacion" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="Observaciones">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    <ItemStyle Width="300px" />
                </asp:BoundField>

                
            <asp:TemplateField HeaderText="Terminar" >
            <ItemTemplate>
                <asp:ImageButton ID="btnEditar" runat="server" Width="16px" ImageUrl="../Content/img/edit.png" 
                    CommandArgument='<%# Eval("CalibracionID") %>'
                     ToolTip="Editar" ImageAlign="Baseline" autopostback="true"
                    EnableTheming="false" OnClientClick="EditarProducto(this);return false;" />
   
                </ItemTemplate>
                <ItemStyle Width="60px" />
            
                  <%--OnClientClick="MostrarPopUpProducto();return false;"/>--%>

            <HeaderStyle CssClass="gvCabecera" HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Eliminar">
            <ItemTemplate>
                <asp:ImageButton ID="btnEliminar" runat="server" Width="16px" ImageUrl="../Content/img/Eliminar.png"
                   OnCommand="btnEliminar_Command" CommandArgument='<%# Eval("CalibracionID") %>' OnClientClick="javascript:return confirm('¿Confirma Eliminacion del registro?');"
                     ToolTip="Eliminar" ImageAlign="Baseline" />
                </ItemTemplate>
                <ItemStyle Width="80px" />
            <HeaderStyle CssClass="gvCabecera" HorizontalAlign="Center" />
            </asp:TemplateField>
          

                </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle  HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

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


              <!-- Modal  -->
   <div class="modal fade" id="PopUpProducto" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="false">  
       <div class="modal-dialog"  >    
            <div class="modal-content"  style="width:400px;height:280px; margin-left:105px; margin-top:100px;">
                       <div class="modal-header" style="background:#428bca; color:white; font-weight:bolder;">
                           <button type="button" class="close" data-dismiss="modal" style="color:white;" aria-hidden="true">&times;</button>
                                   <h4 class="modal-title" id="myModalLabel" >
                                       <asp:label runat="server" ID="lblTitulo" Text=""></asp:label>
                                   </h4> 
                        </div>   
                   
                 <div class="modal-body" style="color:black; ">

                     <%--<iframe id="PopUpProd" name="PopUpProd" src="../Popup/Producto.aspx" width="100%"  height="600px" align="center" frameborder="0"></iframe>--%>
                     
                     <br />
                     <table style="margin:auto;">
                         <tr style="visibility:hidden">
                             <td style="width:120px;">Id. Mantenimiento</td>
                             <td> <asp:TextBox ID="txtMantenimientoID"   ValidationGroup="Popup" CssClass="popupTxts" runat="server" OnKeyPress="SoloLectura()" style="background:#d9d9d9; "></asp:TextBox>
                                
                             </td>
                         </tr>
                         <tr>
                             <td>Fecha Finalizado</td>
                             <td><asp:TextBox ID="txtFecRealizado" TextMode="date" CssClass="popupTxts" Height="27px" Width="143px" runat="server"></asp:TextBox>
                                   <asp:RequiredFieldValidator  ValidationGroup="Popup" ID="rfvFecRealizado" ControlToValidate="txtFecRealizado" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                             </td>
                         </tr>
                         <tr>
                             <td>Observaciones</td>
                             <td><asp:TextBox ID="txtObservaciones" CssClass="popupTxts"  runat="server"></asp:TextBox>
                                   <asp:RequiredFieldValidator  ValidationGroup="Popup" ID="rfvObs" ControlToValidate="txtObservaciones" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>


                             </td>
                         </tr>
                     </table>

                     <br />
                     <div style="text-align:center;">
                        <asp:Button runat="server" ValidationGroup="Popup" class="btn btn-primary btn-sm" ID="btnGuardar" Text="Actualizar" style="margin:auto;" OnClientClick="javascript:return ValidarCampos();" OnClick="btnGuardar_Click"/>
                        <asp:Button runat="server" class="btn btn-primary btn-sm" ID="btnCancelar" Text="Cancelar" style="margin:auto;" OnClick="btnCancelar_Click"/>
                     </div>                          
                 </div>      
                       <%-- <div class="modal-footer">        
                     <asp:Button   runat="server" ID="btnVolver" class="btn btn-default" OnClick="btnVolver_Click" Text="Volver"/>
                 </div> --%>
             </div>  
         </div>
    </div> <!-- FIN Modal -->


    </form>
</body>
</html>
