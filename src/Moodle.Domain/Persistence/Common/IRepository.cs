using Moodle.Domain.Common.Model;

namespace Moodle.Domain.Persistence.Common
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        Task<GetAllResponse<TEntity>> Get();
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void Delete(TEntity? entity);
    }
}
