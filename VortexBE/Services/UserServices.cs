using VortexBE.Domain.Models;
using VortexBE.Domain.Repository;

namespace VortexBE.Services
{
    public class UserServices : BaseRepository<User>, IUserServices
    {
        public UserServices(IRepository<User> repository) : base(repository)
        {
        }
    }
}
