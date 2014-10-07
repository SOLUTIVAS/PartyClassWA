
namespace Comun.EntidadesNegocio
{
	using System;

	[Serializable]
	public class CientePorEvento
	{
        public double idDetalleEvento { get; set; }
		public string TipoEvento { get; set; }
		public string NomreEvento { get; set; }
		public double? Documento { get; set; }
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public DateTime? FechaCheckIn_Hotel { get; set; }
		public DateTime? FechaCheckOut_Hotel { get; set; }
        public string NroHab { get; set; }
        public string NombreCama { get; set; }
		public string Acommodacion { get; set; }
		public string NombreHotel { get; set; }
		public DateTime FechaRegistroEvento { get; set; }
		public bool Pazysalvo { get; set; }
        public string Aerolinea { get; set; }
		public string CiudadOrigen { get; set; }
		public string CiudadDestino { get; set; }
        public double idEvento { get; set; }
        public double? idCama { get; set; }
		public double? idHotel { get; set; }
	}
}
