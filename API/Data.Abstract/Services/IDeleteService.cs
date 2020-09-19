using ZFramework.Data.Abstract.Interfaces;

namespace ZFramework.Data.Abstract.Services
{
    public interface IDeleteService<TEntity> where TEntity : class, IEntity
    {
        void Delete(params object[] keyValues);
    }
}