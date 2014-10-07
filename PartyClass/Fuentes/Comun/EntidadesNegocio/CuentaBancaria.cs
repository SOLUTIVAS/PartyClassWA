// -----------------------------------------------------------------------
// <copyright file="CuentaBancaria.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Comun.EntidadesNegocio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CuentaBancaria
    {
        public int idCuenta { get; set; }
        public string Banco { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public string NombreCuenta { get; set; }
        public string Titular { get; set; }
        public bool Activa { get; set; }
    }
}
