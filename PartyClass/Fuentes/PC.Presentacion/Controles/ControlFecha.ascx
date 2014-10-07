<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlFecha.ascx.cs" Inherits="Controles_ControlFecha" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<asp:TextBox ID="textFecha" runat="server" BackColor="White" CssClass="tbxCampoFechaDosCol"></asp:TextBox>
<asp:ImageButton ID="imagenFecha" runat="server" SkinID="imgCalendario" CausesValidation="False" />
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<cc1:CalendarExtender ID="CalendarExtenderFecha" runat="server" CssClass="MyCalendar" Format="yyyy/MM/dd" PopupButtonID="imagenFecha" TargetControlID="textFecha">
</cc1:CalendarExtender>
<cc1:MaskedEditExtender ID="MaskedEditExtenderFecha" runat="server" CultureName="ja-JP" ErrorTooltipEnabled="true" MaskType="Date" Mask="9999/99/99" TargetControlID="textFecha">
</cc1:MaskedEditExtender>
<cc1:MaskedEditValidator ID="MaskedEditValidatorFecha" runat="server" ControlExtender="MaskedEditExtenderFecha" ControlToValidate="textFecha" Display="Dynamic" ErrorMessage="*" InvalidValueBlurredMessage="*" ValidationGroup="validator">
</cc1:MaskedEditValidator>
