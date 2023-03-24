using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrafficPoliceBlazor.Data
{
    // A class which stores MySQL connection values.
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=myserver;" +
                "port=3306;" +
                "database=mydatabase;" +
                "user=myusername;" +
                "password=mypassword"
                ,new MySqlServerVersion(new Version(8, 0, 23)));
        }
    }
}
