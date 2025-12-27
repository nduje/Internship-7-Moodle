using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Users;

namespace Moodle.Domain.Persistence.Users
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User?> GetById(Guid id);
        Task<User?> GetByEmail(string email);
    }
}
