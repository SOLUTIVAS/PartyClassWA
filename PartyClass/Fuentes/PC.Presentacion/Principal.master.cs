#region Copyright
//-----------------------------------------------------------------
//Prohibida la reproducci�n o trasmisi�n de todo o parte de este material, 
//en cualquier forma o medio, electr�nico, mec�nico o de cualquier otra 
//�ndole, sin la previa autorizaci�n escrita del propietario de los derechos.
//
//  Archivo :  Principal.cs
//  P�gina maestra que servir� de base para las dem�s p�ginas de la aplicaci�n
//  Fecha de Creaci�n: ENERO 2013
//  Autor : ANDR�S JULI�N CHALARCA ESCOBAR
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
