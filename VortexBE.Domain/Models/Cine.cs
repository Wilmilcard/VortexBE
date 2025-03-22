using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexBE.Domain.Models
{
    [Table("Cine")]
    public class Cine : Auditory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("CineId")]
        public int CineId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(100)]
        public string Ciudad { get; set; }

        //Virtuals
        public virtual List<Sala> Salas { get; set; } = new List<Sala>();
    }
}
