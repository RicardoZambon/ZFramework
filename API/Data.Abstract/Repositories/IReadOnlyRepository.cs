using System.Linq;
using ZFramework.Data.Abstract.Interfaces;

namespace ZFramework.Data.Abstract.Repositories
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity FindByKey(params object[] keyValues);

        IQueryable<TEntity> List();
    }
}