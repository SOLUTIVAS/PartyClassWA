

namespace Comun.EntidadesNegocio
{
    using System;

    [Serializable]
    public class Evento
    {
        public double idEvento
        {
            get;
            set;
        }

        public int idTipoEvento 
        { 
            get; 
            set; 
        }

        public string Descripcion
        {
            get;
            set;
        }

        public string Ciudad
        {
            get;
            set;
        }

        public DateTime FechaInicio
        {
            get;
            set;
        }

        public DateTime FechaFin
        {
            get;
            set;
        }

        public DateTime FechaRegistro
        {
            get;
            set;
        }

        public DateTime FechaLimiteInscripcion
        {
            get;
            set;
        }

        public bool Activo { get; set; }
    }
}
