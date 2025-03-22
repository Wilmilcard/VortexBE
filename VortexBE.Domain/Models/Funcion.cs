using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexBE.Domain.Models
{
    [Table("Funcion")]
    public class Funcion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("FuncionId")]
        public int FuncionId { get; set; }
        
        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }

        //Foreign keys
        [ForeignKey("PeliculaId")]
        public int PeliculaId { get; set; }
        public virtual Pelicula Pelicula { get; set; }

        [ForeignKey("SalaId")]
        public int SalaId { get; set; }
        public virtual Sala Sala { get; set; }

        //Virtuals
        public virtual List<Entrada> Entradas { get; set; } = new List<Entrada>();
    }
}
