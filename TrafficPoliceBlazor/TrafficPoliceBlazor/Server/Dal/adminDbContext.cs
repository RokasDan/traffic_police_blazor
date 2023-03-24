using Microsoft.EntityFrameworkCore;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Dal
{
    public class adminDbContext : DbContext
    {

        public adminDbContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<admins> loginDetails { get; set; }

    }
}
