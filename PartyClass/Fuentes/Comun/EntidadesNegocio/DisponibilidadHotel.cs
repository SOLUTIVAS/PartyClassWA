
namespace Comun.EntidadesNegocio
{
    using System;

    [Serializable]
    public class DisponibilidadHotel
    {
        public double idEvento { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string NombreHotel { get; set; }
        public string NroHabitacion { get; set; }
        public string Acomodacion { get; set; }
        public int CamasPorHabitacion { get; set; }
        public int? CamasDisponibles { get; set; }
        public int? CamasOcupadas { get; set; }
        public double? idHotel { get; set; }
    }
}
