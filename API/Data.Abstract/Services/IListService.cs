using System.Linq;
using ZFramework.Data.Abstract.Interfaces;

namespace ZFramework.Data.Abstract.Services
{
    public interface IListService<TEntity> where TEntity : class, IEntity
    {
        TEntity Find(params object[] keyValues);

        IQueryable<TEntity> List();
    }
}