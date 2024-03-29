using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebApplication1.DbContextConfiguration;
using WebApplication1.Entities;
using WebApplication1.Interface;

namespace WebApplication1.Repository;

public class AccountUser:IAccountUser
{
    private readonly DataContext _context;

    public AccountUser(DataContext context)
    {
        _context = context;
    }

    public async Task<Entities.AppUser> Loginuser(string userName, string password)
    {
        var user = await _context.users.FirstOrDefaultAsync(x => x.UserName == userName);
        if (user != null)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for(var i=0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != user.PasswordHash[i])
                    return null;
            }
        }
        return user;
       // throw new NotImplementedException();
    }

    public async Task<bool> RegisterUser(Entities.AppUser appUser)
    {

        var result = await _context.AddAsync(appUser);
        await _context.SaveChangesAsync();
        return true;
       // throw new NotImplementedException();
    }
   

    public async Task<bool> UserIsExist(string userName)
    {
        var data= await _context.users.AnyAsync(x => x.UserName == userName);
        if (data)
        {
            return true;
        }
        return false;
    }
}
