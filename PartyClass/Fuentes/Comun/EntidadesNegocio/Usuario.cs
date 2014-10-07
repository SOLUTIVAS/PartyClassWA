using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comun.EntidadesNegocio
{
    [Serializable]
    public class Usuario
    {
        public Usuario()
        { 
        }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cargo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Cedula { get; set; }
        public string Email { get; set; }
        public double idUsuario { get; set; }
    }
}
