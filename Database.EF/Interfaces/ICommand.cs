namespace ZFramework.Data.Db.Interfaces
{
    public interface ICommand<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}