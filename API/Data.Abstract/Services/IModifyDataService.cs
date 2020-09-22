using ZFramework.Data.Abstract.Interfaces;

namespace ZFramework.Data.Abstract.Services
{
    public interface IModifyDataService<TEntity> where TEntity : class, IEntity
    {
        void SaveChanges(TEntity entity);
    }
}