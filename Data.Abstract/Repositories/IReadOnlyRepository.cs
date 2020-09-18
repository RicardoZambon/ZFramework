using System.Linq;
using ZFramework.Data.Abstract.Interfaces;

namespace ZFramework.Data.Abstract.Repositories
{
    public partial interface IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetObject(params object[] keyValues);

        IQueryable<TEntity> GetQuery();
    }
}