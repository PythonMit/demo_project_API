using WebApplication1.Entities;

namespace WebApplication1.Interface;

public interface IAppUser
{
    public List<AppUser> GetUserdata();
    public AppUser GetUserById(int id);
}
