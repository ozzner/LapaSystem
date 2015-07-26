<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vLaboratorios.aspx.cs" Inherits="LimsWeb.iAdministrador.vLaboratorio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Laboratorios</title>
    <script src="../Content/js/jquery-1.8.2.js"></script>
    <script src="../Content/js/bootstrap.min.js"></script>
    <link href="../Content/css/EstilosPopup.css" rel="stylesheet" />
    <script src="../Content/js/validaciones.js"></script>
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />


    <style>
        * {
            font-family: Calibri;
        }

        .tituloInfo {
            border-bottom: 1px solid gray;
            padding: 10px 0px;
            text-align: left;
            padding-left: 20px;
            font-weight: bold;
            opacity: 0.7;
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
        .hideEvidence {
            display: none !important;
        }
    </style>

    <link href="../Content/css/main_fonts.css" rel="stylesheet" />

    <script>
        $(document).ready(function () {
            window.opener.location.reload();
        });

    </script>


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

            $("#ddlPerfilUsuario option:contains(" + row.cells[2].innerHTML + ")").attr('selected', 'selected');
            $("#ddlLaboratorio option:contains(" + row.cells[3].innerHTML + ")").attr('selected', 'selected');

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

        function alertaSi() {
            $('#rbHabilitado').prop('checked', true);
            $('#rbDeshabilitado').prop('checked', false);

        }

        function alertaNo() {
            $('#rbDeshabilitado').prop('checked', true);
            $('#rbHabilitado').prop('checked', false);

        }



    </script>

</head>

<body style="background: #eee">
    <script>
    </script>

    <form id="form1" runat="server">

        <script>

            function EditarProducto(lnk) {
                var row = lnk.parentNode.parentNode;
                $('#txtProductoID').val(row.cells[0].innerHTML);
                $('#txtProducto').val(row.cells[1].innerHTML);
                $('#txtDescProducto').val(row.cells[2].innerHTML);

                $('#lblTitulo').text("Actualizar Datos");
                $('#btnGuardar').val("Actualizar");

                $('#PopUpProducto').modal('show');
            }

            function NuevoProducto() {
                $('#lblTitulo').text("Nuevo Laboratorio");
                $('#btnGuardar').val("Crear");

                $('#txtProductoID').val('');
                $('#txtProducto').val('');
                $('#txtDescProducto').val('');
                $('#PopUpProducto').modal('show');
            }

        </script>
        <div class="tituloInfo">
            LABORATORIO
        </div>

        <div class="grupoBotones">            
            <asp:Button runat="server" ID="btnIrPopup" Text="Nuevo" 
              CssClass="btn btn-primary btn-sm" OnClientClick="NuevoProducto();  return false;"/>
        </div>
        <br />

        <div class="tabbable tab">
            <ul class="nav nav-tabs">
                <li class="active"><a href="#tab1" data-toggle="tab">Listado</a></li>
            </ul>
            <div class="tab-content" style="border: 1px solid #d9d9d9; border-bottom-left-radius: 5px; border-bottom-right-radius: 5px; padding: 15px;">
                <div class="tab-pane active" id="tab1">


                    <div class="grilla" style="height: 330px; overflow-y: auto;">
                        <asp:GridView ID="gvLaboratorio" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="gvCabecera" Width="100%" CssClass="gvGeneral" RowStyle-CssClass="gvFilas" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="LaboratorioID" HeaderStyle-CssClass="hideEvidence"
                                    SortExpression="LaboratorioID" Visible="true">
                                    <HeaderStyle CssClass="hideEvidence"></HeaderStyle>
                                    <ItemStyle Width="50px" CssClass="hideEvidence"  />
                                </asp:BoundField>

                                <asp:BoundField HeaderText="Laboratorio" DataField="NomLaboratorio" HeaderStyle-CssClass="gvCabecera"
                                    SortExpression="NomLaboratorio">
                                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                                    <ItemStyle Width="200px" />
                                </asp:BoundField>

                                <asp:BoundField HeaderText="Ubicacion" DataField="Ubicacion" HeaderStyle-CssClass="gvCabecera"
                                    SortExpression="Ubicacion">
                                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField HeaderText="Registro" DataField="FechaRegistro" HeaderStyle-CssClass="gvCabecera"
                                    SortExpression="FechaRegistro">
                                    <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEditar" runat="server" Width="16px" ImageUrl="../Content/img/edit.png"
                                            ToolTip="Editar" ImageAlign="Baseline" autopostback="true"
                                            EnableTheming="false" OnClientClick="EditarProducto(this);return false;" />

                                    </ItemTemplate>
                                    <ItemStyle Width="60px" />
                                    <HeaderStyle CssClass="gvCabecera" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEliminar" runat="server" Width="16px" ImageUrl="../Content/img/Eliminar.png"
                                            CommandArgument='<%# Eval("LaboratorioID") %>' OnClientClick="javascript:return confirm('¿Confirma Eliminacion del registro?');"
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
        </div>



        <!-- Modal  -->
        <div class="modal fade" id="PopUpProducto" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="false">
            <div class="modal-dialog">
                <div class="modal-content" style="width: 400px; height: 280px; margin-left: 105px; margin-top: 100px;">
                    <div class="modal-header" style="background: #428bca; color: white; font-weight: bolder;">
                        <button type="button" class="close" data-dismiss="modal" style="color: white;" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="myModalLabel">
                            <asp:Label runat="server" ID="lblTitulo" Text=""></asp:Label>
                        </h4>
                    </div>

                    <div class="modal-body" style="color: black;">

                        <table style="margin: auto;">
                            <tr style="visibility:hidden">
                                <td style="width: 100px;">Id. </td>
                                <td>
                                    <asp:TextBox ID="txtProductoID" CssClass="popupTxts" runat="server" OnKeyPress="SoloLectura()" Style="background: #d9d9d9;"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Nombre</td>
                                <td>
                                    <asp:TextBox ID="txtProducto" CssClass="popupTxts" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Ubicacion</td>
                                <td>
                                    <asp:TextBox ID="txtDescProducto" CssClass="popupTxts" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>

                        <br />
                        <div style="text-align: center;">
                            <asp:Button runat="server" class="btn btn-primary btn-sm" ID="btnGuardar" Text="Actualizar" Style="margin: auto;" OnClientClick="javascript:return ValidarCampos();" OnClick="btnCrear_Click" />
                            <asp:Button runat="server" class="btn btn-primary btn-sm" ID="btnCancelar" Text="Cancelar" Style="margin: auto;" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- FIN Modal -->
        
    </form>
</body>
</html>
