// -----------------------------------------------------------------------
// <copyright file="EstadoCuentaTO.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Comun.TO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Objeto transaccional para obtener el estado de cuenta de los clientes.
    /// </summary>
    [Serializable]
    public class EstadoCuentaTO
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public double idCliente { get; set; }
        public double Documento { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Organizacion { get; set; }
        public string Cargo { get; set; }
        public int NroEventos { get; set; }
        public double SumPasajes { get; set; }
        public double SumAsignacionHotel { get; set; }
        public double SumServiciosAdicionales { get; set; }
        public double VentaTotal { get; set; }
        public double SumValorPagado { get; set; }
        public double Saldo { get; set; }
    }
}
