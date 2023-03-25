using Microsoft.EntityFrameworkCore;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Dal
{
    public class carsDbContext : DbContext
    {

        public carsDbContext(DbContextOptions<carsDbContext> options) : base(options) 
        { 
        }

        public DbSet<cars> cars { get; set; }
    }

}
