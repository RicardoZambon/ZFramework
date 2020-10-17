namespace ZFramework.Data.Abstract.Services
{
    public interface IDeleteService
    {
        void Delete(params object[] keyValues);
    }
}