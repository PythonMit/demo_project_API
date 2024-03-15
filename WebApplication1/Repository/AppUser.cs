
using WebApplication1.DbContextConfiguration;
using WebApplication1.Entities;
using WebApplication1.Interface;

namespace WebApplication1.Repository;

public class AppUser : IAppUser
{
    private readonly DataContext _dataContext;
    public AppUser(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Entities.AppUser GetUserById(int id)
    {
        try
        {
           var userResult= _dataContext.users.Find(id);
            if (userResult !=null)
            {
                return userResult;
            }
            else
            {
                throw new Exception();
            }
        }
        catch (Exception)
        {

            throw new NotImplementedException();
        }
        
    }

    List<Entities.AppUser> IAppUser.GetUserdata()
    {
        try
        {
            return _dataContext.users.ToList();
        }
        catch (Exception)
        {

            throw new NotImplementedException();
        }

       
    }
}
