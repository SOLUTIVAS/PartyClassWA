<%@ Page Title="" Language="C#" MasterPageFile="~/Publica.master" AutoEventWireup="true" CodeFile="ErrorPublico.aspx.cs" Inherits="TC.Seguridad.Seguridad_ErrorPublico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="Server">
    <table>
        <tr>
            <td>
                <asp:Image runat="server" ID="imgError" SkinID="mensError" />
            </td>
            <td>
                <asp:Label ID="lblError" runat="server" Text="Ha ocurrido un error genérico en el sistema. Por favor internte más tarde." />
            </td>
        </tr>
    </table>
</asp:Content>
