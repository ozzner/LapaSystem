<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Administrador.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="LimsWeb.iAdministrador.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/css/main_fonts.css" rel="stylesheet" />
    <style>
        .graficos {
            width: 48%;
            display: inline-block;
            height: 250px;
            background: none;
            border-radius: 5px;
            border: 1px solid #ccc;
            float: left;
            margin-right: 4px;
            margin-bottom: 4px;
        }

        .tituloInfo {
            border-bottom: 1px solid gray;
            padding: 10px 0px;
            text-align: left;
            padding-left: 20px;
            font-weight: bold;
            opacity: 0.7;
        }

        .titulo {
            width: 100%;
            font-size:15px;
            font-weight:bold;
            margin-bottom:3px;
            text-transform:uppercase;
            margin-top:10px;
            }

        .textboxes {
            width: 100%;
            height:30px;
            border-radius:5px;
         
            padding-left:20px;
            font-size:14px;
        }

        .contInfo {
            width: 70%;
            margin:0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdministrador" runat="server">

    <div class="graficos" style="height: 605px;float: left; margin-top: 10px; margin-left: 15px">
        <div class="tituloInfo">
            <%= info %>
        </div>

        <br />

        <div class="contInfo">
            <div class="titulo">
                RUC
            </div>

            <asp:Label ID="txtRuc" Text="1073184145" class="textboxes" runat="server"></asp:Label>

            <div class="titulo">
                <%= rz %>
            </div>

            <asp:Label ID="txtRazonSocial" Text="LOS PELADOS CONSULTING SAC" class="textboxes" runat="server"></asp:Label>

            <div class="titulo">
                <%= country %>
            </div>

            <asp:Label ID="txtNomPais" Text="Perú" class="textboxes" runat="server"></asp:Label>

            <div class="titulo">
                <%= city %>
            </div>

            <asp:Label ID="txtNomCiudad" Text="Lima" class="textboxes" runat="server"></asp:Label>

            <div class="titulo">
                <%= rb %>
            </div>

            <asp:Label ID="txtNomRubro" Text="MEDICINA" class="textboxes" runat="server"></asp:Label>

            <div class="titulo">
                <%= segment %>
            </div>

            <asp:Label ID="txtDom" Text="" class="textboxes" runat="server"></asp:Label>

            <div class="titulo">
                <%= dir %>
            </div>

            <asp:Label ID="txtDireccion"  Text="Av.Enrique Guzman y Valle #755"  class="textboxes" runat="server"></asp:Label>

            

            <div class="titulo">
                <%= type %>
            </div>

            <asp:Label ID="txtUso" Text="Servicio" class="textboxes" runat="server"></asp:Label>


             <div class="titulo">
               Plan
            </div>

            <asp:Label ID="txtPlanes" Text="Planes" class="textboxes" runat="server"></asp:Label>
        </div>


    </div>

    <div class="graficos" style="float: right; margin-right: 15px; margin-top: 10px">

        <div class="tituloInfo">LABORATORIOS </div>
        <br />
        <div class="grilla" style="margin-left: 15px; background: none; width: 100%">
            <asp:GridView ID="gvLaboratorio" runat="server" Width="95%" AutoGenerateColumns="false" HeaderStyle-Height="30px" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>

                    <asp:BoundField HeaderText="LaboratorioID" DataField="LaboratorioID" Visible="false" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="LaboratorioID">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="150px" />
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Laboratorio" DataField="NomLaboratorio" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="NomLaboratorio">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="200px" />
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Ubicacion" DataField="Ubicacion" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="Ubicacion">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="200px" />
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Supervisor" DataField="NomUsuario" HeaderStyle-CssClass="gvCabecera"
                        SortExpression="NomUsuario">
                        <HeaderStyle CssClass="gvCabecera"></HeaderStyle>
                        <ItemStyle Width="200px" />
                    </asp:BoundField>

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

    <div class="grilla" style="background: none; width: 110%">
        <a href="<%= enlace_2 %>" target="_blank"><img src="<%= url_2 %>" style="margin: 10px 0 0 10px;height:170px; width:44%"/></a>
        <a href="<%= enlace_3 %>" target="_blank"><img src="<%= url_3 %>" style="margin: 0px 0 0 10px;height:170px; width:44%"/></a>
    </div>

</asp:Content>