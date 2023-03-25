using Microsoft.EntityFrameworkCore;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Dal
{
    public class offenceDbContext : DbContext
    {
        public offenceDbContext(DbContextOptions<offenceDbContext> options) : base(options) 
        {
        }
        public DbSet<offence> offence { get; set; }
    }
}
