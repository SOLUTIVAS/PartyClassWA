using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using Comun.EntidadesNegocio;
using Comun.Session;
using Comun.TO;
using Mensajes;

public partial class Controles_FiltroGeneral : System.Web.UI.UserControl
{
    #region Declaración de controles públicos

    public TextBox TxtDocumento
    {
        get { return txtDocumentoCon; }
        set { txtDocumentoCon = TxtDocumento; }
    }

    public DropDownList DdCargo
    {
        get { return ddCargoCon; }
        set { ddCargoCon = DdCargo; }
    }

    public TextBox TxtNombres
    {
        get { return txtNombresCon; }
        set { txtNombresCon = TxtNombres; }
    }

    public TextBox TxtApellidos
    {
        get { return txtApellidosCon; }
        set { txtApellidosCon = TxtApellidos; }
    }

    public DropDownList DdDepartamento
    {
        get { return ddDepartamentoCon; }
        set { ddDepartamentoCon = DdDepartamento; }
    }

    public DropDownList DdMunicipio
    {
        get { return ddMunicipioCon; }
        set { ddMunicipioCon = DdMunicipio; }
    }

    public DropDownList DdOrganizacion
    {
        get { return ddOrganizacion; }
        set { ddOrganizacion = DdOrganizacion; }
    }

    #endregion
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Datos.Broker oTCDatos = new Datos.Broker();
            List<Cargo> lstCargo = oTCDatos.obtenerCargo(0);
            List<Departamento> lstDepartamento = oTCDatos.obtenerDepartamento(0);

            if (ddDepartamentoCon.Items.Count == 0)
            {
                ddDepartamentoCon.DataSource = lstDepartamento;
                ddDepartamentoCon.DataBind();
            }

            if (ddCargoCon.Items.Count == 0)
            {
                ddCargoCon.DataSource = lstCargo;
                ddCargoCon.DataBind();
            }
        }
    }

    protected void ddCargoCon_DataBound(object sender, EventArgs e)
    {
        if (ddCargoCon.Items.Count > 0)
        {
            ddCargoCon.Items.Insert(0, "(Seleccione)");
        }
    }

    protected void ddDepartamentoCon_DataBound(object sender, EventArgs e)
    {
        if (ddDepartamentoCon.Items.Count > 0)
        {
            ddDepartamentoCon.Items.Insert(0, "(Seleccione)");
        }
    }

    protected void ddDepartamentoCon_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddDepartamentoCon.SelectedIndex == 0)
        {
            ddMunicipioCon.Items.Clear();
            ddOrganizacion.Items.Clear();
        }
        else
        {
            ddMunicipioCon.Enabled = true;
            Datos.Broker oFTC = new Datos.Broker();
            List<Municipio> lstMunicipio = oFTC.obtenerMunicipiosDepto(Convert.ToInt32(ddDepartamentoCon.SelectedValue));
            ddMunicipioCon.DataSource = lstMunicipio;
            ddMunicipioCon.DataBind();
            ConsultarOrganizacion(0, Convert.ToInt32(ddDepartamentoCon.SelectedValue));
        }
    }

    protected void ddMunicipioCon_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddMunicipioCon.SelectedIndex != 0 || ddDepartamentoCon.SelectedIndex != 0)
        {
            ConsultarOrganizacion(ddMunicipioCon.SelectedIndex == 0 ? 0 : Convert.ToInt32(ddMunicipioCon.SelectedValue), ddDepartamentoCon.SelectedIndex == 0 ? 0 : Convert.ToInt32(ddDepartamentoCon.SelectedValue));
        }
    }

    protected void ddMunicipioCon_DataBound(object sender, EventArgs e)
    {
        if (ddMunicipioCon.Items.Count > 0)
        {
            ddMunicipioCon.Items.Insert(0, "(Seleccione)");
        }
    }

    private void ConsultarOrganizacion(int idMunicipio, int idDepartamento)
    {
        Organizacion oOrganizacion = new Organizacion();
        oOrganizacion.IdMunicipio = idMunicipio;
        oOrganizacion.IdDepartamento = idDepartamento;
        Datos.Broker oTC = new Datos.Broker();
        ddOrganizacion.DataSource = oTC.obtenerListaOrganizacion(oOrganizacion);
        ddOrganizacion.DataBind();
    }

    protected void ddOrganizacion_DataBound(object sender, EventArgs e)
    {
        if (ddOrganizacion.Items.Count > 0)
        {
            ddOrganizacion.Items.Insert(0, "(Seleccione)");
        }
    }
}