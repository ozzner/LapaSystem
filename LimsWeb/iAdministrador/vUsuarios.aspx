<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vUsuarios.aspx.cs" Inherits="LimsWeb.iAdministrador.vUsuarios" %>

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
        .hideEvidence {
            display: none !important;
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

    <script>


        function revisarCheck(checkbox) {

            if (checkbox.checked) {

                $('#txtClave').attr('readonly', false);
                $("#txtClave").css({ "background-color": "white" });
                $("#txtClave").css({ "color": "black" });

                $('#txtClaveConf').attr('readonly', false);
                $("#txtClaveConf").css({ "background-color": "white" });
                $("#txtClaveConf").css({ "color": "black" });

                $('#txtClave').focus();


            } else {

                $('#txtClave').val('');
                $('#txtClaveConf').val('');

                $('#txtClave').attr('readonly', true);
                $("#txtClave").css({ "background-color": "#d9d9d9" });
                $("#txtClave").css({ "color": "gray" });

                $('#txtClaveConf').attr('readonly', true);
                $("#txtClaveConf").css({ "background-color": "#d9d9d9" });
                $("#txtClaveConf").css({ "color": "gray" });
            }
        }


        $(function () {
            $('#chkCambiarClave').prop('checked', false);
            $('#txtUsuarioID').val('');
            $('#txtNombre').val('');
            $('#txtCorreo').val('');
            $('#txtClave').val('');
            $('#txtClaveConf').val('');
            $('#txtClave').attr('readonly', true);
            $("#txtClave").css({ "background-color": "#d9d9d9" });
            $("#txtClave").css({ "color": "gray" });

            $('#txtClaveConf').attr('readonly', true);
            $("#txtClaveConf").css({ "background-color": "#d9d9d9" });
            $("#txtClaveConf").css({ "color": "gray" });

            $('#txtUsuarioID').attr('readonly', true);
            $("#txtUsuarioID").css({ "background-color": "#d9d9d9" });
            $("#txtUsuarioID").css({ "color": "gray" });

        });


        function EditarProducto(lnk) {
            $('#chkCambiarClave').prop('checked', false);
            $('#txtClave').val('');
            $('#txtClaveConf').val('');

            $('#txtCorreo').attr('readonly', true);
            $("#txtCorreo").css({ "background-color": "#d9d9d9" });
            $("#txtCorreo").css({ "color": "gray" });

            $('#txtClave').attr('readonly', true);
            $("#txtClave").css({ "background-color": "#d9d9d9" });
            $("#txtClave").css({ "color": "gray" });

            $('#txtClaveConf').attr('readonly', true);
            $("#txtClaveConf").css({ "background-color": "#d9d9d9" });
            $("#txtClaveConf").css({ "color": "gray" });

            var row = lnk.parentNode.parentNode;

            $('#txtUsuarioID').val(row.cells[0].innerHTML);
            $('#txtNombre').val(row.cells[1].innerHTML);

            if (row.cells[2].innerHTML == "Administrador") {
                $("#ddlPerfilUsuario").parent().parent().css({ "display": "none" });
                $("#ddlLaboratorio").parent().parent().css({ "display": "none" });
                $("#rbHabilitado").parent().parent().css({ "display": "none" });
                $("#ddlPerfil").val(0);
            } else {
                $("#ddlPerfilUsuario option:contains(" + row.cells[2].innerHTML + ")").attr('selected', 'selected');
                $("#ddlLaboratorio option:contains(" + row.cells[3].innerHTML + ")").attr('selected', 'selected');
                $("#ddlPerfil").val(1);
            }

            $('#txtCorreo').val(row.cells[4].innerHTML);
            $('#txtClave').val('');
            $('#txtClaveConf').val('');

            $('#lblTitulo').text("Actualizar Usuario");
            $('#btnGuardar').val("Actualizar");

            $('#PopUpParametro').modal('show');

            if (row.cells[5].innerHTML == "Habilitado") {
                alertaSi();
            } else {
                alertaNo();
            }

            if (row.cells[6].innerHTML == "Si") {
                restriccionSi();
            } else {
                restriccionNo();
            }
        }

        function NuevoParametro() {
            $('#chkCambiarClave').prop('checked', false);

            $('#txtCorreo').attr('readonly', false);
            $("#txtCorreo").css({ "background-color": "white" });
            $("#txtCorreo").css({ "color": "black" });

            $('#lblTitulo').text("Nuevo Usuario");
            $('#btnGuardar').val("Crear");

            $('#txtUsuarioID').val('');
            $('#txtNombre').val('');
            $('#txtCorreo').val('');
            $('#txtClave').val('');
            $('#txtClaveConf').val('');

            $('#lblTitulo').text("Nuevo Usuario");
            $('#btnGuardar').val("Crear");

            $('#PopUpParametro').modal('show');
        }

        function ValidarCampos() {
            
            /*if ($("#perfil").val() == 0) {
                $("#ddlPerfilUsuario").val(1);
                $("#ddlLaboratorio").val(1);
            }*/

            if ($('#txtNombre').val().length == 0) {
                alert('Ingrese nombre de usuario');
                $('#txtNombre').focus();
                return false;
            }

            if ($('#txtCorreo').val().length == 0) {
                alert('Ingrese correo electrónico');
                $('#txtCorreo').focus();
                return false;
            }

            var origen = $('#btnGuardar').val();
            if (origen == 'Crear') {
                if ($('#txtClave').val().length == 0) {
                    alert('Ingrese clave');
                    $('#txtClave').focus();
                    return false;
                }

                if ($('#txtClaveConf').val().length == 0) {
                    alert('Ingrese clave de confirmación');
                    $('#txtClave').focus();
                    return false;
                }

                if ($('#txtClave').val() == $('#txtClaveConf').val()) {
                    return true;
                } else {
                    //alert("Las claves no coinciden");
                    alert("<%= ((Dictionary<string,string>)Session["Etiquetas"])["MU01"] %>");
                    return false;
                }
            }
            else {
                if ($('#chkCambiarClave').is(':checked') == true) {

                    if ($('#txtClave').val().length == 0) {
                        alert('Ingrese clave');
                        $('#txtClave').focus();
                        return false;
                    }

                    if ($('#txtClaveConf').val().length == 0) {
                        alert('Ingrese clave de confirmación');
                        $('#txtClave').focus();
                        return false;
                    }

                    if ($('#txtClave').val() == $('#txtClaveConf').val()) {

                        return true;
                    } else {
                        alert("Las claves no coinciden");
                        return false;
                    }

                } else {
                    return true;
                }
            }
        }

        function isAdministrator(context) {


            var row = context.parentNode.parentNode;


            if (row.cells[2].innerHTML == "Administrador") {

                alert("Para eliminar el usuario administrador, contactarse con support@wasitec.com");
                return false;
            } else {
                //return confirm("¿Seguro que desea eliminar el usuario?");
                return confirm("<%= ((Dictionary<string,string>)Session["Etiquetas"])["MU04"] %>");
            }
        }

        function alertaSi() {
            $('#rbHabilitado').prop('checked', true);
            $('#rbDeshabilitado').prop('checked', false);

        }

        function alertaNo() {
            $('#rbDeshabilitado').prop('checked', true);
            $('#rbHabilitado').prop('checked', false);

        }

        function restriccionSi() {
            $('#rbIpSi').prop('checked', true);
            $('#rbIpNo').prop('checked', false);

        }

        function restriccionNo() {
            $('#rbIpSi').prop('checked', false);
            $('#rbIpNo').prop('checked', true);

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
                          CssClass="btn btn-primary btn-sm" OnClientClick="NuevoParametro();  return false;"/>

            <% if (Session["PerfilUsuarioID"].ToString() == "1"){ %>
            <asp:Button runat="server" ID="btnActualizaIP" Text="Actualizar IP" 
                          CssClass="btn btn-primary btn-sm" OnClick="btnActualizaIP_Click" />
            <% } %>

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
      
   
    <div class="grilla"   style="height:430px; overflow-y:auto;">
            <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="gvCabecera" Width="100%"  CssClass="gvGeneral" RowStyle-CssClass ="gvFilas" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
            
            <asp:BoundField DataField="UsuarioID"  HeaderStyle-CssClass="hideEvidence"
                    SortExpression="UsuarioID" Visible="true">
<HeaderStyle CssClass="hideEvidence"></HeaderStyle>

                       <ItemStyle Width="0px" CssClass="hideEvidence" />
            </asp:BoundField>
            
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="Nombre">
<HeaderStyle CssClass="gvCabecera"></HeaderStyle>

                <ItemStyle Width="200px" />
            </asp:BoundField>

            <asp:BoundField HeaderText="Tipo" DataField="PerfilUsuario" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="PerfilUsuario"> 
<HeaderStyle CssClass="gvCabecera"></HeaderStyle>

                <ItemStyle Width="120px" />
            </asp:BoundField>

             <asp:BoundField HeaderText="Laboratorio" DataField="Laboratorio" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="Laboratorio"> 
<HeaderStyle CssClass="gvCabecera"></HeaderStyle>

                <ItemStyle Width="130px" />
            </asp:BoundField>

            <asp:BoundField HeaderText="Correo" DataField="Correo" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="Correo"> 
<HeaderStyle CssClass="gvCabecera"></HeaderStyle>
            </asp:BoundField>


            <asp:BoundField HeaderText="Estado" DataField="NomEstado" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="NomEstado"> 
<HeaderStyle CssClass="gvCabecera"></HeaderStyle>
            </asp:BoundField>

                <asp:BoundField HeaderText="Restringido" DataField="NomRestriccion" HeaderStyle-CssClass="gvCabecera"
                    SortExpression="NomRestriccion"> 
<HeaderStyle CssClass="gvCabecera"></HeaderStyle>
            </asp:BoundField>
        


             <asp:TemplateField HeaderText="Editar" >
                <ItemTemplate>
                <asp:ImageButton ID="btnEditar" 
                    runat="server" 
                    Width="16px" 
                    ImageUrl="../Content/img/edit.png" 
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
                    CommandArgument='<%# Eval("UsuarioID") %>' 
                    OnClientClick="javascript:return isAdministrator(this);"
                    OnCommand="btnEliminar_Command"
                    ToolTip="Eliminar" 
                    ImageAlign="Baseline" />
                </ItemTemplate>
                <ItemStyle Width="60px" />
                <HeaderStyle CssClass="gvCabecera" HorizontalAlign="Center" />
            </asp:TemplateField>



            </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle Height="30px" HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />

<RowStyle CssClass="gvFilas" BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
        <!--OnCommand="btnEliminar_Command" -->
    </div>

  </div>
</div>
        
     </div>


                     
            <!-- Modal  -->
   <div class="modal fade" id="PopUpParametro" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="false">  
       <div class="modal-dialog"  >    
            <div class="modal-content"  style="width:400px;height:430px; margin-left:105px; margin-top:100px;">
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
                             <td style="width:100px;">Id. Usuario</td>
                             <td> <asp:TextBox ID="txtUsuarioID" autocomplete="off" CssClass="popupTxts" runat="server"  style="background:#d9d9d9;"></asp:TextBox></td>
                         </tr>
                         <tr>
                             <td>Nombre</td>
                             <td><asp:TextBox ID="txtNombre"  autocomplete="off" CssClass="popupTxts" runat="server"></asp:TextBox></td>
                         </tr>
                         <tr>
                             <td>Tipo</td>
                             <td><asp:DropDownList ID="ddlPerfilUsuario" CssClass="popupTxts"  runat="server">
                                 </asp:DropDownList>
                                 <asp:HiddenField ID="ddlPerfil" runat="server" />
                             </td>
                         </tr>
                         <tr>
                             <td>Laboratorio</td>
                             <td><asp:DropDownList ID="ddlLaboratorio"  CssClass="popupTxts"  runat="server">
                                 </asp:DropDownList>
                             </td>
                         </tr>                    
                         <tr >
                             <td>Correo</td>
                             <td><asp:TextBox ID="txtCorreo" CssClass="popupTxts" autocomplete="off"   runat="server"></asp:TextBox></td>
                         </tr>
                         
                         <tr>
                             <td>Estado</td>
                             <td>
                                
                                <asp:RadioButton runat="server" Checked GroupName="estadoUsuario" Text="Habilitar" ID="rbHabilitado"/>
                                <asp:RadioButton runat="server" GroupName="estadoUsuario"  Text="Deshabilitar" ID="rbDeshabilitado"/>
                             
                             </td>
                         </tr>

                         <tr>
                             <td>Restriccion IP?</td>
                             <td>
                                <asp:RadioButton runat="server" GroupName="restriccionIpUsuario" Text="Si" ID="rbIpSi"/>
                                <asp:RadioButton runat="server" Checked="true"  GroupName="restriccionIpUsuario"  Text="No" ID="rbIpNo"/>
                             </td>
                         </tr>

                           </table>
                     
                     <div style="margin:auto; background:#eee; border-radius:5px; padding-top:5px;padding-bottom:10px;margin-top:4px;">
                           <table style="margin:auto;"  >

                               <tr >
                                 <td><asp:CheckBox runat="server" ID="chkCambiarClave" autocomplete="off"  onclick="revisarCheck(this)" /> Crear/Cambiar Clave</td>
                                 <td></td>
                             </tr>

                             <tr >
                                 <td>Clave</td>
                                 <td><asp:TextBox ID="txtClave" CssClass="popupTxts" autocomplete="off" TextMode="Password" runat="server"></asp:TextBox></td>
                             </tr>
                             <tr >
                                 <td>Confirmar Clave</td>
                                 <td><asp:TextBox ID="txtClaveConf" CssClass="popupTxts" autocomplete="off" TextMode="Password"  runat="server"></asp:TextBox>                                     
                                 </td>
                             </tr>
                         
                         </table>
                    </div>    

                     <br />
                     <div style="text-align:center;">
                        <asp:Button runat="server" class="btn btn-primary btn-sm" ID="btnGuardar" Text="Actualizar" style="margin:auto;" OnClientClick="javascript:return ValidarCampos();" OnClick="btnGuardar_Click"/>
                        <asp:Button runat="server" class="btn btn-primary btn-sm" ID="btnCancelar" Text="Cancelar" style="margin:auto;"/>
                     
                     </div>                          
                 </div>      
                       <%-- <div class="modal-footer">        
                     <asp:Button   runat="server" ID="btnVolver" class="btn btn-default" OnClick="btnVolver_Click" Text="Volver"   />
                 </div> --%>
             </div>  
         </div>
    </div> <!-- FIN Modal -->
        
    </form>
</body>
</html>