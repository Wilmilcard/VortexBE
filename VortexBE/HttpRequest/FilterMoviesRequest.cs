namespace VortexBE.HttpRequest
{
    public class FilterMoviesRequest
    {
        public int? CineId { get; set; }
        public int? PeliculaId { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaFuncionInicio { get; set; }
        public DateTime? FechaFuncionFin { get; set; }
    }
}
