<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="TC.Seguridad.Seguridad_Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="Server">
    <table>
        <tr>
            <td>
                <asp:Image runat="server" ID="imgError" SkinID="mensError" />
            </td>
            <td>
                <asp:Label ID="lblError" runat="server" Text="Ha ocurrido un error genérico en el sistema. Por favor verifique el Log de errores con el Administrador." />
            </td>
        </tr>
    </table>
</asp:Content>
