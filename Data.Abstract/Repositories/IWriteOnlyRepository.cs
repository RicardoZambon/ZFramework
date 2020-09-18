using ZFramework.Data.Abstract.Interfaces;

namespace ZFramework.Data.Abstract.Repositories
{
    public partial interface IWriteOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}