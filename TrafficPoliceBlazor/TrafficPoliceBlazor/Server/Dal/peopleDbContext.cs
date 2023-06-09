﻿using Microsoft.EntityFrameworkCore;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Dal
{
    public class peopleDbContext : DbContext
    {
        public peopleDbContext(DbContextOptions<peopleDbContext> options) : base(options)
        {
        }

        public DbSet<people> people { get; set; }
    }
}
