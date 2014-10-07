
namespace Comun.EntidadesNegocio
{
    using System;

    [Serializable]
    public class Registro
    {
        public double idRegistro { get; set; }
        public double Documento { get; set; }
        public double idCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public int idMunicipio { get; set; }
        public bool RequiereHotel { get; set; }
        public DateTime FechaCkeckInHotel { get; set; }
        public DateTime FechaCheckOutHotel { get; set; }
        public string TipoAcomodacion { get; set; }
        public bool RequierePasajes { get; set; }
        public DateTime FechaSalidaPasajes { get; set; }
        public DateTime FechaRegresoPasajes { get; set; }
        public string LugarSalida { get; set; }
        public double idEvento { get; set; }
        public int idcargo { get; set; }
        public string Observaciones { get; set; }
        public bool Seleccionar { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
