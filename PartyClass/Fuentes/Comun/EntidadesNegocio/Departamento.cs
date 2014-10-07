using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun.EntidadesNegocio
{
    public class Departamento
    {
        public Departamento()
        { 
        }

        public int idDepartamento { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string CodigoDANE { get; set; }
    }
}
