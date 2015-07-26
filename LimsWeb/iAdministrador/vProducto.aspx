<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vProducto.aspx.cs" EnableEventValidation="true" Inherits="LimsWeb.iAdministrador.vProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Content/js/jquery-1.8.2.js"></script>
    <script src="../Content/js/bootstrap.min.js"></script>
    <link href="../Content/css/EstilosPopup.css" rel="stylesheet" />
    <script src="../Content/js/validaciones.js"></script>
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />
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

         #buttonsPopUp {
            float: right;
            margin-right: 17.5%;
        }

        .hideEvidence {
            display: none !important;
        }

    </style>

    <script>



        function EditarProducto(lnk) {
            var row = lnk.parentNode.parentNode;
            $('#txtProductoID').val(row.cells[0].innerHTML);
            $('#txtProducto').val(row.cells[1].innerHTML);
            $('#txtDescProducto').val(row.cells[2].innerHTML);

            $('#lblTitulo').text("Actualizar Producto");
            $('#btnGuardar').val("Actualizar");

            $('#PopUpProducto').modal('show');
        }

        function NuevoProducto() {
            $('#lblTitulo').text("Nuevo Producto");
            $('#btnGuardar').val("Crear");

            $('#txtProductoID').val('');
            $('#txtProducto').val('');
            $('#txtDescProducto').val('');
            $('#PopUpProducto').modal('show');
        }

        function ValidarCampos() {

            if ($('#txtProducto').val().length == 0) {
                alert('Ingresa nombre de producto');
                $('#txtProducto').focus();
                return false;
            }

            if ($('#txtDescProducto').val().length == 0) {
                alert('Ingresa descripcion del producto');
                $('#txtDescProducto').focus();
                return false;
            }
            else {

                return true;
            }


        }


    </script>
 
</head>

<body style="background:#eee">
       <script>
       </script>

    <form id="form1" runat="server">
    <div>
        <div class="grupoBotones">
            
                          <asp:Button runat="server" ID="btnIrPopup" Text="Nuevo" 
                          CssClass="btn btn-primary btn-sm" OnClientClick="NuevoProducto();  return false;"/>

        </div>
        
            <br />


<div class="tabbable tab"> 
  <ul class="nav nav-tabs">
    <li class="active"><a href="#tab1" data-toggle="tab">Listado</a></li>
   </ul>
  <div class="tab-content" style="border:1px solid #d9d9d9; border-bottom-left-radius:5px;border-bottom-right-radius:5px; padding:15px;">
    <div class="tab-pane active" id="tab1">
      
   
    <div class="grilla"  style="height:430px; overflow-y:auto;">
            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="gvCabecera" Width="100%"  CssClass="gvGeneral" RowStyle-CssClass ="gvFilas" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
            <asp:BoundField DataField="ProductoID"  HeaderStyle-CssClass="hideEvidence"
                    SortExpression="ProductoID" Visible="true">
<HeaderStyle CssClass="hideEvidence"></HeaderStyle>

                <ItemStyle Width="50px" CssClass="hideEvidence" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Producto" DataField="NombreProducto" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="NombreProducto">
<HeaderStyle CssClass="gvCabecera"></HeaderStyle>

                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Descripcion" DataField="DescProducto" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="DescProducto">

<HeaderStyle CssClass="gvCabecera"></HeaderStyle>

            </asp:BoundField>
            <asp:TemplateField HeaderText="Editar" >
            <ItemTemplate>
                <asp:ImageButton ID="btnEditar" runat="server" Width="16px" ImageUrl="../Content/img/edit.png" 
                    CommandArgument='<%# Eval("NombreProducto") + "{" + Eval("DescProducto") + "{" + Eval("ProductoID") %>'
                    OnCommand="btnEditar_Command" ToolTip="Editar" ImageAlign="Baseline" autopostback="true"
                    EnableTheming="false" OnClientClick="EditarProducto(this);return false;" />
   
                </ItemTemplate>
                <ItemStyle Width="60px" />
            
                  <%--OnClientClick="MostrarPopUpProducto();return false;"/>--%>

            <HeaderStyle CssClass="gvCabecera" HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Eliminar">
            <ItemTemplate>
                <asp:ImageButton ID="btnEliminar" runat="server" Width="16px" ImageUrl="../Content/img/Eliminar.png"
                    CommandArgument='<%# Eval("ProductoID") %>' OnClientClick="javascript:return confirm('¿Está seguro de eliminar el registro?')"
                    OnCommand="btnEliminar_Command" ToolTip="Eliminar" ImageAlign="Baseline" />
                </ItemTemplate>
                <ItemStyle Width="80px" />
            <HeaderStyle CssClass="gvCabecera" HorizontalAlign="Center" />
            </asp:TemplateField>
            </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle  HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

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
                     <table style="margin:auto;">
                         <tr style="visibility:hidden">
                             <td style="width:100px;">Id. Producto</td>
                             <td> <asp:TextBox ID="txtProductoID" CssClass="popupTxts" runat="server" OnKeyPress="SoloLectura()" style="background:#d9d9d9;"></asp:TextBox></td>
                         </tr>
                         <tr>
                             <td>Nombre</td>
                             <td><asp:TextBox ID="txtProducto" CssClass="popupTxts" runat="server" autocomplete="off"></asp:TextBox></td>
                         </tr>
                         <tr>
                             <td>Descripción</td>
                             <td><asp:TextBox ID="txtDescProducto" CssClass="popupTxts"  runat="server" autocomplete="off"></asp:TextBox></td>
                         </tr>
                     </table>

                     <br />
                     <div style="text-align:center;" id="buttonsPopUp">
                        <asp:Button runat="server" class="btn btn-primary btn-sm" ID="btnGuardar" Text="Actualizar" style="margin:auto;" OnClientClick="javascript:return ValidarCampos();" OnClick="btnGuardar_Click"/>
                        <asp:Button runat="server" class="btn btn-primary btn-sm" ID="btnCancelar" Text="Cancelar" style="margin:auto;"/>
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
