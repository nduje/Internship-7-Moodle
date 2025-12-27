using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Users;

namespace Moodle.Domain.Persistence.Users
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User?> GetById(int id);
        Task<bool> EmailExists(string email);
        Task<User?> GetByEmail(string email);
    }
}
