using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun.EntidadesNegocio
{
    public class Municipio
    {
        public Municipio()
        { 
        }

        public int idMunicipio { get; set; }
        public string Nombre { get; set; }
        public string CodigoDANE { get; set; }
        public int idDepartamento { get; set; }
        public string Categoria { get; set; }
        public bool Capital { get; set; }
    }
}
