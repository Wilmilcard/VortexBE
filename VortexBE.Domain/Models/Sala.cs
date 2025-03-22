using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VortexBE.Domain.Models
{
    [Table("Sala")]
    public class Sala
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("SalaId")]
        public int SalaId { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public int Capacidad { get; set; }

        //Foreigns
        [ForeignKey("CineId")]
        public int CineId { get; set; }
        public virtual Cine Cine { get; set; }
    }
}
