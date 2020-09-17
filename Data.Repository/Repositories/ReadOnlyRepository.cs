using System.Linq;
using ZFramework.Data.Repository.Database;
using ZFramework.Data.Repository.Interfaces;

namespace ZFramework.Data.Repository.Repositories
{
    public abstract class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        private readonly RepoContext DbContext;

        public ReadOnlyRepository(RepoContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public TEntity GetObject(params object[] keyValues)
            => DbContext.Find<TEntity>(keyValues);

        public IQueryable<TEntity> GetQuery()
            => DbContext.Set<TEntity>().AsQueryable();
    }
}
