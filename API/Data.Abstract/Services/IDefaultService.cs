using ZFramework.Data.Abstract.Interfaces;

namespace ZFramework.Data.Abstract.Services
{
    public interface IDefaultService<TEntity> : IDeleteService<TEntity>, IListService<TEntity>, IModifyService<TEntity> where TEntity : class, IEntity
    {
    }
}