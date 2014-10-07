namespace TC
{
    using System;
    using System.Web.UI;
    using Comun.EntidadesNegocio;
    using Comun.Session;
    using System.Globalization;
    using System.Collections.Generic;
    using Mensajes;
    using Comun.TO;

    public partial class RegistroClientes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Datos.Broker oTCDatos = new Datos.Broker();
            if (ddDepartamento.Items.Count == 0)
            {
                ddDepartamento.DataSource = oTCDatos.obtenerDepartamento(0);
                ddDepartamento.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CultureInfo cu = new CultureInfo("en-US");
            ClienteTO oCliente = new ClienteTO();
            Funcionario oFuncionario = new Funcionario();
            Telefono oTelefono;
            List<Telefono> lstTelefono = new List<Telefono>();
            List<string> lstResultados = new List<string>();

            oCliente.Nombres = txtNombre.Text;
            oCliente.Apellidos = txtApellidos.Text;
            oCliente.Documento = txtDocumento.Text == string.Empty ? 0 : Convert.ToDouble(txtDocumento.Text);
            oCliente.LugarExpedicion = txtExpedicion.Text;
            oCliente.Sexo = Convert.ToChar(ddSexo.SelectedValue);
            oCliente.FechaNacimiento = HdtpNacimiento.Value.ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(HdtpNacimiento.Value.ToString(), cu);
            oCliente.CiudadNacimiento = txtNacimiento.Text;
            oCliente.TipoSangre = txtGrupoSanguineo.Text;
            oCliente.CiudadResidencia = txtCiudadResidencia.Text;
            oCliente.Direccion = txtDireccion.Text;
            oCliente.TallaCamiseta = ddTallaCamiseta.Text;
            oCliente.Email = txtEmail1.Text;
            oCliente.Visas = txtVisas.Text;
            oCliente.EstadoCivil = ddEstadoCivil.Text;
            oCliente.Hijos = Convert.ToInt32(ddHijos.SelectedValue);
            oCliente.Estudios = ddNivelEducativo.Text;
            oCliente.Idiomas = txtSegundaLengua.Text;
            oCliente.idUsuarioRegistroMod = (double)Contexto.idUsuario;

            oTelefono = new Telefono();
            oTelefono.Tipo = "Fijo";
            oTelefono.NumeroTelefonico = txtTelefono.Text;
            lstTelefono.Add(oTelefono);
            oTelefono = new Telefono();
            oTelefono.Tipo = "Celular";
            oTelefono.NumeroTelefonico = txtCelular.Text;
            lstTelefono.Add(oTelefono);



            Datos.Broker oTC = new Datos.Broker();

            oTC.insertarModificarCliente(oCliente, lstTelefono, oFuncionario, ref lstResultados);
            if (lstResultados[1] == "1")
            {
                MostrarMensaje(TipoMensaje.Success, lstResultados[2]);
            }
            else
            {
                MostrarMensaje(TipoMensaje.Error, lstResultados[2]);
            }
        }

        private void MostrarMensaje(int codigoMsg)
        {
            var mensajes = (MensajeSistema)ucMensajes;
            var mensaje = new Mensaje(codigoMsg);
            mensajes.MostrarMensajes(mensaje);
        }

        private void MostrarMensaje(TipoMensaje tipo, string msg)
        {
            var mensajes = (MensajeSistema)ucMensajes;
            mensajes.MostrarMensajes(msg, tipo);
        }

        private void LimpiarMensajes()
        {
            var mensajes = (MensajeSistema)ucMensajes;
            mensajes.LimpiarOcultarPaneles();
        }
        protected void ddDepartamento_DataBound(object sender, EventArgs e)
        {
            ddDepartamento.Items.Insert(0, "(Seleccione)");
        }
        protected void ddMunicipio_DataBound(object sender, EventArgs e)
        {
            ddMunicipio.Items.Insert(0, "(Seleccione)");
        }
        protected void ddDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddDepartamento.SelectedIndex == 0)
            {
                ddMunicipio.DataSource = null;
                ddMunicipio.DataBind();
            }
            else
            {
                ddMunicipio.Enabled = true;
                ConsultarMunicipios(Convert.ToInt32(ddDepartamento.SelectedValue));
                ConsultarOrganizacion(0, Convert.ToInt32(ddDepartamento.SelectedValue));
            }
        }

        protected void ddMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarOrganizacion(Convert.ToInt32(ddMunicipio.SelectedValue), Convert.ToInt32(ddDepartamento.SelectedValue));
        }

        private void ConsultarOrganizacion(int idMunicipio, int idDepartamento)
        {
            Organizacion oOrganizacion = new Organizacion();
            oOrganizacion.IdMunicipio = idMunicipio;
            oOrganizacion.IdDepartamento = idDepartamento;
            Datos.Broker oTC = new Datos.Broker();
        }


        private void ConsultarMunicipios(int idDepartamento)
        {
            Municipio objMunicipio = new Municipio();
            Datos.Broker oFTC = new Datos.Broker();
            List<Municipio> lstMunicipio = oFTC.obtenerMunicipiosDepto(idDepartamento);
            ddMunicipio.DataSource = null;
            ddMunicipio.DataBind();
            ddMunicipio.DataSource = lstMunicipio;
            ddMunicipio.DataValueField = "idMunicipio";
            ddMunicipio.DataTextField = "Nombre";
            ddMunicipio.DataBind();
        }
        protected void chkFuncionario_CheckedChanged(object sender, EventArgs e)
        {
            PanelFuncioanrio.Visible = chkFuncionario.Checked;
        }
    }
}
