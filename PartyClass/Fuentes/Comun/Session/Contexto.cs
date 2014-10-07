
namespace Comun.Session
{
    using System;
    using System.Web;

    /// <summary>
    /// Provee una fachada para los estado de Sesión. Cualquier acceso a las variables de sesión debe ser a través de esta clase.
    /// </summary>
    public class Contexto
    {
        #region Atributos

        /// <summary>
        /// Identificador del Usuario logeado en la aplicación.
        /// </summary>
        private const string IdUsuario = "idUsuario";

        /// <summary>
        /// Usuario logeado en la aplicación.
        /// </summary>
        private const string NombreUsuario = "Username";

        /// <summary>
        /// Rol del Usuario logeado en la aplicación.
        /// </summary>
        private const string Cargo = "Cargo";

        #endregion

        #region Propiedades

        /// <summary>
        /// Cédula del Usuario logeado en la aplicación.
        /// </summary>
        public static double? idUsuario
        {
            get
            {
                return HttpContext.Current.Session[IdUsuario] != null ? Convert.ToDouble (HttpContext.Current.Session[IdUsuario]) : (double?) null;
            }

            set
            {
                HttpContext.Current.Session[IdUsuario] = value;
            }
        }

        /// <summary>
        ///Usuario logeado en la aplicación.
        /// </summary>
        public static string nombreUsuario
        {
            get
            {
                return HttpContext.Current.Session[NombreUsuario] != null ? Convert.ToString(HttpContext.Current.Session[NombreUsuario]) : string.Empty;
            }

            set
            {
                HttpContext.Current.Session[NombreUsuario] = value;
            }
        }

        /// <summary>
        ///Cargo del usuario logueado.
        /// </summary>
        public static string cargo
        {
            get
            {
                return HttpContext.Current.Session[Cargo] != null ? Convert.ToString(HttpContext.Current.Session[Cargo]) : string.Empty;
            }

            set
            {
                HttpContext.Current.Session[Cargo] = value;
            }
        }

        /// <summary>
        ///Usuario logeado en la aplicación.
        /// </summary>
        public static int TIMEOUT
        {
            set
            {
                HttpContext.Current.Session.Timeout = value;
            }
        }

        #endregion
    }
}
