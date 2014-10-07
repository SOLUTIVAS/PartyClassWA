namespace PC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Comun.EntidadesNegocio;

    public partial class Llamadas : System.Web.UI.Page
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
        protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {

        }
        protected void RadListBoxSports_DataBound(object sender, EventArgs e)
        {

        }
        protected void RadListBoxSports_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void RadListBoxProtocolos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void RadListBoxProtocolos_DataBound(object sender, EventArgs e)
        {

        }
        protected void ddDepartamento_DataBound(object sender, EventArgs e)
        {
            ddMunicipio.Items.Insert(0, "(Seleccione)");
        }
        protected void ddMunicipio_DataBound(object sender, EventArgs e)
        {
            if (ddMunicipio.Items.Count.Equals(0))
            {
                ddMunicipio.Items.Insert(0, "(Seleccione)");
            }
        }
        protected void ddMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            }
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
        protected void chkVolverALlamar_CheckedChanged(object sender, EventArgs e)
        {
            radDtpFechaHoraVolverLlamar.Enabled = chkVolverALlamar.Checked;
        }
}
}