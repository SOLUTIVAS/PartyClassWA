namespace Comun.TO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Comun.EntidadesNegocio;

    [Serializable]
    public class ClienteTO: Cliente
    {
        public string Cargo { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Telefonos { get; set; }
        public string FechaUltLlamada { get; set; }
        public double idCargo { get; set; }
        public double idEvento { get; set; }
        public double idOrganizacion { get; set; }
        public int idDepartamento { get; set; }
        public int idMunicipio { get; set; }
        public Funcionario oFuncionario { get; set; }
    }
}
