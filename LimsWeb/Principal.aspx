<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="LimsWeb.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<link rel="stylesheet" type="text/css" href="css/default.css" />
        <link rel="stylesheet" type="text/css" href="css/component.css" />
        <script src="js/modernizr.custom.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>L.A.P.A. REGISTRO</title>
    <script src="Content/js/jquery-1.8.2.js"></script>
    <script src="Content/js/jquery-1.8.2.min.js"></script>
    <link href="Content/css/EstilosRegistro.css" rel="stylesheet" />
    <link href="Content/css/main_fonts.css" rel="stylesheet" />
    <script type="text/javascript">


        function revisarCheck(checkbox) {
            var dominio = document.getElementById("txtDominio");
            var domCorreo = document.getElementById("txtDominioCorreo");
            if (checkbox.checked) {

                $('#txtCorreo').val('');
                $('#txtDominio').val('');
                $('#txtDominioCorreo').val('');

                $('#txtDominioCorreo').attr('readonly', true);
                $("#txtDominioCorreo").css({ "background-color": "#d9d9d9" });
                $("#txtDominioCorreo").css({ "color": "gray" });

                $('#txtDominio').attr('readonly', false);
                $("#txtDominio").css({ "background-color": "white" });
                $("#txtDominio").css({ "color": "black" });
                //dominio.disabled = false; 
                //domCorreo.disabled = true;

            } else {

                //dominio.disabled = true;
                //domCorreo.disabled = false;
                $('#txtDominio').val('');
                $('#txtCorreo').val('');
                $('#txtDominioCorreo').val('');
                $('#txtDominioCorreo').attr('readonly', false);
                $("#txtDominioCorreo").css({ "background-color": "white" });
                $("#txtDominioCorreo").css({ "color": "black" });

                $('#txtDominio').attr('readonly', true);
                $("#txtDominio").css({ "background-color": "#d9d9d9" });
                $("#txtDominio").css({ "color": "gray" });
            }
        }

        $(function () {
            $('#txtDominio').val('');
            $('#txtCorreo').val('');
            $('#txtDominioCorreo').val('');
            $('#txtDominioCorreo').attr('readonly', false);
            $("#txtDominioCorreo").css({ "background-color": "white" });
            $("#txtDominioCorreo").css({ "color": "black" });

            $('#txtDominio').attr('readonly', true);
            $("#txtDominio").css({ "background-color": "#d9d9d9" });
            $("#txtDominio").css({ "color": "gray" });
            //var dominio = document.getElementById("txtDominio");
            //dominio.disabled = true;
            //var domCorreo = document.getElementById("txtDominioCorreo");
            //domCorreo.disabled = false;

        });



    </script>




</head>
<body>

    <div class="container-fluid" style="height:32px;width:32px">
              
            <div class="main">
                <ul id="cbp-bislideshow" class="cbp-bislideshow">
                    <li><img class='img-responsive' src="images/Lapa.jpg" alt=""/></li>
                    <li><img class='img-responsive' src="images/Lapa1.jpg" alt=""/></li>
                    <li><img class='img-responsive' src="images/Lapa2.jpg" alt=""/></li>
                    <li><img  class='img-responsive' src="images/Lapa4.jpg" alt=""/></li>
                   
                </ul>
                <!-- <div id="cbp-bicontrols" class="cbp-bicontrols">
                    <span class="cbp-biprev"></span>
                    <span class="cbp-bipause"></span>
                    <span class="cbp-binext"></span>
                </div> -->
            </div>
        </div>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
      
        <script src="js/jquery.imagesloaded.min.js"></script>
        <script src="js/cbpBGSlideshow.min.js"></script>
        <script>
            $(function () {
                cbpBGSlideshow.init();
            });
        </script>
    <form id="form1" runat="server">
     
        <div class="registro color" style="float:right; margin-right:15px; width="450px!important;"  ">  <br />       
            <h1> <%= register %> </h1>
            <div class="linea"></div>
               <br />
            <%= rz %>
            <br />
            <asp:TextBox runat="server" ID="txtRazonSocial" autocomplete="off" CssClass="txts"></asp:TextBox>
             <br />
            <br />
            <asp:checkbox runat="server" ID="chkDominio" onclick="revisarCheck(this)"  />
            <br />
            <asp:TextBox runat="server" ID="txtDominio"  autocomplete="off" CssClass="txts" ></asp:TextBox>
             <br />
            <br />
            <%= email %>
            <br />
            <table id="tabla">
                <tr >
                    <td> <asp:TextBox runat="server" ID="txtCorreo" autocomplete="off"  CssClass="txts"></asp:TextBox></td>
                    <td style="width:40px;text-align:right;"> @</td>
                    <td> <asp:TextBox runat="server" ID="txtDominioCorreo" autocomplete="off"  CssClass="txts"></asp:TextBox></td>
                </tr>
            </table>
           
           
           
             <br />

            <asp:Button runat="server" ID="btnRegistrar" Text="REGISTRAR" CssClass="btns" OnClick="btnRegistrar_Click"  OnClientClick="javascript:return confirm('¿Esta seguro de que la información proporcionada es la correcta?');"  />
            <div id="informacion" style="background:none;margin-top:10px;text-align:justify; width:90%;margin:10px auto;font-size:small">
                
            <%= aviso %>
            
                        
        </div>

    </form>
    <script>
        $("#txtDominio").keyup(function () {

            var valor = $("#txtDominio").val();
            $("#txtDominioCorreo").val(valor);
            //alert(valor);
        });


    </script>
</body>
</html>


