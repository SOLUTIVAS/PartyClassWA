using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun.EntidadesNegocio
{
    [Serializable]
    public class Funcionario
    {
        public double Documento { get; set; }
        public string Asistente { get; set; }
        public string Periodo { get; set; }
        public int idCargo { get; set; }
        public string PartidoPolitico { get; set; }
        public string Asociacion { get; set; }
        public string Observaciones { get; set; }
        public double idOrganizacion { get; set; }
        public int idDepartamento { get; set; }
        public int idMunicipio { get; set; }
    }
}
