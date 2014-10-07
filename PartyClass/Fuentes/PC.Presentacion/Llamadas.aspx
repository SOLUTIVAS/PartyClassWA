<%@ Page Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" Title="Registrar Llamada" 
CodeFile="Llamadas.aspx.cs" Inherits="PC.Llamadas" %>
<%@ Register Assembly="Telerik.OpenAccess.Web.40" Namespace="Telerik.OpenAccess.Web"
	TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	<meta name="title" content="Llamadas | Party Class Web" />
	<meta name="description" content="Página donde se gestionarán las llamadas con sus respectivos protocolos." />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1"
		UpdateInitiatorPanelsOnly="true" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
		<AjaxSettings>
			<telerik:AjaxSetting AjaxControlID="RadComboBoxTopAthletes">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="RadListBoxSports" />
					<telerik:AjaxUpdatedControl ControlID="RadListBoxAthletes" />
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="RadListBoxSports">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="RadListBoxAthletes" />
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="RadButtonUpdate">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="RadHtmlChartAthletes" />
				</UpdatedControls>
			</telerik:AjaxSetting>
			<telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
				<UpdatedControls>
					<telerik:AjaxUpdatedControl ControlID="RadListViewAthleteMedalsInfo" />
				</UpdatedControls>
			</telerik:AjaxSetting>
		</AjaxSettings>
	</telerik:RadAjaxManager>
	<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
	</telerik:RadAjaxLoadingPanel>
	<h2>Gestión de Llamadas</h2>
	<p class="description">En esta página se gestionarán las llamadas. Se debe seleccionar un protocolo antes de realizar la gestión de la llamada, posteriormente se puede iniciar.</p>
	<div class="box topAthletes">
		<h3 class="blueTitle">Protocolos</h3>
		<div class="listBoxWrapper">
			<h4>Nombre</h4>
			<telerik:RadListBox ID="RadListBoxProtocolos" runat="server" Height="410px" style="float: left; margin-right: 10px; top: -1px; left: 0px;"
				Skin="Office2010Silver" AutoPostBack="True" DataKeyField="idProtocolo" DataValueField="idProtocolo"
				DataTextField="Descripcion"                  
                OnDataBound="RadListBoxProtocolos_DataBound" DataSortField="idProtocolo" 
                DataSourceID="SqlDataSource1" TransferToID="RadListBoxPasos" 
                onselectedindexchanged="RadListBoxProtocolos_SelectedIndexChanged">
			</telerik:RadListBox>
		    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConStringProd %>" 
                SelectCommand="SELECT * FROM pc.protocolo"></asp:SqlDataSource>
		</div>
		<div class="listBoxWrapper">
			<h4>Pasos</h4>
			<telerik:RadListBox ID="RadListBoxPasos" runat="server" Height="410px"
				Skin="Office2010Silver" DataKeyField="idPaso" DataValueField="idPaso"
				DataTextField="Descripcion" CheckBoxes="True" OnClientItemChecked="onItemChecked" 
                OnClientLoad="OnClientLoad" DataSortField="idPaso" 
                DataSourceID="SqlDataSource2" TransferToID="RadListBoxProtocolos">
			</telerik:RadListBox>
		    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConStringProd %>" 
                
                SelectCommand="SELECT * FROM PC.[PasosProtocolo] ">
            </asp:SqlDataSource>
		</div>
	</div>

	

	<div class="box" style="width: 810px; height: 490px; float: left;">
		<h3 class="orangeTitle">Datos de la Llamada</h3>
                     <table width="100%">
                <tr>
                    <td class="tdVentanaCenCen">
                        <asp:Panel ID="Panel2" runat="server">
                            <table class="tblFormulario">
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
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 22px; width: 147px;">
                                        Grupo:
                                    </td>
                                    <td style="height: 22px; width: 248px;">
                                        <asp:DropDownList ID="ddSexo" runat="server" SkinID="ddlRegistroClientes" Width="172px">
                                            <asp:ListItem Value="0">(Seleccionar)</asp:ListItem>
                                            <asp:ListItem Value="1">11-1-2014</asp:ListItem>
                                            <asp:ListItem Value="2">11-2-2014</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="height: 22px">
                                        &nbsp;</td>
                                    <td style="height: 22px">
                                        
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table width="100%">
                    <tr>
                        <td class="tdVentanaCenCen">                            
                            Plan:<br />
                            <asp:DropDownList ID="ddEvento" runat="server" DataTextField="Descripcion"
                                DataValueField="idEvento" Width="500px" />
                            <br />
                            <br />
                            Teléfonos:<br />
                            <asp:CheckBoxList ID="chklstTelefonosCliente" runat="server">
                            </asp:CheckBoxList>
                            <br />
                            Observaciones:<br />
                            <asp:TextBox ID="txtObservaciones" runat="server" MaxLength="2000" name="txtObservaciones"
                                TextMode="MultiLine" type="text" Width="500px" Height="76px" 
                                Font-Size="Small" >Observaciones de la llamada:</asp:TextBox>
                            <br />
                            <br />
                            Volver a llamar?<br />
                            <asp:CheckBox ID="chkVolverALlamar" runat="server" 
                                ToolTip="El cliente requiere que lo vuelvan a llamar?" AutoPostBack="True" 
                                oncheckedchanged="chkVolverALlamar_CheckedChanged" />
                            <br />
                            <br />
                            Fecha volver a llamar:<br />
                            <telerik:RadDateTimePicker ID="radDtpFechaHoraVolverLlamar" Runat="server" 
                                Enabled="False" Width="152px">
                                    </telerik:RadDateTimePicker>
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>

		
	</div>	

	<br style="clear: both;" />
	
    </asp:Content>

