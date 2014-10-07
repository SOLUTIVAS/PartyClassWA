<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModalCliente.ascx.cs"
    Inherits="ModalCliente" %>
<div class="formulario">
    <asp:UpdatePanel ID="UPNewItem" runat="server">
        <ContentTemplate>
            <br />
            <div onkeypress="if (event.keyCode == 13) event.returnValue = false">
                <asp:HiddenField ID="ID" runat="server" />
                <asp:Label ID="Label1" CssClass="label" Text="Documento Cliente: " runat="server" />
                <br />
                <asp:TextBox CssClass="textfield" ID="txtNumeroConcepto" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="required" ValidationGroup="CC"
                    ErrorMessage="*" ControlToValidate="txtNumeroConcepto" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[A-Za-z0-9]*$"
                    ErrorMessage="Caracteres inválidos" EnableClientScript="true" ValidationGroup="CC"
                    Display="Dynamic" ControlToValidate="txtNumeroConcepto" />
                <br />
                <br />
                <asp:Label ID="Label2" CssClass="label" Text="Descripción Concepto: " runat="server" />
                <br />
                <asp:TextBox CssClass="textfield" Width="350px" ID="txtDescripcionConcepto" runat="server"
                    onkeypress="return MaxLength(this,100)" />
                <asp:RequiredFieldValidator EnableClientScript="true" CssClass="required" ID="RequiredFieldValidatorDescripcion"
                    ValidationGroup="CC" ErrorMessage="*" ControlToValidate="txtDescripcionConcepto"
                    runat="server" />
                <br />
                <br />
                <asp:Label ID="Label3" CssClass="label" Text="Cálculo: " runat="server" />
                <br />
                <asp:DropDownList ID="ddlCalculo" runat="server">
                    <asp:ListItem Selected="True" Text="Suma" Value="true" />
                    <asp:ListItem Text="Resta" Value="false" />
                </asp:DropDownList>
                <br />
                <br />
                <asp:CheckBox ID="chkObligatoria" CssClass="labelCheckbox" Text="Inversiones" runat="server"
                    ToolTip="Este concepto contable debe contener un valor mayor o igual a cero." />
                <br />
                <br />
                <hr />
            </div>
            <asp:Button CssClass="submit" Text="Insertar" ID="btnGuardar" ValidationGroup="CC"
                runat="server"/>
            <asp:Button CssClass="submit" Text="Cancelar" ID="btnCancelar" runat="server"/>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UPNewItem">
        <ProgressTemplate>
            <div id="ovrCN" class="overlay">
                <div class="overlayContent">
                    <asp:Image runat="server" ID="imgProg" SkinID="Progreso"/>
                    <h2>
                        Cargando...</h2>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</div>
