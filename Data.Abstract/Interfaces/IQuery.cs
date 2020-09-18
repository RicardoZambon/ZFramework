using System.Linq;

namespace ZFramework.Data.Abstract.Interfaces
{
    public interface IQuery<TEntity> where TEntity : class
    {
        IQueryable<TEntity> List();

        TEntity FindByID(int id);
    }
}