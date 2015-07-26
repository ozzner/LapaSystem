<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vAtributo.aspx.cs" Inherits="LimsWeb.Atributo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Content/js/jquery-1.8.2.js"></script>
    <script src="../Content/js/bootstrap.min.js"></script>
    <link href="../Content/css/EstilosPopup.css" rel="stylesheet" />
    <script src="../Content/js/validaciones.js"></script>
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
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

            $('#txtAtributoID').val(row.cells[0].innerHTML);
            $('#txtNomAtributo').val(row.cells[1].innerHTML);
            $('#txtUsuarioID').val(row.cells[2].innerHTML);

            $('#lblTitulo').text("Actualizar Atributo");
            $('#btnGuardar').val("Actualizar");

            $('#PopUpProducto').modal('show');
        }



        function NuevoProducto() {
            $('#lblTitulo').text("Nuevo Atributo");
            $('#btnGuardar').val("Crear");

            $('#txtAtributoID').val('');
            $('#txtNomAtributo').val('');
            $('#txtUsuarioID').val('');

            $('#PopUpProducto').modal('show');
        }

        function ValidarCampos() {

            if ($('#txtNomAtributo').val().length == 0) {
                alert('Ingresa nombre de atributo');
                $('#txtNomAtributo').focus();
                return false;
            }

            if ($('#txtUsuarioID').val().length == 0) {
                alert('Ingresa el usuario');
                $('#txtUsuarioID').focus();
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

    <form id="form2" runat="server">
    <div>
        <div class="grupoBotones">
            
                          <asp:Button runat="server" ID="btnIrPopup" Text="Nuevo" 
                          CssClass="btn btn-primary btn-sm" OnClientClick="NuevoProducto();  return false;"/>

<%--            <a runat="server" class="btn btn-primary btn-sm" id="btnNuevo">Nuevo</a>
            <asp:Button runat="server" class="btn btn-primary btn-sm" ID="btnGuardar" Text="Guardar"/>
            <asp:Button runat="server" class="btn btn-primary btn-sm" ID="btnCancelar" Text="Cancelar"/>--%>
        </div>
        
            <br />


<div class="tabbable tab"> 
  <ul class="nav nav-tabs">
    <li class="active"><a href="#tab1" data-toggle="tab">Listado</a></li>
   </ul>
  <div class="tab-content" style="border:1px solid #d9d9d9; border-bottom-left-radius:5px;border-bottom-right-radius:5px; padding:15px;">
    <div class="tab-pane active" id="tab1">
      
    
           <%--OnCommand="btnEditar_Command" --%>
         <div class="grilla">
         <asp:GridView ID="gvAtributo" Width="100%" runat="server"  GridLines="None" AutoGenerateColumns="false">
             <RowStyle CssClass="gvFilas" />
             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="AtributoID"  HeaderStyle-CssClass="hideEvidence"
                    SortExpression="AtributoID" Visible="true">
                    <HeaderStyle CssClass="hideEvidence"></HeaderStyle>
                    <ItemStyle Width="50px"  CssClass="hideEvidence" />
                </asp:BoundField>
               
                <asp:BoundField HeaderText="Nombre" DataField="NomAtributo"  HeaderStyle-CssClass="gvCabecera"
                    SortExpression="NomAtributo" Visible="true">
                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                    
                </asp:BoundField>
         
            <asp:TemplateField HeaderText="Editar" >
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEditar" 
                            runat="server" 
                            Width="16px" 
                            ImageUrl="../Content/img/edit.png" 
                            CommandArgument='<%# Eval("AtributoID") + "{" + Eval("NomAtributo") + "{" + Eval("UsuarioID") %>'
                            ToolTip="Editar" 
                            ImageAlign="Baseline" 
                            autopostback="true"
                            EnableTheming="false" 
                            OnClientClick="EditarProducto(this);return false;" />
                    </ItemTemplate>
                <ItemStyle Width="60px" />
                <HeaderStyle CssClass="gvCabecera" HorizontalAlign="Center" />
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Eliminar">
            <ItemTemplate>
                <asp:ImageButton ID="btnEliminar" 
                    runat="server" 
                    Width="16px" 
                    ImageUrl="../Content/img/Eliminar.png"
                    CommandArgument='<%# Eval("AtributoID") %>' 
                    OnClientClick="javascript:return confirm('¿Está seguro de eliminar el registro?');"
                    OnCommand="btnEliminar_Command"
                    ToolTip="Eliminar" 
                    ImageAlign="Baseline" />
                </ItemTemplate>
                <ItemStyle Width="60px" />
            <HeaderStyle CssClass="gvCabecera" HorizontalAlign="Center" />
            </asp:TemplateField>



            </Columns>
        </asp:GridView>
             <!--OnCommand="btnEliminar_Command"-->
        </div><!-- grilla-->
    

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
                             <td style="width:100px;" >Id. Atributo</td>
                             <td> <asp:TextBox ID="txtAtributoID" CssClass="popupTxts" runat="server" OnKeyPress="SoloLectura()" style="background:#d9d9d9;"></asp:TextBox></td>
                         </tr>
                         <tr>
                             <td>Nombre</td>
                             <td><asp:TextBox ID="txtNomAtributo" CssClass="popupTxts" runat="server" autocomplete="off"></asp:TextBox></td>
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
