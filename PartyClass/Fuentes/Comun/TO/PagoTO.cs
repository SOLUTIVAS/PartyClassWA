namespace Comun.TO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Comun.EntidadesNegocio;

    /// <summary>
    /// Objeto transaccional para guardar datos de pago.
    /// </summary>
    [Serializable]
    public class PagoTO: Pago
    {
        public double idCargo { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Organizacion { get; set; }
        public string Cargo { get; set; }
        public int idDepartamento { get; set; }
        public int idMunicipio { get; set; }
        public double idOrganizacion { get; set; }
        public Funcionario oFuncionario { get; set; }        
    }
}
