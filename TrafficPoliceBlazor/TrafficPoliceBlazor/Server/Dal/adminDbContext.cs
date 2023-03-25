using Microsoft.EntityFrameworkCore;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Dal
{
    public class adminDbContext : DbContext
    {

        public adminDbContext(DbContextOptions<adminDbContext> options) : base(options)
        { 
        }

        public DbSet<admins> admins { get; set; }

    }
}
