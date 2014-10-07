using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun.EntidadesNegocio
{
    [Serializable]
    public class Cliente
    {
        public Cliente()
        {
        }

        public double idCliente { get; set; }
        public double Documento { get; set; }
        public string LugarExpedicion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CiudadNacimiento { get; set; }
        public string CiudadResidencia { get; set; }
        public char Sexo { get; set; }
        public string TipoSangre { get; set; }
        public string TallaCamiseta { get; set; }
        public string PinBB { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Estudios { get; set; }
        public string Idiomas { get; set; }
        public string Visas { get; set; }
        public string EstadoCivil { get; set; }
        public double idUsuarioRegistroMod { get; set; }
        public int Hijos { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
