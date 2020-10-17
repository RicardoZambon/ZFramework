namespace ZFramework.Modules.API.Interfaces
{
    public interface IUserAccount
    {
        string Username { get; set; }

        string PasswordHash { get; set; }
        
        bool IsActive { get; set; }
    }
}