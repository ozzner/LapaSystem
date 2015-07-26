<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vSubirLogo.aspx.cs" Inherits="LimsWeb.iAdministrador.vSubirLogo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script src="../Content/js/jquery-1.8.2.js"></script>
    <script src="../Content/js/bootstrap.min.js"></script>
    <link href="../Content/css/EstilosPopup.css" rel="stylesheet" />
    <script src="../Content/js/validaciones.js"></script>
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />

<style>
    * {
        font-size:13px;
        background:#EEEEEE;
    }
    
    body {
        background:#EEEEEE !important;
    }    
</style>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Logo Empresa</title>
</head>
<body>
    <div align="center">
        <div class="panel panel-primary" align="center" style="width:80%; margin-top: 10px;">
            <div class="panel-heading">
                Actualizar Logo
            </div>
            <div class="panel-body">
                <form id="form1" runat="server" method="post" enctype="multipart/form-data">
                    <input type="file" id="logo" name="logo" runat="server" /><br />
                    <asp:Button runat="server" Text="Subir" CssClass="btn btn-primary" ID="btnSubir" OnClick="Subir_Click" />
                </form><br />
                <img id="previewimg" src="#" alt="Vista Previa" style="display: none; width:100%;" />
            </div>
        </div>
    </div>
<script type="text/javascript">
    $(function () { $("#logo").change(function () { readURL(this); }); });
    function readURL(input) {
        var files = input.files ? input.files : input.currentTarget.files;
        if (files && files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#previewimg').attr('src', e.target.result).css({"display":"block"});
            }

            reader.readAsDataURL(input.files[0]);
        }
    }
</script></body>
</html>
