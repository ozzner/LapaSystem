<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vPlanes.aspx.cs" Inherits="LimsWeb.iAdministrador.vPlanes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Planes</title>
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />
    <link href="../Content/css/plans2checkout.css" rel="stylesheet" />
    <link href="../Content/css/main_styles_lapa.css" rel="stylesheet" />
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />


</head>
<body id="main_plans">

    <div class="tituloInfo">
        PLANES &nbsp;&nbsp;&nbsp;<a id="ver_detalles" target="_blank" href="https://www.lapa-tec.com/#Planes">Ir a la web</a>
        &nbsp; &nbsp;<span runat="server" id="message_span" class="MySuccess"><%= message %></span>
        &nbsp; &nbsp;<span runat="server" id="type_package" class="MySuccess">Plan actual: <%= paquete %></span>
        &nbsp; &nbsp;<span runat="server" id="type_plan" hidden="true" class="MyError"><%= plan %></span>
        &nbsp; &nbsp;<span runat="server" id="type_service" hidden="true" class="MyError"><%= servicio %></span>
  
    </div>

    <form id="form_plans" runat="server">
        <div>
            <ul class="nav nav-tabs">
                <li role="presentation" class="active"><a href="#mPlans">PLANES</a></li>
                <%--            <li role="presentation"><a href="#">Profile</a></li>
          <li role="presentation"><a href="#">Messages</a></li>----%>
            </ul>
        </div>


        <!-- Tab panes -->
        <div class="tab-content" id="tabContentID">
            <div role="tabpanel" class="tab-pane active" id="mPlans">

                <fieldset>
                    <div class="pricing_table_wdg">
                        <ul id="gratis_empresa">
                            <li>Gratis <br />
                                empresa</li>
                            <li class="_price">$0.00/mes</li>
                            <li>1 Supervisor</li>
                            <li>1 Analista</li>
                            <li>1 Laboratorio</li>
                            <li>5 Productos</li>
                            <li>5 Parámetros</li>
                            <li>1 Atributo</li>
                            <li>No exporta resportes</li>
                            <li>No Logo personalizado</li>
                            <li id="gratis_empresa_btn" hidden="true"><a href='https://sandbox.2checkout.com/checkout/purchase?sid=901281879&quantity=1&product_id=2'>Adquirir</a></li>
                        </ul>

                        <ul id="gratis_servicio">
                            <li>Gratis 
                                <br />
                                servicio</li>
                            <li class="_price">$0.00/mes</li>
                            <li>1 Supervisor</li>
                            <li>1 Analista</li>
                            <li>1 Laboratorio</li>
                            <li>3 Clientes</li>
                            <li>5 Productos</li>
                            <li>5 Parámetros</li>
                            <li>1 Atributo</li>
                            <li>No exporta resportes</li>
                            <li>No Logo personalizado</li>
                            <li id="gratis_servicio_btn" hidden="true"><a href='https://sandbox.2checkout.com/checkout/purchase?sid=901281879&quantity=1&product_id=2'>Adquirir</a></li>
                        </ul>

                        <ul id="basico_empresa">
                            <li>Basico 
                                <br />
                                empresa</li>
                            <li class="_price">$50.00/mes</li>
                            <li>1 Supervisor</li>
                            <li>Ilimitado</li>
                            <li>1 Laboratorio</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>SI exporta resportes</li>
                            <li>NO Logo personalizado</li>
                            <li id="basico_empresa_btn"><a href='https://sandbox.2checkout.com/checkout/purchase?sid=901281879&quantity=1&product_id=4'>Adquirir</a></li>
                        </ul>


                        <ul id="basico_servicio">
                            <li>Basico<br />
                                servicio</li>
                            <li class="_price">$70.00/mes</li>
                            <li>1 Supervisor</li>
                            <li>Ilimitado</li>
                            <li>1 Laboratorio</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>SI exporta resportes</li>
                            <li>NO Logo personalizado</li>
                            <li id="basico_servicio_btn"><a href='https://sandbox.2checkout.com/checkout/purchase?sid=901281879&quantity=1&product_id=3'>Adquirir</a></li>
                        </ul>

                        <ul id="corporativo_empresa">
                            <li>Corporativo<br />
                                empresa</li>
                            <li class="_price">$100.00/mes</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>SI exporta resportes</li>
                            <li>SI Logo personalizado</li>
                            <li id="corporativo_empresa_btn"><a href='https://sandbox.2checkout.com/checkout/purchase?sid=901281879&quantity=1&product_id=5'>Adquirir</a></li>
                        </ul>

                        <ul id="corporativo_servicio">
                            <li>Corporativo<br />
                                servicio</li>
                            <li class="_price">$140.00/mes</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>Ilimitado</li>
                            <li>SI exporta resportes</li>
                            <li>SI Logo personalizado</li>
                            <li id="corporativo_servicio_btn"><a href='https://sandbox.2checkout.com/checkout/purchase?sid=901281879&quantity=1&product_id=6'>Adquirir</a></li>
                        </ul>
                    </div>
                    <br style="clear: both;" />
                </fieldset>
            </div>
        </div>
    </form>
    <script src="../Content/js/jquery-1.8.2.js"></script>
    <script src="../Content/js/custom_2checkout.js"></script>
</body>
</html>
