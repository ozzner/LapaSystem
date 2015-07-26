﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="LimsWeb.iRegistro.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Content/js/jquery-1.8.2.js"></script>
    <script src="../Content/js/jquery-1.8.2.min.js"></script>
    <link href="../Content/css/EstilosRegistro.css" rel="stylesheet" />
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

        <div class="ContenedorRegistro color">


            <h1>COMPLETANDO REGISTRO</h1>
            <div style="width: 830px; height: 1px; background: #3399ff;"></div>

            <br />

            <fieldset class="fielset" style="float: left;">
                <legend class="color">EMPRESA</legend>
                <div class="etqs color">RUC/NIT</div>
                <asp:TextBox runat="server" ID="txtRuc" class="txts tamanoNormal" placeholder="Ingrese RUC" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRuc" ControlToValidate="txtRuc" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <div class="etqs color">Razón Social</div>
                <asp:TextBox runat="server" ID="txtRazonSocial" ReadOnly class="txts tamanoNormal soloLectura"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRazonSocial" ControlToValidate="txtRazonSocial" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <div class="etqs color">Pais</div>
                <asp:DropDownList runat="server" ID="ddlPais" AutoPostBack="True" class="txts tamanoNormal">
                    <asp:ListItem Value="AF">Afghanistan</asp:ListItem>
                    <asp:ListItem Value="AX">Åland Islands</asp:ListItem>
                    <asp:ListItem Value="AL">Albania</asp:ListItem>
                    <asp:ListItem Value="DZ">Algeria</asp:ListItem>
                    <asp:ListItem Value="AS">American Samoa</asp:ListItem>
                    <asp:ListItem Value="AD">Andorra</asp:ListItem>
                    <asp:ListItem Value="AO">Angola</asp:ListItem>
                    <asp:ListItem Value="AI">Anguilla</asp:ListItem>
                    <asp:ListItem Value="AQ">Antarctica</asp:ListItem>
                    <asp:ListItem Value="AG">Antigua and Barbuda</asp:ListItem>
                    <asp:ListItem Value="AR">Argentina</asp:ListItem>
                    <asp:ListItem Value="AM">Armenia</asp:ListItem>
                    <asp:ListItem Value="AW">Aruba</asp:ListItem>
                    <asp:ListItem Value="AU">Australia</asp:ListItem>
                    <asp:ListItem Value="AT">Austria</asp:ListItem>
                    <asp:ListItem Value="AZ">Azerbaijan</asp:ListItem>
                    <asp:ListItem Value="BS">Bahamas</asp:ListItem>
                    <asp:ListItem Value="BH">Bahrain</asp:ListItem>
                    <asp:ListItem Value="BD">Bangladesh</asp:ListItem>
                    <asp:ListItem Value="BB">Barbados</asp:ListItem>
                    <asp:ListItem Value="BY">Belarus</asp:ListItem>
                    <asp:ListItem Value="BE">Belgium</asp:ListItem>
                    <asp:ListItem Value="BZ">Belize</asp:ListItem>
                    <asp:ListItem Value="BJ">Benin</asp:ListItem>
                    <asp:ListItem Value="BM">Bermuda</asp:ListItem>
                    <asp:ListItem Value="BT">Bhutan</asp:ListItem>
                    <asp:ListItem Value="BO">Bolivia</asp:ListItem>
                    <asp:ListItem Value="BA">Bosnia and Herzegovina</asp:ListItem>
                    <asp:ListItem Value="BW">Botswana</asp:ListItem>
                    <asp:ListItem Value="BV">Bouvet Island</asp:ListItem>
                    <asp:ListItem Value="BR">Brazil</asp:ListItem>
                    <asp:ListItem Value="IO">British Indian Ocean Territory</asp:ListItem>
                    <asp:ListItem Value="BN">Brunei Darussalam</asp:ListItem>
                    <asp:ListItem Value="BG">Bulgaria</asp:ListItem>
                    <asp:ListItem Value="BF">Burkina Faso</asp:ListItem>
                    <asp:ListItem Value="BI">Burundi</asp:ListItem>
                    <asp:ListItem Value="KH">Cambodia</asp:ListItem>
                    <asp:ListItem Value="CM">Cameroon</asp:ListItem>
                    <asp:ListItem Value="CA">Canada</asp:ListItem>
                    <asp:ListItem Value="CV">Cape Verde</asp:ListItem>
                    <asp:ListItem Value="KY">Cayman Islands</asp:ListItem>
                    <asp:ListItem Value="CF">Central African Republic</asp:ListItem>
                    <asp:ListItem Value="TD">Chad</asp:ListItem>
                    <asp:ListItem Value="CL">Chile</asp:ListItem>
                    <asp:ListItem Value="CN">China</asp:ListItem>
                    <asp:ListItem Value="CX">Christmas Island</asp:ListItem>
                    <asp:ListItem Value="CC">Cocos (Keeling) Islands</asp:ListItem>
                    <asp:ListItem Value="CO">Colombia</asp:ListItem>
                    <asp:ListItem Value="KM">Comoros</asp:ListItem>
                    <asp:ListItem Value="CG">Congo</asp:ListItem>
                    <asp:ListItem Value="CD">Congo, The Democratic Republic of The</asp:ListItem>
                    <asp:ListItem Value="CK">Cook Islands</asp:ListItem>
                    <asp:ListItem Value="CR">Costa Rica</asp:ListItem>
                    <asp:ListItem Value="CI">Cote D'ivoire</asp:ListItem>
                    <asp:ListItem Value="HR">Croatia</asp:ListItem>
                    <asp:ListItem Value="CU">Cuba</asp:ListItem>
                    <asp:ListItem Value="CY">Cyprus</asp:ListItem>
                    <asp:ListItem Value="CZ">Czech Republic</asp:ListItem>
                    <asp:ListItem Value="DK">Denmark</asp:ListItem>
                    <asp:ListItem Value="DJ">Djibouti</asp:ListItem>
                    <asp:ListItem Value="DM">Dominica</asp:ListItem>
                    <asp:ListItem Value="DO">Dominican Republic</asp:ListItem>
                    <asp:ListItem Value="EC">Ecuador</asp:ListItem>
                    <asp:ListItem Value="EG">Egypt</asp:ListItem>
                    <asp:ListItem Value="SV">El Salvador</asp:ListItem>
                    <asp:ListItem Value="GQ">Equatorial Guinea</asp:ListItem>
                    <asp:ListItem Value="ER">Eritrea</asp:ListItem>
                    <asp:ListItem Value="EE">Estonia</asp:ListItem>
                    <asp:ListItem Value="ET">Ethiopia</asp:ListItem>
                    <asp:ListItem Value="FK">Falkland Islands (Malvinas)</asp:ListItem>
                    <asp:ListItem Value="FO">Faroe Islands</asp:ListItem>
                    <asp:ListItem Value="FJ">Fiji</asp:ListItem>
                    <asp:ListItem Value="FI">Finland</asp:ListItem>
                    <asp:ListItem Value="FR">France</asp:ListItem>
                    <asp:ListItem Value="GF">French Guiana</asp:ListItem>
                    <asp:ListItem Value="PF">French Polynesia</asp:ListItem>
                    <asp:ListItem Value="TF">French Southern Territories</asp:ListItem>
                    <asp:ListItem Value="GA">Gabon</asp:ListItem>
                    <asp:ListItem Value="GM">Gambia</asp:ListItem>
                    <asp:ListItem Value="GE">Georgia</asp:ListItem>
                    <asp:ListItem Value="DE">Germany</asp:ListItem>
                    <asp:ListItem Value="GH">Ghana</asp:ListItem>
                    <asp:ListItem Value="GI">Gibraltar</asp:ListItem>
                    <asp:ListItem Value="GR">Greece</asp:ListItem>
                    <asp:ListItem Value="GL">Greenland</asp:ListItem>
                    <asp:ListItem Value="GD">Grenada</asp:ListItem>
                    <asp:ListItem Value="GP">Guadeloupe</asp:ListItem>
                    <asp:ListItem Value="GU">Guam</asp:ListItem>
                    <asp:ListItem Value="GT">Guatemala</asp:ListItem>
                    <asp:ListItem Value="GG">Guernsey</asp:ListItem>
                    <asp:ListItem Value="GN">Guinea</asp:ListItem>
                    <asp:ListItem Value="GW">Guinea-bissau</asp:ListItem>
                    <asp:ListItem Value="GY">Guyana</asp:ListItem>
                    <asp:ListItem Value="HT">Haiti</asp:ListItem>
                    <asp:ListItem Value="HM">Heard Island and Mcdonald Islands</asp:ListItem>
                    <asp:ListItem Value="VA">Holy See (Vatican City State)</asp:ListItem>
                    <asp:ListItem Value="HN">Honduras</asp:ListItem>
                    <asp:ListItem Value="HK">Hong Kong</asp:ListItem>
                    <asp:ListItem Value="HU">Hungary</asp:ListItem>
                    <asp:ListItem Value="IS">Iceland</asp:ListItem>
                    <asp:ListItem Value="IN">India</asp:ListItem>
                    <asp:ListItem Value="ID">Indonesia</asp:ListItem>
                    <asp:ListItem Value="IR">Iran, Islamic Republic of</asp:ListItem>
                    <asp:ListItem Value="IQ">Iraq</asp:ListItem>
                    <asp:ListItem Value="IE">Ireland</asp:ListItem>
                    <asp:ListItem Value="IM">Isle of Man</asp:ListItem>
                    <asp:ListItem Value="IL">Israel</asp:ListItem>
                    <asp:ListItem Value="IT">Italy</asp:ListItem>
                    <asp:ListItem Value="JM">Jamaica</asp:ListItem>
                    <asp:ListItem Value="JP">Japan</asp:ListItem>
                    <asp:ListItem Value="JE">Jersey</asp:ListItem>
                    <asp:ListItem Value="JO">Jordan</asp:ListItem>
                    <asp:ListItem Value="KZ">Kazakhstan</asp:ListItem>
                    <asp:ListItem Value="KE">Kenya</asp:ListItem>
                    <asp:ListItem Value="KI">Kiribati</asp:ListItem>
                    <asp:ListItem Value="KP">Korea, Democratic People's Republic of</asp:ListItem>
                    <asp:ListItem Value="KR">Korea, Republic of</asp:ListItem>
                    <asp:ListItem Value="KW">Kuwait</asp:ListItem>
                    <asp:ListItem Value="KG">Kyrgyzstan</asp:ListItem>
                    <asp:ListItem Value="LA">Lao People's Democratic Republic</asp:ListItem>
                    <asp:ListItem Value="LV">Latvia</asp:ListItem>
                    <asp:ListItem Value="LB">Lebanon</asp:ListItem>
                    <asp:ListItem Value="LS">Lesotho</asp:ListItem>
                    <asp:ListItem Value="LR">Liberia</asp:ListItem>
                    <asp:ListItem Value="LY">Libyan Arab Jamahiriya</asp:ListItem>
                    <asp:ListItem Value="LI">Liechtenstein</asp:ListItem>
                    <asp:ListItem Value="LT">Lithuania</asp:ListItem>
                    <asp:ListItem Value="LU">Luxembourg</asp:ListItem>
                    <asp:ListItem Value="MO">Macao</asp:ListItem>
                    <asp:ListItem Value="MK">Macedonia, The Former Yugoslav Republic of</asp:ListItem>
                    <asp:ListItem Value="MG">Madagascar</asp:ListItem>
                    <asp:ListItem Value="MW">Malawi</asp:ListItem>
                    <asp:ListItem Value="MY">Malaysia</asp:ListItem>
                    <asp:ListItem Value="MV">Maldives</asp:ListItem>
                    <asp:ListItem Value="ML">Mali</asp:ListItem>
                    <asp:ListItem Value="MT">Malta</asp:ListItem>
                    <asp:ListItem Value="MH">Marshall Islands</asp:ListItem>
                    <asp:ListItem Value="MQ">Martinique</asp:ListItem>
                    <asp:ListItem Value="MR">Mauritania</asp:ListItem>
                    <asp:ListItem Value="MU">Mauritius</asp:ListItem>
                    <asp:ListItem Value="YT">Mayotte</asp:ListItem>
                    <asp:ListItem Value="MX">Mexico</asp:ListItem>
                    <asp:ListItem Value="FM">Micronesia, Federated States of</asp:ListItem>
                    <asp:ListItem Value="MD">Moldova, Republic of</asp:ListItem>
                    <asp:ListItem Value="MC">Monaco</asp:ListItem>
                    <asp:ListItem Value="MN">Mongolia</asp:ListItem>
                    <asp:ListItem Value="ME">Montenegro</asp:ListItem>
                    <asp:ListItem Value="MS">Montserrat</asp:ListItem>
                    <asp:ListItem Value="MA">Morocco</asp:ListItem>
                    <asp:ListItem Value="MZ">Mozambique</asp:ListItem>
                    <asp:ListItem Value="MM">Myanmar</asp:ListItem>
                    <asp:ListItem Value="NA">Namibia</asp:ListItem>
                    <asp:ListItem Value="NR">Nauru</asp:ListItem>
                    <asp:ListItem Value="NP">Nepal</asp:ListItem>
                    <asp:ListItem Value="NL">Netherlands</asp:ListItem>
                    <asp:ListItem Value="AN">Netherlands Antilles</asp:ListItem>
                    <asp:ListItem Value="NC">New Caledonia</asp:ListItem>
                    <asp:ListItem Value="NZ">New Zealand</asp:ListItem>
                    <asp:ListItem Value="NI">Nicaragua</asp:ListItem>
                    <asp:ListItem Value="NE">Niger</asp:ListItem>
                    <asp:ListItem Value="NG">Nigeria</asp:ListItem>
                    <asp:ListItem Value="NU">Niue</asp:ListItem>
                    <asp:ListItem Value="NF">Norfolk Island</asp:ListItem>
                    <asp:ListItem Value="MP">Northern Mariana Islands</asp:ListItem>
                    <asp:ListItem Value="NO">Norway</asp:ListItem>
                    <asp:ListItem Value="OM">Oman</asp:ListItem>
                    <asp:ListItem Value="PK">Pakistan</asp:ListItem>
                    <asp:ListItem Value="PW">Palau</asp:ListItem>
                    <asp:ListItem Value="PS">Palestinian Territory, Occupied</asp:ListItem>
                    <asp:ListItem Value="PA">Panama</asp:ListItem>
                    <asp:ListItem Value="PG">Papua New Guinea</asp:ListItem>
                    <asp:ListItem Value="PY">Paraguay</asp:ListItem>
                    <asp:ListItem Selected="True" Value="PE">Peru</asp:ListItem>
                    <asp:ListItem Value="PH">Philippines</asp:ListItem>
                    <asp:ListItem Value="PN">Pitcairn</asp:ListItem>
                    <asp:ListItem Value="PL">Poland</asp:ListItem>
                    <asp:ListItem Value="PT">Portugal</asp:ListItem>
                    <asp:ListItem Value="PR">Puerto Rico</asp:ListItem>
                    <asp:ListItem Value="QA">Qatar</asp:ListItem>
                    <asp:ListItem Value="RE">Reunion</asp:ListItem>
                    <asp:ListItem Value="RO">Romania</asp:ListItem>
                    <asp:ListItem Value="RU">Russian Federation</asp:ListItem>
                    <asp:ListItem Value="RW">Rwanda</asp:ListItem>
                    <asp:ListItem Value="SH">Saint Helena</asp:ListItem>
                    <asp:ListItem Value="KN">Saint Kitts and Nevis</asp:ListItem>
                    <asp:ListItem Value="LC">Saint Lucia</asp:ListItem>
                    <asp:ListItem Value="PM">Saint Pierre and Miquelon</asp:ListItem>
                    <asp:ListItem Value="VC">Saint Vincent and The Grenadines</asp:ListItem>
                    <asp:ListItem Value="WS">Samoa</asp:ListItem>
                    <asp:ListItem Value="SM">San Marino</asp:ListItem>
                    <asp:ListItem Value="ST">Sao Tome and Principe</asp:ListItem>
                    <asp:ListItem Value="SA">Saudi Arabia</asp:ListItem>
                    <asp:ListItem Value="SN">Senegal</asp:ListItem>
                    <asp:ListItem Value="RS">Serbia</asp:ListItem>
                    <asp:ListItem Value="SC">Seychelles</asp:ListItem>
                    <asp:ListItem Value="SL">Sierra Leone</asp:ListItem>
                    <asp:ListItem Value="SG">Singapore</asp:ListItem>
                    <asp:ListItem Value="SK">Slovakia</asp:ListItem>
                    <asp:ListItem Value="SI">Slovenia</asp:ListItem>
                    <asp:ListItem Value="SB">Solomon Islands</asp:ListItem>
                    <asp:ListItem Value="SO">Somalia</asp:ListItem>
                    <asp:ListItem Value="ZA">South Africa</asp:ListItem>
                    <asp:ListItem Value="GS">South Georgia and The South Sandwich Islands</asp:ListItem>
                    <asp:ListItem Value="ES">Spain</asp:ListItem>
                    <asp:ListItem Value="LK">Sri Lanka</asp:ListItem>
                    <asp:ListItem Value="SD">Sudan</asp:ListItem>
                    <asp:ListItem Value="SR">Suriname</asp:ListItem>
                    <asp:ListItem Value="SJ">Svalbard and Jan Mayen</asp:ListItem>
                    <asp:ListItem Value="SZ">Swaziland</asp:ListItem>
                    <asp:ListItem Value="SE">Sweden</asp:ListItem>
                    <asp:ListItem Value="CH">Switzerland</asp:ListItem>
                    <asp:ListItem Value="SY">Syrian Arab Republic</asp:ListItem>
                    <asp:ListItem Value="TW">Taiwan, Province of China</asp:ListItem>
                    <asp:ListItem Value="TJ">Tajikistan</asp:ListItem>
                    <asp:ListItem Value="TZ">Tanzania, United Republic of</asp:ListItem>
                    <asp:ListItem Value="TH">Thailand</asp:ListItem>
                    <asp:ListItem Value="TL">Timor-leste</asp:ListItem>
                    <asp:ListItem Value="TG">Togo</asp:ListItem>
                    <asp:ListItem Value="TK">Tokelau</asp:ListItem>
                    <asp:ListItem Value="TO">Tonga</asp:ListItem>
                    <asp:ListItem Value="TT">Trinidad and Tobago</asp:ListItem>
                    <asp:ListItem Value="TN">Tunisia</asp:ListItem>
                    <asp:ListItem Value="TR">Turkey</asp:ListItem>
                    <asp:ListItem Value="TM">Turkmenistan</asp:ListItem>
                    <asp:ListItem Value="TC">Turks and Caicos Islands</asp:ListItem>
                    <asp:ListItem Value="TV">Tuvalu</asp:ListItem>
                    <asp:ListItem Value="UG">Uganda</asp:ListItem>
                    <asp:ListItem Value="UA">Ukraine</asp:ListItem>
                    <asp:ListItem Value="AE">United Arab Emirates</asp:ListItem>
                    <asp:ListItem Value="GB">United Kingdom</asp:ListItem>
                    <asp:ListItem Value="US">United States</asp:ListItem>
                    <asp:ListItem Value="UM">United States Minor Outlying Islands</asp:ListItem>
                    <asp:ListItem Value="UY">Uruguay</asp:ListItem>
                    <asp:ListItem Value="UZ">Uzbekistan</asp:ListItem>
                    <asp:ListItem Value="VU">Vanuatu</asp:ListItem>
                    <asp:ListItem Value="VE">Venezuela</asp:ListItem>
                    <asp:ListItem Value="VN">Viet Nam</asp:ListItem>
                    <asp:ListItem Value="VG">Virgin Islands, British</asp:ListItem>
                    <asp:ListItem Value="VI">Virgin Islands, U.S.</asp:ListItem>
                    <asp:ListItem Value="WF">Wallis and Futuna</asp:ListItem>
                    <asp:ListItem Value="EH">Western Sahara</asp:ListItem>
                    <asp:ListItem Value="YE">Yemen</asp:ListItem>
                    <asp:ListItem Value="ZM">Zambia</asp:ListItem>
                    <asp:ListItem Value="ZW">Zimbabwe</asp:ListItem>

                </asp:DropDownList>
                <asp:XmlDataSource ID="XmlDataSource1" runat="server"></asp:XmlDataSource>
                <br />
                <div class="etqs color">Idioma</div>
                <asp:DropDownList runat="server" ID="ddlIdioma" class="txts tamanoNormal"> 
                    <asp:ListItem Value="ES">Español</asp:ListItem>
                    <asp:ListItem Value="EN">Inglés</asp:ListItem>
                </asp:DropDownList>
                <br />
                <div class="etqs color">Ciudad</div>
                <asp:TextBox runat="server" ID="ddlCiudad2" class="txts tamanoNormal" placeholder="Ingrese ciudad" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDireccion" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />

                <%--                <div class="etqs color">Ciudad</div>
                <asp:DropDownList runat="server" ID="ddlCiudad" class="txts tamanoNormal">
                </asp:DropDownList>
                <br />--%>
                <div class="etqs color">Dirección</div>
                <asp:TextBox runat="server" ID="txtDireccion" class="txts tamanoNormal" placeholder="Ingrese dirección" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDireccion" ControlToValidate="txtDireccion" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />

                <div class="rubros_container color">
                    <div class="etqs color">Rubro</div>
                    <asp:DropDownList runat="server" ID="ddlRubro" class="txts tamanoNormal" OnSelectedIndexChanged="ddlRubro_SelectedIndexChanged" AutoPostBack="True" placeholder="Ingrese rubro">

                        <asp:ListItem Selected="True" Value="default">--Seleccione--</asp:ListItem>
                        <asp:ListItem Value="alimentos animal">Alimentos - Animal</asp:ListItem>
                        <asp:ListItem Value="alimentos consumo">Alimentos - Consumo</asp:ListItem>
                        <asp:ListItem Value="alimentos insumos">Alimentos - Insumos</asp:ListItem>
                        <asp:ListItem Value="industrial extraccion">Industrial - Extracción</asp:ListItem>
                        <asp:ListItem Value="industrial farma">Industrial - Farma</asp:ListItem>
                        <asp:ListItem Value="industrial maquilado">Industrial - Maquilado</asp:ListItem>
                        <asp:ListItem Value="industrial quimico">Industrial - Químico</asp:ListItem>
                        <asp:ListItem Value="industrial vestido">Industrial - Vestido</asp:ListItem>

                    </asp:DropDownList>

                    <div class="etqs color">Segmento</div>

                    <asp:DropDownList runat="server" ID="segmento1" class="txts tamanoNormal">
                        <asp:ListItem Value="harinas">Harina de pescado</asp:ListItem>
                        <asp:ListItem Value="pet food">Pet Food</asp:ListItem>
                        <asp:ListItem Value="balanceados y forrajes">Balanceados y Forrajes</asp:ListItem>
                        <asp:ListItem Value="otros">Otros</asp:ListItem>
                    </asp:DropDownList>


                    <asp:DropDownList runat="server" ID="segmento2" class="txts tamanoNormal">

                        <asp:ListItem Value="aceites">Aceites</asp:ListItem>
                        <asp:ListItem Value="agricola">Agrícola</asp:ListItem>
                        <asp:ListItem Value="azucar">Azucar</asp:ListItem>
                        <asp:ListItem Value="bebidas alcohólicas">Bebidas Alcohólicas</asp:ListItem>
                        <asp:ListItem Value="bebidas no alcohólicas">Bebidas No Alcohólicas</asp:ListItem>
                        <asp:ListItem Value="carnicos">Carnicos</asp:ListItem>
                        <asp:ListItem Value="chocolate">Chocolate</asp:ListItem>
                        <asp:ListItem Value="conservas">Conservas</asp:ListItem>
                        <asp:ListItem Value="fideos">Fideos</asp:ListItem>
                        <asp:ListItem Value="galletas">Galletas</asp:ListItem>
                        <asp:ListItem Value="golosinas">Golosinas</asp:ListItem>
                        <asp:ListItem Value="helados">Helados</asp:ListItem>
                        <asp:ListItem Value="pesca">Pesca</asp:ListItem>
                        <asp:ListItem Value="snacks">Snacks</asp:ListItem>
                        <asp:ListItem Value="otros">Otros</asp:ListItem>

                    </asp:DropDownList>



                    <asp:DropDownList runat="server" ID="segmento3" class="txts tamanoNormal">
                        <asp:ListItem Value="semillas y granos">Semillas y Granos</asp:ListItem>
                        <asp:ListItem Value="otros">Otros</asp:ListItem>
                    </asp:DropDownList>


                    <asp:DropDownList runat="server" ID="segmento4" class="txts tamanoNormal">
                              <asp:ListItem Value="hidrocarburos">Hidrocarburos</asp:ListItem>
                        <asp:ListItem Value="minería">Minería</asp:ListItem>
                        <asp:ListItem Value="otros">Otros</asp:ListItem>

                    </asp:DropDownList>



                    <asp:DropDownList runat="server" ID="segmento5" class="txts tamanoNormal">
                        <asp:ListItem Value="farmacéutico">Farmacéutico</asp:ListItem>
                        <asp:ListItem Value="cosmético">Cosmético</asp:ListItem>
                        <asp:ListItem Value="veterinario">Veterinario</asp:ListItem>
                        <asp:ListItem Value="otros">Otros</asp:ListItem>

                    </asp:DropDownList>


                    <asp:DropDownList runat="server" ID="segmento6" class="txts tamanoNormal">
                        <asp:ListItem Value="hojalatería">Hojalatería</asp:ListItem>
                        <asp:ListItem Value="papel">Papel</asp:ListItem>
                        <asp:ListItem Value="carton">Carton</asp:ListItem>
                        <asp:ListItem Value="otros">Otros</asp:ListItem>

                    </asp:DropDownList>

                    <asp:DropDownList runat="server" ID="segmento7" class="txts tamanoNormal">
                        <asp:ListItem Value="colorantes">Colorantes</asp:ListItem>
                        <asp:ListItem Value="pinturas">Pinturas</asp:ListItem>
                        <asp:ListItem Value="plásticos">Plásticos</asp:ListItem>
                        <asp:ListItem Value="fertilizantes">Fertilizantes</asp:ListItem>
                        <asp:ListItem Value="insumos">Insumos</asp:ListItem>
                        <asp:ListItem Value="otros">Otros</asp:ListItem>

                    </asp:DropDownList>

                   
                    <asp:DropDownList runat="server" ID="segmento8" class="txts tamanoNormal">
                        <asp:ListItem Value="textil">Textil</asp:ListItem>
                        <asp:ListItem Value="otros">Otros</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <br />
                <div class="etqs color">Dominio</div>
                <asp:TextBox runat="server" ID="txtDominio" ReadOnly class="txts tamanoNormal soloLectura"></asp:TextBox>
                <br />
                <div class="etqs color">Tipo de Uso</div>
                <asp:RadioButton runat="server" ID="rbEmpresa" GroupName="Tipos" Checked Text="Privado" />
                <asp:RadioButton runat="server" ID="rbServicio" GroupName="Tipos" Text="Servicio" />
                <br />
                <div class="etqs color">Correo</div>
                <asp:TextBox runat="server" ID="txtCorreo" ReadOnly class="txts tamanoNormal soloLectura"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCorreo" ControlToValidate="txtCorreo" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <br />
            </fieldset>


            <fieldset class="fielset" style="float: right;">
                <legend class="color">USUARIO</legend>
                <div class="etqs color">Nombre Completo</div>
                <asp:TextBox runat="server" ID="txtNombre" class="txts tamanoNormal" placeholder="Ingrese nombre completo" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <div class="etqs color">Correo</div>
                <asp:TextBox runat="server" ID="txtCorreoE" ReadOnly class="txts tamanoNormal soloLectura"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCorreoE" runat="server" ControlToValidate="txtCorreoE" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <%--   <div class="etqs color"> Usuario</div>
            <asp:TextBox runat="server" ID="txtUsuario" class="txts tamanoNormal"></asp:TextBox>
            <br />--%>
                <div class="etqs color">Clave</div>
                <asp:TextBox runat="server" ID="txtClave" class="txts tamanoNormal" TextMode="Password" placeholder="Ingrese clave" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClave" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <div class="etqs color">Confirmar Clave</div>
                <asp:TextBox runat="server" ID="txtClaveConf" class="txts tamanoNormal" TextMode="Password" placeholder="Repite clave" autocomplete="off"></asp:TextBox><br />
                <asp:CompareValidator ID="cvClaveConf" runat="server" ControlToValidate="txtClaveConf" ControlToCompare="txtClave" Style="float: right;" ErrorMessage="La confirmación de la clave no coincide." ForeColor="red"></asp:CompareValidator>
                <br />
                <br />

            </fieldset>
            <br />
            <br />
            <div id="InformacionTerminos" style="float: right;">
                Al hacer clic en "Finalizar Registro", usted está de acuerdo con nuestros Términos y Condiciones.
                <br />
                <asp:CheckBox runat="server" GroupName="opciones" Style="display: inline-block; background: none" ID="chkAceptar" Text="Estoy de acuerdo" /><br />
            </div>

            <br />
            <asp:Button runat="server" CssClass="btns" ID="btnFinalizar" Style="width: 850PX" Text="FINALIZAR REGISTRO" OnClick="btnFinalizar_Click" />
            <br />
            <br />

        </div>

    </form>

</body>
</html>
