using Moodle.Domain.Entities.Users;
using Moodle.Domain.Persistence.Users;
using Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Moodle.Infrastructure.Repositories.Users
{
    internal sealed class UserRepository : Repository<User, int>, IUserRepository
    {
    }
}
