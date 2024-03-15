using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplication1.Entities;

namespace WebApplication1.DbContextConfiguration;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<AppUser> users { get; set; }
    public DbSet<userLoginInfo> userLoginInfos { get; set; }
}
