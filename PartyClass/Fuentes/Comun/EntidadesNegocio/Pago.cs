

namespace Comun.EntidadesNegocio
{
    using System;

    [Serializable]
    public class Pago
    {
        public double idPagoEvento { get; set; }
        public int idCuenta { get; set; }
        public string NombreNumeroCuenta { get; set; }
        public string NumeroConsignacion { get; set; }
        public string NombreEvento { get; set; }
        public string ConceptoPago { get; set; }
        public int? idMedioPago { get; set; }
        public string MedioPago { get; set; }
        public bool PagoVerificado { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal ValorPagado { get; set; }
        public decimal ValorDetalle { get; set; }
        public int CantReservas { get; set; }
        public double idUsuario { get; set; }
        public string Usuario { get; set; }
        
        public double? idEvento { get; set; }
        public double? Documento { get; set; }
        public double? idCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
    }
}