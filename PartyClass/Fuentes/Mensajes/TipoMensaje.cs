using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Mensajes
{
    /// <summary>
    /// Define las constantes para los diferentes tipos de mensajes.
    /// </summary>    
    public enum TipoMensaje : int
    {
        /// <summary>
        /// Mensaje de tipo de error.
        /// </summary>
        Error = 1,

        /// <summary>
        /// Mensaje de tipo confirmación.
        /// </summary>
        Pregunta = 2,

        /// <summary>
        /// Mensaje de tipo información.
        /// </summary>
        Informacion = 3,

        /// <summary>
        /// Mensaje de tipo advertencia.
        /// </summary>
        Advertencia = 4,

        /// <summary>
        /// Mensaje de éxito.
        /// </summary>
        Success = 5
    }
}
