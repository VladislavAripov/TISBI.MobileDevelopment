using App.Dal;
using Microsoft.EntityFrameworkCore;

namespace App.Web;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<UserVisit> UserVisits { get; set; }
}