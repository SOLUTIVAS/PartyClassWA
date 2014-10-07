using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Comun;
using Mensajes;

public partial class MensajeSistema : System.Web.UI.UserControl
{
    #region Métodos Públicos

    /// <summary>
    /// Muestra en pantalla el mensaje según su tipo.
    /// </summary>
    /// <param name="mensaje">Mensaje a mostrar al usuario.</param>
    public void MostrarMensajes(Mensaje mensaje)
    {
        List<Mensaje> listaMensaje = new List<Mensaje>();
        listaMensaje.Add(mensaje);
        this.MostrarMensajes(listaMensaje);
    }

    /// <summary>
    /// Muestra en pantalla el listado de mensajes según el tipo.
    /// </summary>
    /// <param name="listaMensajes">Lista de mensajes a mostrar al usuario.</param>
    public void MostrarMensajes(List<Mensaje> listaMensajes)
    {
        lblError.Text = string.Empty;
        lblAdvertencia.Text = string.Empty;
        lblInformacion.Text = string.Empty;
        lblOk.Text = string.Empty;

        foreach (Mensaje mensaje in listaMensajes)
        {
            this.RenderizarMensaje(mensaje.Texto, mensaje.Tipo);
        }

        this.MostrarPaneles();
    }

    /// <summary>
    /// Muestra en pantalla el texto del mensaje según su tipo.
    /// </summary>
    /// <param name="textoMensaje">Texto del mensaje.</param>
    /// <param name="tipo">Tipo del mensaje.</param>
    public void MostrarMensajes(string textoMensaje, TipoMensaje tipo)
    {
        lblError.Text = string.Empty;
        lblAdvertencia.Text = string.Empty;
        lblInformacion.Text = string.Empty;
        lblOk.Text = string.Empty;

        this.RenderizarMensaje(textoMensaje, tipo);
        this.MostrarPaneles();
    }

    #endregion

    #region Eventos

    /// <summary>
    /// Evento que se ejecuta cuando se carga la página.
    /// </summary>
    /// <param name="sender">Object sender.</param>
    /// <param name="e">EventArgs e.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblAdvertencia.Text) &&
            string.IsNullOrEmpty(lblError.Text) &&
            string.IsNullOrEmpty(lblInformacion.Text) &&
            string.IsNullOrEmpty(lblOk.Text))
        {
            this.LimpiarOcultarPaneles();
        }
    }
    #endregion

    #region Métodos Privados

    /// <summary>
    /// Renderizar un mensaje en su respectivo panel.
    /// </summary>
    /// <param name="textoMensaje">Texto del mensaje.</param>
    /// <param name="tipo">Tipo del mensaje.</param>
    private void RenderizarMensaje(string textoMensaje, TipoMensaje tipo)
    {
        if (!string.IsNullOrEmpty(textoMensaje))
        {
            if (tipo == TipoMensaje.Error)
            {
                lblError.Text += string.Format("{0}", textoMensaje);
            }
            else if (tipo == TipoMensaje.Advertencia)
            {
                lblAdvertencia.Text += string.Format("{0}", textoMensaje);
            }
            else if (tipo == TipoMensaje.Informacion)
            {
                lblInformacion.Text += string.Format("{0}", textoMensaje);
            }
            else if (tipo == TipoMensaje.Success)
            {
                lblOk.Text += string.Format("{0}", textoMensaje);
            }
        }
    }

    /// <summary>
    /// Muestra u oculta los paneles dependiendo del contenido de sus 
    /// respectivos labels.
    /// </summary>
    private void MostrarPaneles()
    {
        this.MostrarPanel(lblError, pnlError);
        this.MostrarPanel(lblAdvertencia, pnlAdvertencia);
        this.MostrarPanel(lblInformacion, pnlInformacion);
        this.MostrarPanel(lblOk, pnlOk);
    }

    /// <summary>
    /// Muestra u oculta los paneles dependiendo del contenido de sus 
    /// respectivos labels.
    /// </summary>
    /// <param name="lbl">Label donde residen los mensajes.</param>
    /// <param name="panel">Panel donde reside el label.</param>
    private void MostrarPanel(Label lbl, Panel panel)
    {
        if (!string.IsNullOrEmpty(lbl.Text))
        {
            panel.Visible = true;
        }
        else
        {
            panel.Visible = false;
        }
    }

    /// <summary>
    /// Limpia y oculta los paneles.
    /// </summary>blic
    public void LimpiarOcultarPaneles()
    {
        pnlError.Visible = false;
        pnlAdvertencia.Visible = false;
        pnlInformacion.Visible = false;
        pnlOk.Visible = false;

        lblError.Text = string.Empty;
        lblAdvertencia.Text = string.Empty;
        lblInformacion.Text = string.Empty;
        lblOk.Text = string.Empty;
    }
    #endregion
}