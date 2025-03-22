using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexBE.Domain.Models
{
    [Table("Pago")]
    public class Pago
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("PagoId")]
        public int PagoId { get; set; }
        
        [Required]
        [StringLength(20)]
        public string MetodoPago { get; set; } // Tarjeta, Nequi, PSE, Efectivo

        [Required]
        [StringLength(10)]
        public string Estado { get; set; } // Pendiente, Pagado, Fallido

        [Required]
        public DateTime FechaPago { get; set; } = DateTime.Now;

        //Foreign
        [ForeignKey("EntradaId")]
        public int EntradaId { get; set; }
        public virtual Entrada Entrada { get; set; }
    }
}
