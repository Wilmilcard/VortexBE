using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VortexBE.Domain.Models;

namespace VortexBE.HttpRequest
{
    public class PeliculaCreateUpdate
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }
        public string Genero { get; set; }
        public string Director { get; set; }
        public string Clasificacion { get; set; }
        public string PosterUrl { get; set; }
        public DateTime FechaEstreno { get; set; }
        public bool Activo { get; set; }

        public virtual List<int> FuncionesId { get; set; }
    }
}
