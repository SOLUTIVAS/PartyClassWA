using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.XPath;

namespace Mensajes
{
    public class Mensaje
    {
        #region Constantes

        /// <summary>
        /// Nombre del archivo de mensajes.
        /// </summary>
        private const string NOMBRE_ARCHIVO_MENSAJES = "Mensajes.xml";

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Mensaje()
        {
        }

        /// <summary>
        /// Crea una nueva instancia del mensaje, consultando el texto asociado al código.
        /// </summary>
        /// <param name="codigo">Código con el que se identifica y se consulta el mensaje.
        /// </param>
        public Mensaje(int codigo)
            : this(codigo, null)
        {
        }

        /// <summary>
        /// Crea una nueva instancia del mensaje, consultando el texto asociado al código.
        /// </summary>
        /// <param name="codigo">Código con el que se identifica y se consulta el mensaje.
        /// </param>
        /// <param name="parametros">Parámetros necesarios para completar el texto del
        /// mensaje.</param>
        public Mensaje(int codigo, params string[] parametros)
        {
            ConsultarMensaje(codigo);
            this.Codigo = codigo;
            if (parametros != null)
            {
                this.Texto = string.Format(this.Texto, parametros);
            }
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Obtiene el código del mensaje.
        /// </summary>
        public int Codigo
        {
            get;
            set;
        }

        /// <summary>
        /// Obtiene los parametros que se utilizan para construir la descripción del
        /// mensaje.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Analisís y Diseño")]
        public string[] Parametros
        {
            get;
            set;
        }

        /// <summary>
        /// Obtiene la descripción del mensaje.
        /// </summary>
        public string Texto
        {
            get;
            set;
        }

        /// <summary>
        /// Obtiene el tipo de mensaje.
        /// </summary>
        public TipoMensaje Tipo
        {
            get;
            set;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Lee el archivo xml que contiene la lista de mensajes basado en los códigos.
        /// </summary>
        /// <returns>Nodo con la información respectiva del mensaje.</returns>
        private static XPathDocument ObtenerArchivoMensajes()
        {
            string rutaArchivo = ObtenerRutaArchivoMensajes();

            if (!File.Exists(rutaArchivo))
            {
                string mensaje = "No se encontró el archivo";
                throw new FileNotFoundException(mensaje);
            }

            XPathDocument documentoMensajes = new XPathDocument(rutaArchivo);

            return documentoMensajes;
        }

        /// <summary>
        /// Obtiene la ruta del archivo de mensajes. Este metodo utiliza las costantes de
        /// precompilacion PLATAFORMA_ASPNET y PLATAFORMA_WINDOWS, para establecer el
        /// mecanismo de lectura de la ruta.
        /// </summary>
        /// <returns>Ruta del archivo de mensajes.</returns>
        private static string ObtenerRutaArchivoMensajes()
        {
            string rutaArchivoConfiguracion = String.Empty;

           //if(PLATAFORMA_ASPNET)
                rutaArchivoConfiguracion = string.Format("{0}\\{1}", AppDomain.CurrentDomain.RelativeSearchPath, NOMBRE_ARCHIVO_MENSAJES);
            //#endif
            //#if(PLATAFORMA_WINDOWS)
                //rutaArchivoConfiguracion = string.Format("{0}\\{1}", AppDomain.CurrentDomain.BaseDirectory, NOMBRE_ARCHIVO_MENSAJES);
            //#endif

            return rutaArchivoConfiguracion;
        }

        /// <summary>
        /// Consulta la información (desde el repositorio de mensajes) necesaria para crear
        /// un mensaje según el código. Establece los valores para las variables de clase.
        /// </summary>
        /// <param name="codigo">Código del mensaje.</param>
        private void ConsultarMensaje(int codigo)
        {
            XPathDocument documentoMensajes = ObtenerArchivoMensajes();
            if (documentoMensajes != null)
            {
                XPathNavigator navegador = documentoMensajes.CreateNavigator();
                XPathExpression filtroMensaje = navegador.Compile(string.Format("mensajes/mensaje[@codigo='{0}']", codigo.ToString()));
                XPathNodeIterator nodosMensaje = navegador.Select(filtroMensaje);

                if (nodosMensaje != null)
                {
                    nodosMensaje.MoveNext();

                    this.Texto = nodosMensaje.Current.Value;

                    int tipoMensaje = string.IsNullOrEmpty(nodosMensaje.Current.GetAttribute("tipo", string.Empty)) ? 0 : Convert.ToInt32(nodosMensaje.Current.GetAttribute("tipo", string.Empty));
                    this.Tipo = (TipoMensaje)tipoMensaje;
                }
            }
        }

        #endregion
    }
}
