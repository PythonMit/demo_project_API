using WebApplication1.Entities;

namespace WebApplication1.Interface;

public interface IAccountUser
{
    Task<bool> RegisterUser(AppUser appUser);
    Task<bool> UserIsExist(string userName);
    Task<AppUser> Loginuser(string userName,string password);
}
