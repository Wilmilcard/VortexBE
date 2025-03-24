namespace VortexBE.HttpRequest
{
    public class FilterMoviesRequest
    {
        public int? CineId { get; set; }
        public string? DireccionCine { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Genero { get; set; }
        public string? Director { get; set; }
        public DateTime? FechaFuncionInicio { get; set; }
        public DateTime? FechaFuncionFin { get; set; }
    }
}
