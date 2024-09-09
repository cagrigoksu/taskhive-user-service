namespace TaskHive_UserService.Services.Interfaces
{
    public interface ISecurityService
    {
        string GenerateSalt();
        string Hasher(string pwd, string salt, int iter);
    }
}
