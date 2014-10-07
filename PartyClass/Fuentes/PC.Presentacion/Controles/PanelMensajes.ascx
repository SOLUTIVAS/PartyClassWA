<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PanelMensajes.ascx.cs" Inherits="PanelMensajes" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../Css/initial.css" rel="stylesheet" type="text/css" />
    <link href="../Css/cssTC.css" rel="stylesheet" type="text/css" />
<body>
    <div id="divMarco">
        <!--div id="divContenido"-->
            <!-- +++++++++++++++++++++++++ VENTANA INGRESO ++++++++++++++++++++++++++ -->
            <table class="tblVentana">
	            <tr>
		            <td class="tdVentanaArrIzq"></td>
		            <td class="tdVentanaArrCen"></td>
		            <td class="tdVentanaArrDer"></td>
	            </tr>
	            <tr>
		            <td class="tdVentanaCenIzq"></td>
		            <td class="tdVentanaCenCen">
			           
                        <asp:Panel ID="panelInformacion" runat="server">
			            <div class="divMensajeUsuario01">
			                <p class="pVentanaTitulo">
			                    <asp:Label ID="lblTituloInformacion" runat="server" Text="Información"></asp:Label>
			                </p>
					        <p>
                                <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
                            </p>
				        </div>
                        </asp:Panel>
                        <asp:Panel ID="panelError" runat="server">
		                    <div class="divMensajeUsuario01Error">
		                        <p class="pVentanaTitulo">
		                            <asp:Label ID="lblTituloError" runat="server" Text="Error" ForeColor="Red"></asp:Label>
		                        </p>
				                <p>
                                    <asp:Label ID="lblMensajeError" runat="server" Text="Label"></asp:Label>
                                </p>
			                </div>
                        </asp:Panel>
		            </td>
		            <td class="tdVentanaCenDer"></td>
	            </tr>
	            <tr>
		            <td class="tdVentanaAbaIzq"></td>
		            <td class="tdVentanaAbaCen"></td>
		            <td class="tdVentanaAbaDer"></td>
	            </tr>
            </table>
        <!--/div-->
    </div>
</body>
