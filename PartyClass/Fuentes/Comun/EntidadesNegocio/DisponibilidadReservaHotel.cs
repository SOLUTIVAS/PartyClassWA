
namespace Comun.EntidadesNegocio
{
    using System;

    [Serializable]
    public class DisponibilidadReservaHotel
    {
        public string NombreHotel
        {
            get;
            set;
        }

        public string NumeroHabitacion
        {
            get;
            set;
        }
        
        public string Acomodacion
        {
            get;
            set;
        }

        public int IdCama
        {
            get;
            set;
        }

        public string NumeroCama
        {
            get;
            set;
        }

        public string CamaDisponible
        {
            get;
            set;
        }
        
        public bool Disponible
        {
            get;
            set;
        }

        public string ReservadoPor
        {
            get;
            set;
        }

        public double Precio { get; set; }
    }
}
