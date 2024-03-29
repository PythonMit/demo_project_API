using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using WebApplication1.DTO;
using WebApplication1.Entities;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ApiControllerBase
{
    private readonly IAccountUser _accountUser;

    public AccountController(IAccountUser accountUser)
    {
        _accountUser = accountUser;
    }


    [HttpPost("register{username},{password}")]
    public async Task<IActionResult> RegisterUser(string username ,string password)
    {
        var userData = await UserIsExist(username);
        if (userData==true) {
            return BadRequest("username is alredy take.");
        }
        
        using var hmac = new HMACSHA512();
        var user = new AppUser
        {
            UserName = username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key
        };

        var result = await _accountUser.RegisterUser(user);
        if(result== true)
        {
            return Success(user);
        }
        return Error("user is not register");
        
    }
    [HttpGet]
    public async Task<bool> UserIsExist(string userName)
    {
        var result= await _accountUser.UserIsExist(userName);
        return result;
    }
    [HttpGet("login{username},{password}")]
    public async Task<IActionResult>LoginUser(string username, string password) 
    { 
        var result= await _accountUser.Loginuser(username, password);
        return Success(result);
    }
}
