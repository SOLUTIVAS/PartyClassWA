#region Copyright
//-----------------------------------------------------------------
//Prohibida la reproducción o trasmisión de todo o parte de este material, 
//en cualquier forma o medio, electrónico, mecánico o de cualquier otra 
//índole, sin la previa autorización escrita del propietario de los derechos.
//
//  Archivo :  Principal.cs
//  Página maestra que servirá de base para las demás páginas de la aplicación
//  Fecha de Creación: ENERO 2013
//  Autor : ANDRÉS JULIÁN CHALARCA ESCOBAR
//  SOLUTIC.CO
//-----------------------------------------------------------------
#endregion

namespace PC
{
    using System;
    using Comun.Session;
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {       
            if (Contexto.idUsuario != null)
            {
                lblFecha.Text = DateTime.Now.ToString();
                lblUsuario.Text = Contexto.nombreUsuario;
            }
            else
            {
                this.Response.Redirect ("~/Default.aspx", false);
            }
        }
    }
}
