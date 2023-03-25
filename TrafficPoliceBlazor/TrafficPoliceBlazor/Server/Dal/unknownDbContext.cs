using Microsoft.EntityFrameworkCore;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Dal
{
    public class unknownDbContext : DbContext
    {
        public unknownDbContext(DbContextOptions<unknownDbContext> options) : base(options) 
        {
        }

        public DbSet<unknown> unknown { get; set; }
    }
}
