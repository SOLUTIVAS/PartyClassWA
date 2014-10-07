<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true"
    CodeFile="Welcome.aspx.cs" Inherits="PC.Welcome" Title="Party Class - Welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta name="title" content="Party Class | WebAppPC" />
	<meta name="description" content="Bienvenido a la aplicación web de Party Class" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Bienvenido a Party Class Web</h2>
	
	<p class="description">
		La aplicación web de gestión de eventos que nos facilitará la vida. Seleccione una de las opciones del menú superior para comenzar.
	</p>
	<telerik:RadToolTipManager runat="server" ID="RadToolTipManagerAbout" Position="MiddleRight"
		RelativeTo="Element" HideDelay="8000" Width="400px" ToolTipZoneID="aboutArea" AutoTooltipify="true" CssClass="OlympicGamesTooltips">
	</telerik:RadToolTipManager>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="aboutPage">
        <div class="main" id="aboutArea">
            <h3>Bienvenido al WebApp de PartyClass</h3>
        </div>
    </div>
</asp:Content>--%>
