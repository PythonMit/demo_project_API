using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContextConfiguration;
using WebApplication1.Entities;
using WebApplication1.Interface;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    //public IConfiguration Configuration { get; set; }
    //readonly private DataContext _dataContext;
    //public UserController(DataContext dataContext)
    //{
    //    _dataContext = dataContext;
    //}
    private readonly IAppUser _appUser;
    public UserController(IAppUser appUser)
    {

        _appUser = appUser;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetAllUser()
    {
        return await Task.FromResult(_appUser.GetUserdata());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetUserById(int id)
    {
        var result=await Task.FromResult(_appUser.GetUserById(id));
       return Ok(result);
    }
}
