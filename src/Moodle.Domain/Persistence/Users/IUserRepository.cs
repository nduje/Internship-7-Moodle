using Moodle.Domain.Persistence.Common;
using Moodle.Domain.Entities.Users;
using Moodle.Domain.Enumerations.Users;

namespace Moodle.Domain.Persistence.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User?> GetById(Guid id);
        Task<User?> GetByEmail(string email);
        Task<IReadOnlyList<User>> GetByRole(UserRole? role);
        Task<IReadOnlyList<User>> GetByIds(IEnumerable<Guid> ids);
        Task<IReadOnlyList<User>> GetAllUsers();
    }
}
