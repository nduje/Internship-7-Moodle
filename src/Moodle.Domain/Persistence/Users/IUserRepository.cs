using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Users;
using Moodle.Domain.Enumerations.Users;

namespace Moodle.Domain.Persistence.Users
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User?> GetById(Guid id);
        Task<User?> GetByEmail(string email);
        Task<IReadOnlyList<User>> GetByRole(UserRole? role);
    }
}
