namespace ZFramework.Data.Abstract.Services
{
    public interface IModifyDataService<TEditModel> where TEditModel : class
    {
        void SaveChanges(TEditModel entity);
    }
}