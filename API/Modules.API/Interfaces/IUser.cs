namespace ZFramework.Modules.API.Interfaces
{
    public interface IUser
    {
        string Username { get; set; }

        string PasswordHash { get; set; }
    }
}