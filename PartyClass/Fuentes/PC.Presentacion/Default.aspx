<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="PC._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Party Class Web | Iniciar Sesión</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <br />
    <table class="tblLogin">
        <tr>
            <td>
                PartyClass WebApp 
            </td>
        </tr>
    </table>
    <br />
    <table class="tblLogin">
        <tr>
            <td style="height: 23px; width: 100px;">
                Usuario:
            </td>
            <td style="width: 200px">
                <asp:TextBox ID="txtUsuario" runat="server" Width="195px" MaxLength="100" />
            </td>
        </tr>
        <tr>
            <td>
                Contraseña:
            </td>
            <td style="width: 200px">
                <asp:TextBox ID="txtPassword" runat="server" Width="195px" TextMode="Password" 
                    MaxLength="100"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table class="tblLogin">
        <tr>
            <td>
                <asp:Button runat="server" ID="btnIngresar" SkinID="botonIngresar" OnClick="btnIngresar_Click" />
                <br />
                <asp:Label ID="lblError" runat="server" SkinID="labelError" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
