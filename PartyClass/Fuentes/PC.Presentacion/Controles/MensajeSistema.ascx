<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MensajeSistema.ascx.cs" Inherits="MensajeSistema" %>
<asp:Panel ID="pnlError" runat="server" Visible="False">
    <table width="100%" cellspacing="10">
        <tr class="row">
            <td align="center">
                <asp:Image runat="server" ID="imgError" SkinID="mensError" />
                <asp:Label ID="lblError" CssClass="error" SkinID="ErrorMessage" runat="server" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlAdvertencia" runat="server" Visible="False">
    <table width="100%" cellspacing="10">
        <tr class="row">
            <td align="center">
                <asp:Image runat="server" ID="menAlert" SkinID="mensAlerta" />
                <asp:Label ID="lblAdvertencia" CssClass="alert" SkinID="AlertMessage" runat="server" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlInformacion" runat="server" Visible="False">
    <table width="100%" cellspacing="10">
        <tr class="row">
            <td align="center">
                <asp:Image runat="server" ID="Image1" SkinID="mensInfo" />
                <asp:Label ID="lblInformacion" CssClass="info" SkinID="InfoMessage" runat="server" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlOk" runat="server" Visible="False">
    <table width="100%" cellspacing="10">
        <tr class="row">
            <td align="center">
                <asp:Image runat="server" ID="imgOk" SkinID="mensOk" />
                <asp:Label ID="lblOk" CssClass="ok" SkinID="SuccessMessage" runat="server" />
            </td>
        </tr>
    </table>
</asp:Panel>
