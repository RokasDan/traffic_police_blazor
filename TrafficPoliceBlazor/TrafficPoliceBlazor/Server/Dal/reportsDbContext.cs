using Microsoft.EntityFrameworkCore;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Dal
{
    public class reportsDbContext : DbContext
    {
        public reportsDbContext(DbContextOptions<reportsDbContext> options) : base(options) 
        {
        }

        public DbSet<reports> reports { get; set; }
    }
}
