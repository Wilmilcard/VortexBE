using VortexBE.Domain.Models;
using VortexBE.Domain.Repository;
using VortexBE.Interfaces;

namespace VortexBE.Services
{
    public class EntradaServices : BaseRepository<Entrada>, IEntradaServices
    {
        public EntradaServices(IRepository<Entrada> repository) : base(repository)
        {
        }
    }
}
