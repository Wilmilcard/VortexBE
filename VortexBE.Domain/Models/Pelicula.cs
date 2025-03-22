using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexBE.Domain.Models
{
    [Table("Pelicula")]
    public class Pelicula : Auditory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("PeliculaId")]
        public int PeliculaId { get; set; }

        [Required]
        [StringLength(150)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(1000)]
        public string Descripcion { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "La duración debe estar entre 1 y 500 minutos.")]
        public int Duracion { get; set; } // Minutos

        [Required]
        [StringLength(50)]
        public string Genero { get; set; }

        [Required]
        [StringLength(100)]
        public string Director { get; set; }

        [Required]
        [StringLength(10)]
        public string Clasificacion { get; set; } // Ejemplo: PG, R, G

        [Required]
        [StringLength(255)]
        public string PosterUrl { get; set; }

        [Required]
        public DateTime FechaEstreno { get; set; }

        //virtual
        public virtual List<Funcion> Funciones { get; set; }
    }
}
