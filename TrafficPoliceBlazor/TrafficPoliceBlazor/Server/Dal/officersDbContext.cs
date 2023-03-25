using Microsoft.EntityFrameworkCore;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Dal
{
    public class officersDbContext : DbContext
    {
        public officersDbContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<officers> officers { get; set; }

    }
}
