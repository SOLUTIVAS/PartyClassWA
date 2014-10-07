namespace Comun.TO
{
    using System;
    using Comun.EntidadesNegocio;

    /// <summary>
    /// Objeto transaccional para guardar datos de Cliente por evento.
    /// </summary>
    [Serializable]
    public class CientePorEventoTO : CientePorEvento
    {
        public double idCliente { get; set; }
        public double idCargo { get; set; }
        public double idPasajeAereo { get; set; }
        public double idAsignacionHotel { get; set; }
        public double PrecioVentaPasaje { get; set; }
        public double PrecioAsignacionHotel { get; set; }
        public double? idUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Clase { get; set; }
        public string Avion { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Organizacion { get; set; }
        public string ObservacionesHotel { get; set; }
        public string ObservacionesPasajes { get; set; }
        public string Cargo { get; set; }
        public string CodigoPasaje { get; set; }
        public int idDepartamento { get; set; }
        public int idMunicipio { get; set; }
        public double idOrganizacion { get; set; }
        public DateTime? FechaSalidaVuelo { get; set; }
        public DateTime? FechaRegresoVuelo { get; set; }
        public Funcionario oFuncionario { get; set; }
    }
}
