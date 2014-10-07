using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun.EntidadesNegocio
{
    public class Organizacion
    {
        public Organizacion()
        {
        }

        public double Id { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public int IdTipo { get; set; }
        public int IdMunicipio { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string SecretarioDespacho { get; set; }
        public int MyProperty { get; set; }
        public string Email2 { get; set; }
        public string Fuente { get; set; }
        public string Pagina { get; set; }
        public string Cumpleanos { get; set; }
        public string FechaFiestas { get; set; }
        public string PeriodicidadFiestas { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string NombreFiestas { get; set; }
        public int IdDepartamento { get; set; }
    }
}
