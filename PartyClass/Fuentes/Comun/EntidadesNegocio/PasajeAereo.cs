using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun.EntidadesNegocio
{
    public class PasajeAereo
    {
        public double idPasaje { get; set; }
        public string Avion { get; set; }
        public string Aerolinea { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public int idMunicipioOrigen { get; set; }
        public int idMunicipioDestino { get; set; }
        public bool Redondo { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaRegreso { get; set; }
        public string Clase { get; set; }
        public string CodigoPasaje { get; set; }
    }
}
