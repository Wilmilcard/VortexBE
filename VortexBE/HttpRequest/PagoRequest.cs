using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VortexBE.Domain.Models;

namespace VortexBE.HttpRequest
{
    public class PagoRequest
    {
        //Info de Entrada
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public int FuncionId { get; set; }
        //Info para pago
        public string MetodoPago { get; set; }
    }
}
