namespace TC
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web.UI;
    using App_Code;
    using Comun.EntidadesNegocio;

    public partial class PublicRegistro : Page
    {
        #region Propiedades

        #endregion

        #region Eventos de la Pagina.

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Datos.Broker oTCDatos = new Datos.Broker();
                if (ddDepartamento.Items.Count == 0)
                {
                    ddDepartamento.DataSource = oTCDatos.obtenerDepartamento(0);
                    ddDepartamento.DataBind();
                }
                if (ddCargo.Items.Count == 0)
                {
                    ddCargo.DataSource = oTCDatos.obtenerCargo(0);
                    ddCargo.DataBind();
                }
                if (ddEvento.Items.Count == 0)
                {
                    List<Evento> lstEvento = oTCDatos.ObtenerEvento(0, true);
                    ddEvento.DataSource = lstEvento;
                    ddEvento.DataBind();
                }
            }
            catch (Exception ex)
            {
                this.ManejarExcepcionPublico(ex);
            }
        }

        protected void ddDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                }
            }
            catch (Exception ex)
            {
                this.ManejarExcepcionPublico(ex);
            }
        }

        protected void chkRequiereHotel_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtpLlegadaHotel.Enabled = chkRequiereHotel.Checked;
                dtpSalidaHotel.Enabled = chkRequiereHotel.Checked;
                ddAcomodacion.Enabled = chkRequiereHotel.Checked;
                if (!chkRequiereHotel.Checked)
                {
                    HdtpLlegadaHotel.Value = string.Empty;
                    HdtpSalidaHotel.Value = string.Empty;
                    ddAcomodacion.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                this.ManejarExcepcionPublico(ex);
            }
        }

        protected void chkRequierePasajes_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtpSalidaVuelo.Enabled = chkRequierePasajes.Checked;
                dtpRegresoVuelo.Enabled = chkRequierePasajes.Checked;
                txtLugarSalidaVuelo.Enabled = chkRequierePasajes.Checked;
                if (!chkRequiereHotel.Checked)
                {
                    HdtpSalidaVuelo.Value = string.Empty;
                    HdtpRegresoVuelo.Value = string.Empty;
                    txtLugarSalidaVuelo.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                this.ManejarExcepcionPublico(ex);
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    CultureInfo cu = new CultureInfo("en-US");

                    Registro oRegistro = new Registro();
                    oRegistro.Nombres = txtNombres.Text;
                    oRegistro.Apellidos = txtApellidos.Text;
                    oRegistro.Celular = txtCelular.Text;
                    oRegistro.Documento = Convert.ToDouble(txtDocumento.Text);
                    oRegistro.Email = txtEmail.Text;
                    oRegistro.RequiereHotel = chkRequiereHotel.Checked;
                    oRegistro.FechaCkeckInHotel = HdtpLlegadaHotel.Value.ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(HdtpLlegadaHotel.Value.ToString(), cu);
                    oRegistro.FechaCheckOutHotel = HdtpSalidaHotel.Value.ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(HdtpSalidaHotel.Value.ToString(), cu);
                    oRegistro.RequierePasajes = chkRequierePasajes.Checked;
                    oRegistro.FechaSalidaPasajes = HdtpSalidaVuelo.Value.ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(HdtpSalidaVuelo.Value.ToString(), cu);
                    oRegistro.FechaRegresoPasajes = HdtpRegresoVuelo.Value.ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(HdtpRegresoVuelo.Value.ToString(), cu);
                    oRegistro.idMunicipio = Convert.ToInt32(ddMunicipio.SelectedValue);
                    oRegistro.TipoAcomodacion = Convert.ToString(ddAcomodacion.SelectedItem);
                    oRegistro.LugarSalida = txtLugarSalidaVuelo.Text;
                    oRegistro.idEvento = Convert.ToDouble(ddEvento.SelectedValue);
                    oRegistro.Observaciones = txtOtro.Text;

                    Datos.Broker oFTC = new Datos.Broker();
                    List<string> lstResultado = new List<string>();
                    oFTC.insertarRegistro(oRegistro, ref lstResultado);

                    //1=Operación exitosa
                    if (lstResultado[1] == "1")
                    {
                        lblExito.Visible = true;
                        lblResultado.Visible = false;
                    }
                    else
                    {
                        lblExito.Visible = false;
                        lblResultado.Visible = true;
                        lblResultado.Text = lstResultado[2];
                    }

                    this.LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                this.ManejarExcepcionPublico(ex);
            }
        }

        protected void ddCargo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddCargo.SelectedItem.Text == "Otro")
                {
                    txtOtro.Enabled = true;
                }
                else
                {
                    txtOtro.Enabled = false;
                    txtOtro.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                this.ManejarExcepcionPublico(ex);
            }
        }

        protected void ddCargo_DataBound(object sender, EventArgs e)
        {
            ddCargo.Items.Insert(0, "(Seleccione)");
        }

        protected void ddDepartamento_DataBound(object sender, EventArgs e)
        {
            ddDepartamento.Items.Insert(0, "(Seleccione)");
        }

        protected void ddAcomodacion_DataBound(object sender, EventArgs e)
        {
            ddAcomodacion.Items.Insert(0, "(Seleccione)");
        }

        protected void ddEvento_DataBound(object sender, EventArgs e)
        {
            if (ddEvento.Items.Count > 0)
            {
                ddEvento.Items.Insert(0, "(Seleccione)");
            }
        }

        #endregion

        #region Métodos Privados

        private bool ValidarCampos()
        {
            if (txtDocumento.Text == string.Empty
                   || txtCelular.Text == string.Empty
                   || txtNombres.Text == string.Empty
                   || txtApellidos.Text == string.Empty
                   || txtEmail.Text == string.Empty
                   || txtNombres.Text == string.Empty
                   || ddMunicipio.SelectedItem == null || ddMunicipio.SelectedItem.Text == string.Empty
                   || ddCargo.SelectedIndex == 0)
            {
                lblResultado.Text = "Los campos con * son obligatorios";
                lblResultado.Visible = true;
                lblExito.Visible = false;
                return false;
            }
            else
            {
                if (chkRequiereHotel.Checked)
                {
                    if (HdtpLlegadaHotel.Value.ToString() == string.Empty || HdtpSalidaHotel.Value.ToString() == string.Empty || ddAcomodacion.SelectedIndex == 0)
                    {
                        lblResultado.Text = "Si requiere hotel debe ingresar fecha checkin, fecha checkout y acomodación.";
                        lblResultado.Visible = true;
                        return false;
                    }
                }
                if (chkRequierePasajes.Checked)
                {
                    if (HdtpSalidaVuelo.Value.ToString() == string.Empty || HdtpRegresoVuelo.Value.ToString() == string.Empty || txtLugarSalidaVuelo.Text == string.Empty)
                    {
                        lblResultado.Text = "Si requiere pasajes debe ingresar fecha y lugar de salida y fecha regreso.";
                        lblResultado.Visible = true;
                        return false;
                    }
                }

                lblResultado.Text = "Resultado";
                lblResultado.Visible = false;
            }
            return true;
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

        private void LimpiarCampos()
        {
            txtNombres.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            HdtpNacimiento.Value = string.Empty;
            txtEmail.Text = string.Empty;
            txtOtro.Text = string.Empty;
            chkRequiereHotel.Checked = false;
            chkRequiereHotel_CheckedChanged(new object(), new EventArgs());
            dtpLlegadaHotel.Text = string.Empty;
            dtpSalidaHotel.Text = string.Empty;
            chkRequierePasajes.Checked = false;
            chkRequierePasajes_CheckedChanged(new object(), new EventArgs());
            dtpSalidaVuelo.Text = string.Empty;
            dtpRegresoVuelo.Text = string.Empty;
            ddCargo.SelectedIndex = 0;
            ddDepartamento.SelectedIndex = 0;
            ddMunicipio.DataSource = null;
            ddMunicipio.DataBind();
            txtLugarSalidaVuelo.Text = string.Empty;
            dtpNacimiento.Text = string.Empty;

            //foreach (TextBox texto in Page.Controls.OfType<TextBox>())
            //{
            //    texto.Text = string.Empty;
            //}
            //foreach (Control ctr in this.Controls)
            //{
            //    ctr.GetType();
            //    //switch (ctr.OfType<TextBox>())
            //    //{
            //    //        case 
            //    //    default:
            //    //        break;
            //    //}
            //    //texto.Text = string.Empty;
            //}
            //Control strWebForm = Page.FindControl("form1");


            //foreach (Control strControl in this.Controls)
            //{
            //    if (strControl.GetType().ToString().Equals("System.Web.UI.WebControls.TextBox"))
            //    {
            //        ((TextBox)strControl).Text = string.Empty;
            //    }
            //}
            //foreach (TextBox c in this.Controls.OfType<TextBox>())
            //{
            //    c.Text = string.Empty;
            //}

        }

        #endregion Métodos Privados
    }
}