

namespace Comun.EntidadesNegocio
{
    using System;

    [Serializable]
    public class NoRegistrados
    {
        public double Documento { get; set; }
        public double idCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Organizacion { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Estudios { get; set; }
        public string Idiomas { get; set; }
        public string Visas { get; set; }
        public string EstadoCivil { get; set; }
        public int Hijos { get; set; }
    }
}
