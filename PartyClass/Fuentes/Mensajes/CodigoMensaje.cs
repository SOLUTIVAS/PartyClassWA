using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mensajes
{
    public struct CodigoMensaje
    {
        #region Atributos

        /// <summary>
        /// {0}.
        /// </summary>
        public const int MENSAJE0 = 0;

        /// <summary>
        /// El sistema no pudo realizar la operación solicitada. Por favor contacte al administrador del sistema.
        /// </summary>
        public const int MENSAJE500 = 500;

        /// <summary>
        /// {0}. Mensaje genérico de error.
        /// </summary>
        public const int MENSAJE600 = 600;

        /// <summary>
        /// {0}. Mensaje genérico de confirmación.
        /// </summary>
        public const int MENSAJE620 = 620;

        /// <summary>
        /// {0}. Mensaje genérico de exito.
        /// </summary>
        public const int MENSAJE630 = 630;
        
        /// <summary>
        /// {0}. Mensaje genérico de advertencia.
        /// </summary>
        public const int MENSAJE640 = 640;

        /// <summary>
        /// Error almacenando la información..
        /// </summary>
        public const int MENSAJE101 = 101;

        /// <summary>
        /// Error actualizando la información.
        /// </summary>
        public const int MENSAJE102 = 102;

        /// <summary>
        /// La fecha final {0} no puede ser menor que la fecha inicial {1}.
        /// </summary>
        public const int MENSAJE107 = 107;

        /// <summary>
        /// La extensión del archivo no está soportada.
        /// </summary>
        public const int MENSAJE110 = 110;

        /// <summary>
        /// No se ha subido ningún archivo.
        /// </summary>
        public const int MENSAJE111 = 111;

        /// <summary>
        /// Debe ingresar la información del hotel o del vuelo según sea el caso
        /// </summary>
        public const int MENSAJE112 = 112;

        /// <summary>
        /// Está seguro que desea eliminar el reporte {0}?
        /// </summary>
        public const int MENSAJE201 = 201;

        /// <summary>
        /// El proceso ha finalizado exitosamente
        /// </summary>
        public const int MENSAJE301 = 301;

        /// <summary>
        /// No se encontraron registros
        /// </summary>
        public const int MENSAJE302 = 302;

        /// <summary>
        /// La información se guardo con éxito.
        /// </summary>
        public const int MENSAJE303 = 303;

        /// <summary>
        /// La información se actualizó exitosamente.
        /// </summary>
        public const int MENSAJE304 = 304;

        /// <summary>
        /// La información se eliminó exitosamente.
        /// </summary>
        public const int MENSAJE305 = 305;
        
        /// <summary>
        /// No se encontraron Registros en la Consulta
        /// </summary>
        public const int MENSAJE308 = 308;

        

        #endregion
    }
}
