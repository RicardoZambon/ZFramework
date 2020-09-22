using ZFramework.Data.Abstract.Interfaces;

namespace ZFramework.Data.Abstract.Services
{
    public interface IDefaultDataService<TEntity> : IDeleteService<TEntity>, IListService<TEntity>, IModifyDataService<TEntity> where TEntity : class, IEntity
    {
    }
}