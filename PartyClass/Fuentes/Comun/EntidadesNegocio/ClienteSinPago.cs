
namespace Comun.EntidadesNegocio
{
    using System;

    [Serializable]
    public class ClienteSinPago
    {
        public double idDetalleEvento { get; set; }
        public string NombreEvento { get; set; }
        public double idEvento { get; set; }
        public double? idCliente { get; set; }
        public double? Documento { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool ReservaPasajeAereo { get; set; }
        public bool ReservaHotel { get; set; }
        public bool Pazysalvo { get; set; }
        public string Cargo { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Organizacion { get; set; }
        public double ValorAsignado { get; set; }
    }
}
