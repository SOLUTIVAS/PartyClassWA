<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Publica.master" Title="Registrarse" 
CodeFile="PublicRegistro.aspx.cs" Inherits="TC.PublicRegistro" ClientIDMode="Static" %>
<%@ Register Src="~/Controles/PanelMensajes.ascx" TagName="PanelMensajes" TagPrefix="uc1" %>
<%@ Register TagPrefix="UC" TagName="MensajeSistema" Src="~/Controles/MensajeSistema.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="Server">
    <script type="text/javascript">
        function pageLoad() {
            $("#dtpNacimiento").datepicker({
                changeMonth: true,
                changeYear: true,
                altField: '[id$=HdtpNacimiento]'
            });
            if (!($("[id$=HdtpNacimiento]").attr("Value") == undefined)) {
                if ($("[id$=HdtpNacimiento]").attr("Value").length > 0) {
                    $("[id$=dtpNacimiento]").datepicker("setDate", new Date($("[id$=HdtpNacimiento]").attr("Value")));
                }
            }
            $("#dtpLlegadaHotel").datepicker({
                changeMonth: true,
                changeYear: true,
                altField: '[id$=HdtpLlegadaHotel]'
            });
            if (!($("[id$=HdtpLlegadaHotel]").attr("Value") == undefined)) {
                if ($("[id$=HdtpLlegadaHotel]").attr("Value").length > 0) {
                    $("[id$=dtpLlegadaHotel]").datepicker("setDate", new Date($("[id$=HdtpLlegadaHotel]").attr("Value")));
                }
            }
            $("#dtpSalidaHotel").datepicker({
                changeMonth: true,
                changeYear: true,
                altField: '[id$=HdtpSalidaHotel]'
            });
            if (!($("[id$=HdtpSalidaHotel]").attr("Value") == undefined)) {
                if ($("[id$=HdtpSalidaHotel]").attr("Value").length > 0) {
                    $("[id$=dtpSalidaHotel]").datepicker("setDate", new Date($("[id$=HdtpSalidaHotel]").attr("Value")));
                }
            }
            $("#dtpSalidaVuelo").datepicker({
                changeMonth: true,
                changeYear: true,
                altField: '[id$=HdtpSalidaVuelo]'
            });
            if (!($("[id$=HdtpSalidaVuelo]").attr("Value") == undefined)) {
                if ($("[id$=HdtpSalidaVuelo]").attr("Value").length > 0) {
                    $("[id$=dtpSalidaVuelo]").datepicker("setDate", new Date($("[id$=HdtpSalidaVuelo]").attr("Value")));
                }
            }
            $("#dtpRegresoVuelo").datepicker({
                changeMonth: true,
                changeYear: true,
                altField: '[id$=HdtpRegresoVuelo]'
            });
            if (!($("[id$=HdtpRegresoVuelo]").attr("Value") == undefined)) {
                if ($("[id$=HdtpRegresoVuelo]").attr("Value").length > 0) {
                    $("[id$=dtpRegresoVuelo]").datepicker("setDate", new Date($("[id$=HdtpRegresoVuelo]").attr("Value")));
                }
            }
        }
    </script>
    <asp:UpdatePanel ID="EmployeesUpdatePanel" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td class="tdVentanaCenCen" style="text-align: center">
                        <p class="tdTituloFormularioEtiqueta">
                            Formulario de registro</p>
                        <p class="tdTituloFormularioEtiqueta">
                            *Evento:
                            <asp:DropDownList ID="ddEvento" runat="server" Width="583px" 
                                DataTextField="Descripcion" DataValueField="idEvento" />
                        </p>
                    </td>
                </tr>
            </table>
            <br />
            <table width="100%">
                <tr>
                    <td>
                        <p class="pVentanaTitulo">
                            Ingrese sus datos:&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblNombreCliente" runat="server"></asp:Label>
                            &nbsp;&nbsp;</p>
                    </td>
                </tr>
            </table>
            <table class="tblFormulario">
                <tr>
                    <td style="height: 23px; width: 522px;">
                        *Documento:
                    </td>
                    <td style="height: 23px; width: 223px;">
                        <asp:TextBox ID="txtDocumento" runat="server" Height="18px" MaxLength="15" ToolTip="Documento del cliente (ingrese sólo números sin puntos ni comas)"
                            Width="153px"></asp:TextBox>
                    </td>
                    <td style="height: 22px; width: 540px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 407px;">
                        *Celular:&nbsp;
                    </td>
                    <td style="height: 22px; width: 343px;">
                        <asp:TextBox ID="txtCelular" runat="server" Width="152px" Height="18px" MaxLength="15"
                            ToolTip="Ingrese el número de celular del cliente"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RangeValidator ID="RangeValidatorDoc" runat="server" Width="130px" ErrorMessage="Ingrese un valor válido."
                            ControlToValidate="txtDocumento" MaximumValue="999999999999999" MinimumValue="0"
                            Type="Double" SetFocusOnError="True"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 522px;">
                        *Nombres:
                    </td>
                    <td style="height: 23px; width: 223px;">
                        <asp:TextBox ID="txtNombres" runat="server" Width="152px" Height="18px" MaxLength="50"
                            ToolTip="Ingrese los nombres del cliente"></asp:TextBox>
                    </td>
                    <td style="width: 540px">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 407px;">
                        *Apellidos:
                    </td>
                    <td style="height: 22px; width: 343px;">
                        <asp:TextBox ID="txtApellidos" runat="server" Width="153px" Height="18px" MaxLength="50"
                            ToolTip="Ingrese los apellidos del cliente"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 522px;">
                        *Fecha Nacimiento:
                    </td>
                    <td style="height: 23px; width: 223px;">
                        <asp:TextBox runat="server" type="text" ID="dtpNacimiento" name="dtpNacimiento" Style="height: 18px;
                            width: 152px;" ReadOnly="True" ToolTip="Ingrese la fecha de nacimiento del cliente"
                            ViewStateMode="Enabled">01/01/1970</asp:TextBox>
                        <asp:HiddenField ID="HdtpNacimiento" runat="server" />
                    </td>
                    <td style="width: 540px">
                    </td>
                    <td style="height: 22px; width: 407px;">
                        *Email:
                    </td>
                    <td style="height: 22px; width: 343px;">
                        <asp:TextBox ID="txtEmail" runat="server" Width="153px" Height="18px" MaxLength="70"
                            ToolTip="Ingrese su correo electrónino Ej alguien@gmail.com"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 522px;">
                        *Cargo:
                    </td>
                    <td style="height: 23px; width: 223px;">
                        <asp:DropDownList ID="ddCargo" runat="server" Width="152px" AutoPostBack="True" ToolTip="Ingrese el cargo del cliente, si es &quot;Otro&quot; especifique en el siguiente campo"
                            OnTextChanged="ddCargo_TextChanged" OnDataBound="ddCargo_DataBound" 
                            DataTextField="Nombre" DataValueField="Id">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 540px">
                    </td>
                    <td style="height: 22px; width: 407px;">
                        Especifique Cargo:
                    </td>
                    <td style="height: 22px; width: 343px;">
                        <asp:TextBox ID="txtOtro" runat="server" Width="152px" Height="56px" MaxLength="200"
                            ToolTip="Especifique el cargo si seleccionó &quot;Otro&quot; o ingrese las observaciones necesarias."
                            Enabled="False" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 522px;">
                        *Departamento:
                    </td>
                    <td style="height: 23px; width: 223px;">
                        <asp:DropDownList ID="ddDepartamento" runat="server" Width="152px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddDepartamento_SelectedIndexChanged" DataTextField="Descripcion"
                            DataValueField="idDepartamento" ToolTip="Seleccione un departamento" OnDataBound="ddDepartamento_DataBound">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 540px">
                    </td>
                    <td style="height: 22px; width: 407px;">
                        *Municipio:
                    </td>
                    <td style="height: 22px; width: 343px;">
                        <asp:DropDownList ID="ddMunicipio" runat="server" Width="152px" ToolTip="Seleccione un municipio"
                            Enabled="False">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 522px;">
                        &nbsp;
                    </td>
                    <td style="height: 23px; width: 223px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 540px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 407px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 343px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 522px;">
                        <asp:CheckBox ID="chkRequiereHotel" runat="server" AutoPostBack="True" Text="Requiere Hotel?"
                            OnCheckedChanged="chkRequiereHotel_CheckedChanged" />
                    </td>
                    <td style="height: 23px; width: 223px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 540px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 407px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 343px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 522px;">
                        Fecha CheckIn Hotel:
                    </td>
                    <td style="height: 23px; width: 223px;">
                        <asp:TextBox runat="server" type="text" ID="dtpLlegadaHotel" name="dtpLlegadaHotel"
                            Style="height: 18px; width: 152px;" Enabled="False" ReadOnly="True" />
                        <asp:HiddenField ID="HdtpLlegadaHotel" runat="server" />
                    </td>
                    <td style="height: 22px; width: 540px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 407px;">
                        Fecha CheckOut Hotel:
                    </td>
                    <td style="height: 23px; width: 343px;">
                        <asp:TextBox runat="server" type="text" ID="dtpSalidaHotel" name="dtpSalidaHotel"
                            Style="height: 18px; width: 152px;" Enabled="False" ReadOnly="True" />
                        <asp:HiddenField ID="HdtpSalidaHotel" runat="server" />
                    </td>
                    <td style="height: 22px">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 522px;">
                        Acomodación:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddAcomodacion" runat="server" Width="152px" Enabled="False"
                            OnDataBound="ddAcomodacion_DataBound">
                            <asp:ListItem>(Seleccione)</asp:ListItem>
                            <asp:ListItem>SENCILLA</asp:ListItem>
                            <asp:ListItem>DOBLE</asp:ListItem>
                            <asp:ListItem>TRIPLE</asp:ListItem>
                            <asp:ListItem>CUADRUPLE</asp:ListItem>
                            <asp:ListItem>FAMILIAR</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="height: 22px; width: 540px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 407px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 343px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 522px;">
                        &nbsp;
                    </td>
                    <td style="height: 23px; width: 223px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 540px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 407px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 343px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 522px;">
                        <asp:CheckBox ID="chkRequierePasajes" runat="server" AutoPostBack="True" Text="Requiere Pasajes?"
                            OnCheckedChanged="chkRequierePasajes_CheckedChanged" />
                    </td>
                    <td style="height: 23px; width: 223px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 540px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 407px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 343px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 522px;">
                        Fecha Salida Vuelo:
                    </td>
                    <td style="height: 23px; width: 223px;">
                        <asp:TextBox runat="server" type="text" ID="dtpSalidaVuelo" name="dtpSalidaVuelo"
                            Style="height: 18px; width: 152px;" Enabled="False" ReadOnly="True" />
                        <asp:HiddenField ID="HdtpSalidaVuelo" runat="server" />
                    </td>
                    <td style="height: 22px; width: 540px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 407px;">
                        Fecha Regreso Vuelo:
                    </td>
                    <td style="height: 23px; width: 343px;">
                        <asp:TextBox runat="server" type="text" ID="dtpRegresoVuelo" Style="height: 18px;
                            width: 152px;" Enabled="False" ReadOnly="True" />
                        <asp:HiddenField ID="HdtpRegresoVuelo" runat="server" />
                    </td>
                    <td style="height: 22px">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px; width: 522px;">
                        Lugar Salida:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLugarSalidaVuelo" runat="server" Width="152px" Height="18px"
                            MaxLength="50" ToolTip="Especifique la ciudad desde donde saldrá" Enabled="False"></asp:TextBox>
                    </td>
                    <td style="height: 22px; width: 540px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 407px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 343px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <br />
            <table class="tblFormulario">
                <tr>
                    <td style="height: 23px; width: 522px;">
                        &nbsp;
                    </td>
                    <td style="height: 23px; width: 223px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 540px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 407px;">
                        &nbsp;
                    </td>
                    <td style="height: 22px; width: 343px;">
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar Solicitud" Width="100px" OnClick="btnEnviar_Click" />
                    </td>
                    <td style="height: 22px">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <br />
            <table width="100%">
                <tr>
                    <td class="tdVentanaCenCen">
                        <asp:Label ID="lblResultado" runat="server" Font-Bold="True" ForeColor="#CC3300"
                            Text="TextoEror" Visible="False"></asp:Label>
                        <asp:Label ID="lblExito" runat="server" Font-Bold="True" ForeColor="#33CC33" Text="Usted se ha inscrito satisfactoriamente al evento. Espere la llamada de nuestros asesores."
                            Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="RegistrarClienteUpdateProgress" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="EmployeesUpdatePanel">
        <ProgressTemplate>
            <div id="ovrCF" class="overlay">
                <div class="overlayContent">
                    <h3>
                    <asp:Image runat="server" ID="imgProg" SkinID="Progreso" />
                        Cargando...</h3>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
