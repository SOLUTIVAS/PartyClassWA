using System;
using System.Web.UI;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Comun.Excepciones;

namespace TC.App_Code
{
    /// <summary>
    /// Summary description for Utilidad
    /// </summary>
    public static class Utilidad
    {
        /// <summary>
        /// Controla cualquier excepción que ocurra en el sistema, sin
        /// tener en cuenta las de SQL, aplicando la política para el manejo
        /// de excepciones y redireccionando a la página de error.
        /// </summary>
        /// <param name="pagina">Página donde ocurre la excepción.</param>
        /// <param name="excepcion">Excepción generada.</param>
        public static void ManejarExcepcion (this Page pagina, Exception excepcion)
        {
            ExceptionPolicy.HandleException (excepcion, PoliticaExcepcion.PoliticaLog);

            const string Pagina_Error = "~/Seguridad/Error.aspx";

            pagina.Response.Redirect (Pagina_Error, false);
        }

        /// <summary>
        /// Controla cualquier excepción que ocurra en el sistema, sin
        /// tener en cuenta las de SQL, aplicando la política para el manejo
        /// de excepciones y redireccionando a la página de error.
        /// </summary>
        /// <param name="pagina">Página donde ocurre la excepción.</param>
        /// <param name="excepcion">Excepción generada.</param>
        public static void ManejarExcepcionPublico (this Page pagina, Exception excepcion)
        {
            ExceptionPolicy.HandleException (excepcion, PoliticaExcepcion.PoliticaLog);

            const string Pagina_Error = "~/Seguridad/ErrorPublico.aspx";

            pagina.Response.Redirect (Pagina_Error, false);
        }
    }
}