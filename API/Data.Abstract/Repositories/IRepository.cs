using System.Linq;
using ZFramework.Data.Abstract.Interfaces;

namespace ZFramework.Data.Abstract.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        void Delete(TEntity entity);

        TEntity FindByKey(params object[] keyValues);

        IQueryable<TEntity> List();

        void Insert(TEntity entity);

        void Update(TEntity entity);
    }
}