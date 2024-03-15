using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.DbContextConfiguration;
using WebApplication1.Entities;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class userLoginController : ControllerBase
{
    public IConfiguration _configuration { get; set; }
    readonly private DataContext _dataContext;
    public userLoginController(IConfiguration configuration,DataContext dataContext) {
        _dataContext=dataContext;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> Post(userLoginInfo userLoginInfo)
    {
        
        if (userLoginInfo != null && userLoginInfo.UserEmail!=null && userLoginInfo != null)
        {
           var userResult = await _dataContext.userLoginInfos.FirstOrDefaultAsync(x => x.UserEmail == userLoginInfo.UserEmail && x.password==userLoginInfo.password);
            if (userResult != null)
            {
                //create claims details based on the user information
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", userResult.Id.ToString()),
                        new Claim("UserEmail",userResult.UserEmail)                        
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }
        else
        {
            return BadRequest();
        }
    }
}
