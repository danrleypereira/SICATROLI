using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Models;
namespace backend.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Guardian> Guardian { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Categories { get; set; }

        // With this approach, you no longer need to hard-code the connection string in the OnConfiguring method, and you can easily switch between different database providers and connection strings just by modifying the appsettings.json file.
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //     => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=postgres;Username=postgres;Password=changeme");
    }
}
