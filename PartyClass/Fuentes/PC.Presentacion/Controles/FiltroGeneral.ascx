<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FiltroGeneral.ascx.cs"
    Inherits="Controles_FiltroGeneral" %>
<asp:Panel ID="pnlError" runat="server" Visible="true">
    <table class="tblFormulario" width="100%">
        
        <tr>
            <td style="height: 23px; width: 200px; text-align: left;">
                &nbsp; &nbsp;
            </td>
            <td style="height: 23px; width: 200px; text-align: left;">
                &nbsp;
            </td>
            <td style="height: 22px; width: 200px; text-align: left;">
                &nbsp;
            </td>
            <td style="height: 22px; width: 200px; text-align: left;">
                &nbsp;
            </td>
            <td style="height: 22px; width: 200px; text-align: left;">
                &nbsp;
            </td>
            <td style="height: 22px; width: 200px; text-align: left;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 23px; width: 200px; text-align: left;">
                Documento:
            </td>
            <td style="height: 23px; width: 223px;">
                <asp:TextBox ID="txtDocumentoCon" runat="server" Height="18px" MaxLength="50" ToolTip="Cédula del cliente que se desea consultar"
                    Width="172px" Style="text-align: left"></asp:TextBox>
            </td>
            <td style="height: 23px; width: 50px; text-align: left;">
                &nbsp;
            </td>
            <td style="height: 23px; text-align: left;">
                Cargo:
            </td>
            <td style="height: 23px">
                <asp:DropDownList ID="ddCargoCon" runat="server" Width="172px" AutoPostBack="True"
                    ToolTip="Ingrese el cargo del cliente" OnDataBound="ddCargoCon_DataBound" DataTextField="Nombre"
                    DataValueField="Id">
                </asp:DropDownList>
            </td>
            <td style="height: 23px; text-align: left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 23px; width: 200px; text-align: left;">
                Nombres:
            </td>
            <td style="height: 23px; width: 223px;">
                <asp:TextBox ID="txtNombresCon" runat="server" Height="18px" MaxLength="50" ToolTip="Nombres del cliente que se desea consultar"
                    Width="172px"></asp:TextBox>
            </td>
            <td>
            </td>
            <td style="height: 22px; text-align: left;">
                Apellidos:
            </td>
            <td style="height: 22px">
                <asp:TextBox ID="txtApellidosCon" runat="server" Height="18px" MaxLength="50" ToolTip="Apellidos del cliente que se desea consultar"
                    Width="172px"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 23px; text-align: left;">
                Departamento:
            </td>
            <td style="height: 23px; width: 223px;">
                <asp:DropDownList ID="ddDepartamentoCon" runat="server" AutoPostBack="True" DataTextField="Descripcion"
                    DataValueField="idDepartamento" OnDataBound="ddDepartamentoCon_DataBound" OnSelectedIndexChanged="ddDepartamentoCon_SelectedIndexChanged"
                    ToolTip="Seleccione un departamento" Width="172px">
                </asp:DropDownList>
            </td>
            <td style="height: 22px; text-align: left;">
                &nbsp;
            </td>
            <td style="height: 22px; text-align: left;">
                Municipio:</td>
            <td style="height: 22px">
                <asp:DropDownList ID="ddMunicipioCon" runat="server" Enabled="False" ToolTip="Seleccione un municipio"
                    Width="172px" OnDataBound="ddMunicipioCon_DataBound" DataValueField="idMunicipio"
                    AutoPostBack="True" DataTextField="Nombre" OnSelectedIndexChanged="ddMunicipioCon_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="height: 22px; text-align: left;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 23px; width: 200px;">
                Zona:
            </td>
            
            <td>
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
                &nbsp;
            </td>
            <td style="height: 22px">
                Colegio</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" SkinID="ddlRegistroClientes" Width="172px">
                                            <asp:ListItem Value="0">(Seleccionar)</asp:ListItem>
                                            <asp:ListItem Value="1">INEM</asp:ListItem>
                                            <asp:ListItem Value="2">TERESIANO</asp:ListItem>                                            
                                            <asp:ListItem Value="2">CALASANZ</asp:ListItem>
                                        </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 23px; width: 200px; text-align: left;">
                Grupo:
            </td>
            <td style="height: 23px; width: 223px;">
                <asp:DropDownList ID="ddSexo" runat="server" SkinID="ddlRegistroClientes" Width="172px">
                                            <asp:ListItem Value="0">(Seleccionar)</asp:ListItem>
                                            <asp:ListItem Value="1">11-1-2014</asp:ListItem>
                                            <asp:ListItem Value="2">11-2-2014</asp:ListItem>
                                        </asp:DropDownList>
            </td>
            <td>
            </td>
            <td style="height: 22px; text-align: left;">
                &nbsp;</td>
            <td style="height: 22px">
                <asp:DropDownList ID="ddOrganizacion" runat="server" AutoPostBack="True" DataTextField="Nombre"
                    DataValueField="Id" OnDataBound="ddOrganizacion_DataBound" ToolTip="Seleccione la organización a la que pertenece el cliente."
                    Width="172px" Visible="False">
                </asp:DropDownList></td>
            <td>
            </td>
        </tr>
    </table>
</asp:Panel>
