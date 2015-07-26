<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HolaMundo.aspx.cs" Inherits="LimsWeb.HolaMundo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Hola mundo!</title>

    <style type="text/css">
        .holamundo
        {
        margin:auto; 
        margin-top:150px;
        font-family:Calibri;
        height:100px;
        width:200px; 
        background:#ddd; 
        line-height:100px; 
        text-align:center; 
        border-radius:4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="holamundo">
                Hola mundo!           
        </div>
    </form>
</body>
</html>
