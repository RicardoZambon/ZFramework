using System.Linq;

namespace ZFramework.Data.Db.Interfaces
{
    public interface IQuery<TEntity> where TEntity : class
    {
        IQueryable<TEntity> List();

        TEntity FindByID(int id);
    }
}