<%@ Page Language="C#" MasterPageFile="~/Principal.master" Title="Asignar Cliente a Plan" 
AutoEventWireup="true" CodeFile="GestionarPlan.aspx.cs" Inherits="GestionarPlan" %>
<%@ Register Src="~/Controles/PanelMensajes.ascx" TagName="PanelMensajes" TagPrefix="uc1" %>
<%@ Register TagPrefix="UC" TagName="MensajeSistema" Src="~/Controles/MensajeSistema.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Src="~/Controles/FiltroGeneral.ascx" TagName="FiltroGeneral" TagPrefix="ucFiltro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="GestionarEventoUpdatePanel" RenderMode="Inline" runat="server"
        UpdateMode="Conditional">
        <ContentTemplate>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
            </telerik:RadWindowManager>
            <table width="100%">
                <tr>
                    <td class="tdVentanaCenCen">
                        <p class="tdTituloFormularioEtiqueta">
                            Plan:
                            <asp:DropDownList ID="ddEvento" runat="server" Width="583px" DataTextField="Descripcion"
                                DataValueField="idEvento" OnDataBound="ddEvento_DataBound" />
                        </p>
                    </td>
                </tr>
            </table>
            <br />
            <div id="accordionReg">
                <h3>
                    Consultar Detalle Plan</h3>
                <div>
                    <ucFiltro:FiltroGeneral runat="server" ID="ucFiltroGeneral" Visible="true" />
                    <table class="tblFormulario" id="Table1">
                        <caption>
                            <p style="text-align: left">
                                Otros Filtros&nbsp; :</p>
                            <tr>
                                <td style="height: 23px; width: 123px;">
                                    Hotel:
                                </td>
                                <td style="height: 23px; width: 187px;">
                                    <asp:DropDownList ID="ddHotel" runat="server" DataSourceID="dsHotel" DataTextField="Nombre"
                                        DataValueField="idHotel" OnDataBound="ddHotel_DataBound" Width="152px" />
                                </td>
                                <td style="width: 193px">
                                    &nbsp;
                                </td>
                                <td style="height: 22px; width: 148px;">
                                    Usuario:
                                </td>
                                <td style="height: 22px; width: 297px;">
                                    <asp:DropDownList ID="ddUsuario" runat="server" DataTextField="UserName" DataValueField="idUsuario"
                                        OnDataBound="ddUsuario_DataBound" ToolTip="Usuario que realizó la llamada" Width="172px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </caption>
                    </table>
                    <table width="100%">
                        <tr>
                            <td class="tdVentanaCenCen">
                                <uc:mensajesistema runat="server" ID="ucMensajes" />
                            </td>
                        </tr>
                    </table>
                    <table class="tblFormulario" id="Table2">
                        <tr>
                            <td style="height: 22px; width: 343px;">
                                <asp:Button ID="btnConsultarClientesRegistrados" runat="server" SkinID="botonConsultar"
                                    OnClick="btnConsultarClientesRegistrados_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="PanelClientesRegistrados" runat="server" Width="100%" Visible="false">
                        <asp:Label ID="lblTotales" runat="server"></asp:Label>                        
                        <telerik:RadGrid ID="radGrdClientesRegistrados" runat="server" AllowSorting="True"
                            CellSpacing="0" GridLines="None" ShowStatusBar="True" OnDeleteCommand="radGrdClientesRegistrados_DeleteCommand"
                            OnSortCommand="radGrdClientesRegistrados_SortCommand">
                            <MasterTableView AutoGenerateColumns="False" EnableColumnsViewState="False" DataKeyNames="Documento,Nombres,Apellidos,idDetalleEvento">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="NombreUsuario" FilterControlAltText="Filter NombreUsuario column"
                                        HeaderText="Nombre Usuario" UniqueName="NombreUsuario">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Departamento" FilterControlAltText="Filter Departamento column"
                                        HeaderText="Departamento" UniqueName="Departamento">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Municipio" FilterControlAltText="Filter Municipio column"
                                        HeaderText="Municipio" UniqueName="Municipio">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Cargo" FilterControlAltText="Filter Cargo column"
                                        HeaderText="Cargo" UniqueName="Cargo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Organizacion" FilterControlAltText="Filter Organizacion column"
                                        HeaderText="Organización" UniqueName="Organizacion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Documento" FilterControlAltText="Filter Documento column"
                                        HeaderText="Documento" UniqueName="Documento">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Nombres" FilterControlAltText="Filter Nombres column"
                                        HeaderText="Nombres" UniqueName="Nombres">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Apellidos" FilterControlAltText="Filter Apellidos column"
                                        HeaderText="Apellidos" UniqueName="Apellidos">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaRegistroEvento" FilterControlAltText="Filter FechaRegistroEvento column"
                                        HeaderText="Fecha Registro Evento" UniqueName="FechaRegistroEvento">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NombreHotel" FilterControlAltText="Filter NombreHotel column"
                                        HeaderText="Hotel" UniqueName="NombreHotel">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NroHab" FilterControlAltText="Filter NroHab column"
                                        HeaderText="Habitación" UniqueName="NroHab">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Acommodacion" FilterControlAltText="Filter Acommodacion column"
                                        HeaderText="Acommodación" UniqueName="Acommodacion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaCheckIn_Hotel" FilterControlAltText="Filter FechaCheckIn_Hotel column"
                                        HeaderText="Fecha CheckIn" UniqueName="FechaCheckIn_Hotel">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaCheckOut_Hotel" FilterControlAltText="Filter FechaCheckOut_Hotel column"
                                        HeaderText="Fecha CheckOut" UniqueName="FechaCheckOut_Hotel">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ObservacionesHotel" FilterControlAltText="Filter ObservacionesHotel column"
                                        HeaderText="Observaciones Hotel" UniqueName="ObservacionesHotel">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Aerolinea" FilterControlAltText="Filter Aerolinea column"
                                        HeaderText="Aerolinea" UniqueName="Aerolinea">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CiudadOrigen" FilterControlAltText="Filter CiudadOrigen column"
                                        HeaderText="Ciudad Origen" UniqueName="CiudadOrigen">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CiudadDestino" FilterControlAltText="Filter CiudadDestino column"
                                        HeaderText="Ciudad Destino" UniqueName="CiudadDestino">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaSalidaVuelo" FilterControlAltText="Filter FechaSalidaVuelo column"
                                        HeaderText="Fecha Salida Vuelo" UniqueName="FechaSalidaVuelo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaRegresoVuelo" FilterControlAltText="Filter FechaRegresoVuelo column"
                                        HeaderText="Fecha Regreso Vuelo" UniqueName="FechaRegresoVuelo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ObservacionesPasajes" FilterControlAltText="Filter ObservacionesPasajes column"
                                        HeaderText="Observaciones Pasajes" UniqueName="ObservacionesPasajes">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn ConfirmText="Se eliminará al cliente del evento con su respectiva asignación de pasajes y hotel. ¿Está seguro?" ConfirmDialogType="RadWindow"
                                        ConfirmTitle="Eliminar" ButtonType="ImageButton" CommandName="Delete" Text="Eliminar Registro"
                                        ImageUrl = "App_Themes/TC_Theme/imgGaspar/cancel16x16.png" />
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </asp:Panel>
                </div>
            </div>
            <br />
            <div id="accordionNoReg">
                <h3>
                    Consultar Disponibilidad Hoteles por Evento</h3>
                <div>
                    <p>
                        <asp:Button runat="server" ID="btnConsultarDisponibilidad" SkinID="botonConsultar"
                            OnClick="btnConsultarDisponibilidad_Click" />
                    </p>
                    <asp:Panel ID="PanelDisponibilidadHotel" runat="server" Width="100%" Visible="false">                        
                        <telerik:RadGrid ID="radGrdDisponibilidad" runat="server" AllowSorting="True"
                            CellSpacing="0" GridLines="None" ShowStatusBar="True" 
                            onsortcommand="radGrdDisponibilidad_SortCommand">
                            <MasterTableView AutoGenerateColumns="False" EnableColumnsViewState="False">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="NombreHotel" FilterControlAltText="Filter NombreHotel column"
                                        HeaderText="Hotel" UniqueName="NombreHotel">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaInicio" FilterControlAltText="Filter FechaInicio column"
                                        HeaderText="Fecha Inicio" UniqueName="FechaInicio">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FechaFin" FilterControlAltText="Filter MuFechaFinnicipio column"
                                        HeaderText="Fecha Fin" UniqueName="FechaFin">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NroHabitacion" FilterControlAltText="Filter NroHabitacion column"
                                        HeaderText="Habitación" UniqueName="NroHabitacion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Acomodacion" FilterControlAltText="Filter Acomodacion column"
                                        HeaderText="Acomodación" UniqueName="Acomodacion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CamasPorHabitacion" FilterControlAltText="Filter CamasPorHabitacion column"
                                        HeaderText="Camas Por Habitación" UniqueName="CamasPorHabitacion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CamasDisponibles" FilterControlAltText="Filter CamasDisponibles column"
                                        HeaderText="Camas Disponibles" UniqueName="CamasDisponibles">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CamasOcupadas" FilterControlAltText="Filter CamasOcupadas column"
                                        HeaderText="Camas Ocupadas" UniqueName="CamasOcupadas">
                                    </telerik:GridBoundColumn>                                    
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="GestionarEventoUpdateProgress" runat="server" DisplayAfter="0"
        AssociatedUpdatePanelID="GestionarEventoUpdatePanel">
        <ProgressTemplate>
            <div id="ovrCF" class="overlay">
                <div class="overlayContent">
                    <asp:Image runat="server" ID="imgProg" SkinID="Progreso" />
                    <h3>
                        Cargando...</h3>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:SqlDataSource ID="dsHotel" runat="server" ConnectionString="<%$ ConnectionStrings:ConStringProd %>"
        SelectCommand="SELECT [idHotel], [Nombre] FROM partyclass.tc.[Hotel]"></asp:SqlDataSource>
</asp:Content>
