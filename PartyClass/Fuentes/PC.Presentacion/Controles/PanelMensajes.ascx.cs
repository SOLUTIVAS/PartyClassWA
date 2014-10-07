using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PanelMensajes : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Metodos

    ///// <summary>
    ///// Lleva al label una lista de mensajes
    ///// </summary>
    //public void MostrarMensajes(List<Mensaje> mensaje, string tipoError)
    //{
    //    string mensajeTexto = string.Empty;
    //    string labelTexto = string.Empty;
    //    string labelTextoError = string.Empty;

    //    int numeroMensajes = mensaje.Count;

    //    foreach (Mensaje mensajeError in mensaje)
    //    {
    //        if (mensajeError.Tipo == TipoMensaje.Informacion || mensajeError.Tipo == TipoMensaje.Pregunta)
    //        {
    //            mensajeTexto = mensajeError.Texto;
    //            if (labelTexto == string.Empty)
    //            {
    //                labelTexto = mensajeTexto;
    //            }
    //            else
    //            {
    //                labelTexto = labelTexto + "<br>" + mensajeTexto;
    //            }
    //        }
    //        else
    //        {

    //            mensajeTexto = mensajeError.Texto;
    //            if (labelTextoError == string.Empty)
    //            {
    //                labelTextoError = mensajeTexto;
    //            }
    //            else
    //            {
    //                labelTextoError = labelTextoError + "<br>" + mensajeTexto;
    //            }

    //        }
    //    }
    //    if (tipoError == "Informacion")
    //        tipoError = "Información";

    //    // lblTipoError.Text = tipoError;

    //    if (!string.IsNullOrEmpty(labelTexto.Trim()))
    //    {
    //        panelInformacion.Visible = true;
    //        lblMensaje.Text = labelTexto;

    //    }
    //    else
    //        panelInformacion.Visible = false;

    //    if (!string.IsNullOrEmpty(labelTextoError.Trim()))
    //    {
    //        panelError.Visible = true;
    //        lblMensajeError.Text = labelTextoError;

    //    }
    //    else
    //        panelError.Visible = false;
    //}


    ///// <summary>
    ///// Lleva al label una lista de mensajes
    ///// </summary>
    //public void MostrarMensajes(List<Mensaje> mensaje)
    //{
    //    string mensajeTexto = string.Empty;
    //    string labelTexto = string.Empty;
    //    string labelTextoError = string.Empty;

    //    int numeroMensajes = mensaje.Count;

    //    foreach (Mensaje mensajeError in mensaje)
    //    {
    //        if (mensajeError.Tipo == TipoMensaje.Informacion || mensajeError.Tipo == TipoMensaje.Pregunta)
    //        {
    //            mensajeTexto = mensajeError.Texto;
    //            if (labelTexto == string.Empty)
    //            {
    //                labelTexto = mensajeTexto;
    //            }
    //            else
    //            {
    //                labelTexto = labelTexto + "<br>" + mensajeTexto;
    //            }
    //        }
    //        else
    //        {

    //            mensajeTexto = mensajeError.Texto;
    //            if (labelTextoError == string.Empty)
    //            {
    //                labelTextoError = mensajeTexto;
    //            }
    //            else
    //            {
    //                labelTextoError = labelTextoError + "<br>" + mensajeTexto;
    //            }

    //        }
    //    }

    //    if (!string.IsNullOrEmpty(labelTexto.Trim()))
    //    {
    //        panelInformacion.Visible = true;
    //        lblMensaje.Text = labelTexto;

    //    }
    //    else
    //        panelInformacion.Visible = false;

    //    if (!string.IsNullOrEmpty(labelTextoError.Trim()))
    //    {
    //        panelError.Visible = true;
    //        lblMensajeError.Text = labelTextoError;

    //    }
    //    else
    //        panelError.Visible = false;
    //}

    ///// <summary>
    ///// Lleva al label un mensaje
    ///// </summary>
    //public void MostrarMensajes(string mensaje, string tipoMensaje)
    //{
    //    if (tipoMensaje == TipoMensaje.Error.ToString())
    //    {
    //        panelError.Visible = true;
    //        panelInformacion.Visible = false;
    //        lblMensajeError.Text = mensaje;
    //    }
    //    else
    //    {
    //        panelInformacion.Visible = true;
    //        panelError.Visible = false;
    //        lblMensaje.Text = mensaje;
    //    }

    //}

    ///// <summary>
    ///// Lleva al label un mensaje
    ///// </summary>
    //public void MostrarMensajes(string mensaje, TipoMensaje tipoMensaje)
    //{
    //    if (tipoMensaje == TipoMensaje.Error)
    //    {
    //        panelError.Visible = true;
    //        panelInformacion.Visible = false;
    //        lblMensajeError.Text = mensaje;
    //    }
    //    else
    //    {
    //        panelInformacion.Visible = true;
    //        panelError.Visible = false;
    //        lblMensaje.Text = mensaje;
    //    }

    //}
    #endregion
}