using System.Linq;
using System.Threading.Tasks;
using ZFramework.Data.Abstract.Interfaces;
using ZFramework.Data.Abstract.Repositories;

namespace ZFramework.Data.EfCore.Repositories
{
    public abstract class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly ZDbContext DbContext;

        protected EfRepository(ZDbContext dbContext)
        {
            DbContext = dbContext;
        }


        public virtual void Delete(TEntity entity)
        {
            //TODO, check if implements interface for SoftDelete
        }

        public virtual TEntity FindByKey(params object[] keyValues)
            => DbContext.Find<TEntity>(keyValues);

        public virtual void Insert(TEntity entity)
        {
            DbContext.Add(entity);

            if (DbContext.Database.CurrentTransaction == null)
            {
                DbContext.SaveChanges();
            }
        }

        public virtual IQueryable<TEntity> List()
            => DbContext.Set<TEntity>().AsQueryable();

        public virtual void Update(TEntity entity)
        {
            DbContext.Update(entity);

            if (DbContext.Database.CurrentTransaction == null)
            {
                DbContext.SaveChanges();
            }
        }
    }
}