using ZFramework.Data.Abstract.Interfaces;

namespace ZFramework.Data.Abstract.Repositories
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        void Delete(TEntity entity);

        void Insert(TEntity entity);

        void Update(TEntity entity);
    }
}