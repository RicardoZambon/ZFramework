using System.Linq;

namespace ZFramework.Data.Repository.Interfaces
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity GetObject(params object[] keyValues);

        IQueryable<TEntity> GetQuery();
    }
}