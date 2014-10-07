
namespace Comun.TO
{
    using System;

    [Serializable]
    public class DetalleEventoTO
    {
        public double idDetalleEvento { get; set; }
        public double idEvento { get; set; }
        public double documentoCliente { get; set; }
        public double idCliente { get; set; }
        public bool Pazysalvo { get; set; }

        public bool RequierePasajes { get; set; }
        public string Aerolinea { get; set; }
        public string Avion { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaRegreso { get; set; }
        public bool Redondo { get; set; }
        public string Clase { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioHotel { get; set; }
        public decimal Costo { get; set; }
        public string CodigoPasaje { get; set; }
        
        public int idMunicipioOrigen { get; set; }
        public int idMunicipioDestino { get; set; }

        public bool RequiereHotel{ get; set; }
        public int idCama { get; set; }
        public DateTime FechaCheckIn { get; set; }
        public DateTime FechaCheckOut { get; set; }
        public string ObservacionesHotel { get; set; }
        public string ObservacionesPasaje { get; set; }
        public double idUsuario { get; set; }
    }
}
