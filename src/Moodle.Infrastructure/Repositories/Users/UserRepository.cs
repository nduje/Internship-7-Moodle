using Moodle.Domain.Entities.Users;
using Moodle.Domain.Persistence.Users;
using Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Moodle.Infrastructure.Repositories.Common;
using Moodle.Domain.Enumerations.Users;

namespace Moodle.Infrastructure.Repositories.Users
{
    internal sealed class UserRepository : Repository<User, Guid>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IReadOnlyList<User>> GetByRole(UserRole? role)
        {
            return await _dbContext.Users
                .Where(u => u.Role == role)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<User>> GetByIds(IEnumerable<Guid> ids)
        {
            return await _dbContext.Users
                .Where(u => ids.Contains(u.Id))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}   
