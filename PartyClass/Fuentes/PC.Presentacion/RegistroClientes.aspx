<%@ Page Language="C#" MasterPageFile="~/Principal.master" Title="Crear Cliente - Estudiante"
    AutoEventWireup="true" CodeFile="RegistroClientes.aspx.cs" Inherits="TC.RegistroClientes"
    ClientIDMode="Static" %>

<%@ Register Src="~/Controles/PanelMensajes.ascx" TagName="PanelMensajes" TagPrefix="uc1" %>
<%@ Register TagPrefix="UC" TagName="MensajeSistema" Src="~/Controles/MensajeSistema.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function pageLoad() {
            $('#dtpNacimiento').unbind();
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
            $("#accordionFun").accordion({
                collapsible: true,
                heightStyle: "content"
            });
        } 
    </script>
    <%--<asp:UpdatePanel ID="EmployeesUpdatePanel" runat="server">--%>
    <contenttemplate>
            <table width="100%">
                <tr>
                    <td class="tdVentanaCenCen">
                        <p class="tdTituloFormularioEtiqueta">
                            Registrar Cliente</p>
                    </td>
                </tr>
            </table>
            <br />
            <UC:MensajeSistema runat="server" ID="ucMensajes" />
            <table width="100%">
                <tr>
                    <td class="tdVentanaCenCen">
                        <asp:Panel ID="Panel2" runat="server">
                            <table class="tblFormulario">
                                <tr>
                                    <td style="height: auto; width: 148px;">
                                        *Nombres:
                                    </td>
                                    <td style="height: 22px; width: 248px; margin-left: 80px;">
                                        <asp:TextBox ID="txtNombre" runat="server" Width="172px" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre"
                                            ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                    <td style="height: 22px">
                                        *Apellidos:
                                    </td>
                                    <td style="height: 22px">
                                        <asp:TextBox ID="txtApellidos" runat="server" Width="172px" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtApellidos"
                                            ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 23px; width: 148px;">
                                        Tipo identificación:
                                    </td>
                                    <td style="height: 23px; width: 248px;">
                                        <asp:DropDownList ID="ddTipoIdentificacion" runat="server" SkinID="ddlRegistroClientes"
                                            Width="172px">
                                            <asp:ListItem Value="0">(Seleccione)</asp:ListItem>
                                            <asp:ListItem Value="1">Cédula de Ciudadanía</asp:ListItem>
                                            <asp:ListItem Value="2">Cédula de Extranjería</asp:ListItem>
                                            <asp:ListItem Value="3">Tarjeta de Identidad</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="height: 22px">
                                        *Número de identificación:
                                    </td>
                                    <td style="height: 22px">
                                        <asp:TextBox ID="txtDocumento" runat="server" Width="172px" MaxLength="50"></asp:TextBox>                                        
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDocumento"
                                            ErrorMessage="Valor no válido" MaximumValue="9999999999" MinimumValue="0" SetFocusOnError="True"
                                            Type="Double"></asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 22px; width: 147px;">
                                        Lugar expedición:
                                    </td>
                                    <td style="height: 22px; width: 248px;">
                                        <asp:TextBox ID="txtExpedicion" runat="server" Width="172px" MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td style="height: 22px">
                                        Sexo:
                                    </td>
                                    <td style="height: 22px">
                                        <asp:DropDownList ID="ddSexo" runat="server" SkinID="ddlRegistroClientes" Width="172px">
                                            <asp:ListItem Value="0">(Seleccionar)</asp:ListItem>
                                            <asp:ListItem Value="1">M</asp:ListItem>
                                            <asp:ListItem Value="2">F</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 22px; width: 147px;">
                                        Fecha Nacimiento:
                                    </td>
                                    <td style="height: 22px; width: 248px;">
                                        <asp:TextBox ID="dtpNacimiento" runat="server" Width="172px"></asp:TextBox>
                                        <asp:HiddenField ID="HdtpNacimiento" runat="server" />
                                    </td>
                                    <td style="height: 22px">
                                        Lugar Nacimiento:
                                    </td>
                                    <td style="height: 22px">
                                        <asp:TextBox ID="txtNacimiento" runat="server" Width="172px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 23px; width: 147px;">
                                        Grupo Sanguíneo RH:
                                    </td>
                                    <td style="height: 23px; width: 248px;">
                                        <asp:TextBox ID="txtGrupoSanguineo" runat="server" Width="172px" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td style="height: 23px">
                                        Ciudad Residencia:
                                    </td>
                                    <td style="height: 23px">
                                        <asp:TextBox ID="txtCiudadResidencia" runat="server" Width="172px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 23px; width: 147px;">
                                        Dirección:
                                    </td>
                                    <td style="height: 23px; width: 248px;">
                                        <asp:TextBox ID="txtDireccion" runat="server" MaxLength="100" Width="172px"></asp:TextBox>
                                    </td>
                                    <td style="height: 22px">
                                        Talla Camiseta:
                                    </td>
                                    <td style="height: 22px">
                                        <asp:DropDownList ID="ddTallaCamiseta" runat="server" SkinID="ddlRegistroClientes"
                                            Width="172px">
                                            <asp:ListItem Value="0">(Seleccionar)</asp:ListItem>
                                            <asp:ListItem Value="1">S</asp:ListItem>
                                            <asp:ListItem Value="2">M</asp:ListItem>
                                            <asp:ListItem Value="3">L</asp:ListItem>
                                            <asp:ListItem Value="4">XL</asp:ListItem>
                                            <asp:ListItem Value="5">XXL</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 23px; width: 147px;">
                                        Teléfono:
                                    </td>
                                    <td style="height: 23px; width: 248px;">
                                        <asp:TextBox ID="txtTelefono" runat="server" Width="172px" MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td style="height: 22px">
                                        Celular:
                                    </td>
                                    <td style="height: 22px">
                                        <asp:TextBox ID="txtCelular" runat="server" MaxLength="50" Width="172px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 23px; width: 147px;">
                                        Email:
                                    </td>
                                    <td style="height: 23px; width: 248px;">
                                        <asp:TextBox ID="txtEmail1" runat="server" Width="172px" MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td style="height: 22px">
                                        Visas:
                                    </td>
                                    <td style="height: 22px">
                                        <asp:TextBox ID="txtVisas" runat="server" Width="172px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 23px; width: 147px;">
                                        Estado Civil:
                                    </td>
                                    <td style="height: 23px; width: 248px;">
                                        <asp:DropDownList ID="ddEstadoCivil" runat="server" SkinID="ddlRegistroClientes"
                                            Width="172px">
                                            <asp:ListItem Value="0">(Seleccionar)</asp:ListItem>
                                            <asp:ListItem Value="1">Soltero</asp:ListItem>
                                            <asp:ListItem Value="2">Casado</asp:ListItem>
                                            <asp:ListItem Value="3">Viudo</asp:ListItem>
                                            <asp:ListItem Value="4">Divorciado</asp:ListItem>
                                            <asp:ListItem Value="5">Unión libre</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="height: 22px">
                                        Nro Hijos:
                                    </td>
                                    <td style="height: 22px">
                                        <asp:DropDownList ID="ddHijos" runat="server" SkinID="ddlRegistroClientes" Width="172px">
                                            <asp:ListItem Value="0">(Seleccionar)</asp:ListItem>
                                            <asp:ListItem Value="1">0</asp:ListItem>
                                            <asp:ListItem Value="2">1</asp:ListItem>
                                            <asp:ListItem Value="3">2</asp:ListItem>
                                            <asp:ListItem Value="4">3</asp:ListItem>
                                            <asp:ListItem Value="5">4</asp:ListItem>
                                            <asp:ListItem Value="6">5</asp:ListItem>
                                            <asp:ListItem Value="7">6</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 23px; width: 147px;">
                                        Nivel Educativo:
                                    </td>
                                    <td style="height: 23px; width: 248px;">
                                        <asp:DropDownList ID="ddNivelEducativo" runat="server" SkinID="ddlRegistroClientes"
                                            Width="172px">
                                            <asp:ListItem Value="0">(Seleccionar)</asp:ListItem>
                                            <asp:ListItem Value="1">Primaria</asp:ListItem>
                                            <asp:ListItem Value="2">Secundaria</asp:ListItem>
                                            <asp:ListItem Value="3">Universidad</asp:ListItem>
                                            <asp:ListItem Value="4">Posgrado</asp:ListItem>
                                            <asp:ListItem Value="5">Magister</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="height: 22px">
                                        Idiomas:
                                    </td>
                                    <td style="height: 22px">
                                        <asp:TextBox ID="txtSegundaLengua" runat="server" Width="172px" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <div id="accordionFun">
                <h3>
                    Datos Colegio</h3>
                <div>
                    <p>
                        <asp:CheckBox ID="chkFuncionario" runat="server" AutoPostBack="True" Text="Ingresar Datos Colegio?"
                            OnCheckedChanged="chkFuncionario_CheckedChanged" />
                        <asp:Panel ID="PanelFuncioanrio" runat="server" Visible="false">
                            <table>
                                <tr>
                                    <td style="height: 23px; text-align: left; width: 156px;">
                                        *Departamento :
                                    </td>
                                    <td style="height: 23px; width: 223px;">
                                        <asp:DropDownList ID="ddDepartamento" runat="server" AutoPostBack="True" DataTextField="Descripcion"
                                            DataValueField="idDepartamento" OnDataBound="ddDepartamento_DataBound" OnSelectedIndexChanged="ddDepartamento_SelectedIndexChanged"
                                            ToolTip="Seleccione un departamento" Width="172px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="height: 22px; text-align: left;">
                                        &nbsp;
                                    </td>
                                    <td style="height: 22px; text-align: left;">
                                        *Municipio:
                                    </td>
                                    <td style="height: 22px">
                                        <asp:DropDownList ID="ddMunicipio" runat="server" Enabled="False" ToolTip="Seleccione un municipio"
                                            Width="172px" OnDataBound="ddMunicipio_DataBound" AutoPostBack="True" OnSelectedIndexChanged="ddMunicipio_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="height: 22px; text-align: left;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 23px; width: 156px;">
                                        *Zona:
                                    </td>
                                    <td style="height: 23px; width: 223px;">
                                        <asp:DropDownList ID="DropDownList2" runat="server" 
                                            SkinID="ddlRegistroClientes" Width="172px" Height="16px">
                                            <asp:ListItem Value="0">(Seleccionar)</asp:ListItem>
                                            <asp:ListItem Value="1">NORTE</asp:ListItem>
                                            <asp:ListItem Value="2">SUR</asp:ListItem>                                            
                                            <asp:ListItem Value="2">CENTRO</asp:ListItem>                                            
                                            <asp:ListItem Value="2">ORIENTE</asp:ListItem>                                            
                                            <asp:ListItem Value="2">OCCIDENTE</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="height: 22px">
                                        *Colegio:
                                    </td>
                                    <td style="height: 22px">
                                        <asp:DropDownList ID="DropDownList1" runat="server" SkinID="ddlRegistroClientes" Width="172px">
                                            <asp:ListItem Value="0">(Seleccionar)</asp:ListItem>
                                            <asp:ListItem Value="1">INEM</asp:ListItem>
                                            <asp:ListItem Value="2">TERESIANO</asp:ListItem>                                            
                                            <asp:ListItem Value="2">CALASANZ</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 23px; width: 156px;">
                                        Grupo:
                                    </td>
                                    <td style="height: 23px; width: 223px;">
                                        <asp:DropDownList ID="DropDownList3" runat="server" SkinID="ddlRegistroClientes" Width="172px">
                                            <asp:ListItem Value="0">(Seleccionar)</asp:ListItem>
                                            <asp:ListItem Value="1">11-1-2014</asp:ListItem>
                                            <asp:ListItem Value="2">11-2-2014</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="height: 22px">
                                        Jornada:
                                    </td>
                                    <td style="height: 22px">
                                        <asp:DropDownList ID="DropDownList4" runat="server" SkinID="ddlRegistroClientes" Width="172px">
                                            <asp:ListItem Value="0">(Seleccionar)</asp:ListItem>
                                            <asp:ListItem Value="1">MAÑANA</asp:ListItem>
                                            <asp:ListItem Value="2">TARDE</asp:ListItem>
                                            <asp:ListItem Value="2">NOCHE</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>                                
                                <tr>
                                    <td style="height: 23px; width: 156px;">
                                        Observaciones:
                                    </td>
                                    <td style="height: 23px; width: 223px;">
                                        <asp:TextBox ID="txtObservaciones" runat="server" MaxLength="200" Width="172px"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="height: 22px">
                                        &nbsp;
                                    </td>
                                    <td style="height: 22px">
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                </div>
            </div>
            <table width="100%">
                <tr>
                    <td class="tdVentanaCenCen">
                        <asp:Button ID="btnGuardar" runat="server" SkinID="botonGuardar" OnClick="btnGuardar_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </contenttemplate>
    <%--</asp:UpdatePanel>--%>
    <%--<asp:UpdateProgress ID="RegistrarClienteUpdateProgress" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="GestionarEventoUpdatePanel">
        <ProgressTemplate>
            <div id="ovrCF" class="overlay">
                <div class="overlayContent">
                    <asp:Image runat="server" ID="imgProg" SkinID="Progreso" />
                    <h3>
                        Cargando...</h3>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
</asp:Content>
