using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun.EntidadesNegocio
{
    [Serializable]
    public class RegistroLlamada
    {
        public RegistroLlamada() 
        { }

        public double idRegistroLlamada { get; set; }
        public double idUsuario { get; set; }
        public double idCliente { get; set; }
        public double Documento { get; set; }
        public double idOrganizacion { get; set; }
        public double idCargo { get; set; }
        public int idDepartamento { get; set; }
        public int idMunicipio { get; set; }
        public string NombreUsuario { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Cargo { get; set; }
        public string NombresCliente { get; set; }
        public string ApellidosCliente { get; set; }
        public DateTime Fecha { get; set; }
        public double idEvento { get; set; }
        public string NombreEvento { get; set; }
        public string Observacion { get; set; }
        public string Telefono { get; set; }
        public bool? VolverALlamar { get; set; }
        public DateTime FechaHoraVolverALlamar { get; set; }
    }
}
