using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun.EntidadesNegocio
{
    [Serializable]
    public class Telefono
    {
        public double idTelefono { get; set; }
        public double idOrganizacion { get; set; }
        public double idCliente { get; set; }
        public int Orden { get; set; }
        public string Tipo { get; set; }
        public string NumeroTelefonico { get; set; }
        public string Indicativo { get; set; }
    }
}
