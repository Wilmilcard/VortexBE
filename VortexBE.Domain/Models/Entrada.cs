using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexBE.Domain.Models
{
    [Table("Entrada")]
    public class Entrada : Auditory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("EntradaId")]
        public int EntradaId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        [Required]
        public DateTime FechaCompra { get; set; } = DateTime.Now;

        //Foreigns
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User Usuario { get; set; }
        
        [ForeignKey("FuncionId")]
        public int FuncionId { get; set; }
        public virtual Funcion Funcion { get; set; }

        //Virtuals
        public virtual Pago Pago { get; set; }
    }
}
