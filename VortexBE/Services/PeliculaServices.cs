using VortexBE.Domain.Models;
using VortexBE.Domain.Repository;
using VortexBE.Interfaces;

namespace VortexBE.Services
{
    public class PeliculaServices : BaseRepository<Pelicula>, IPeliculaServices
    {
        public PeliculaServices(IRepository<Pelicula> repository) : base(repository)
        {
        }
    }
}
