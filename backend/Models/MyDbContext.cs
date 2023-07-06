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
        public MyDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institution>()
                .HasMany(inst => inst.Guardians)
                .WithOne(guard => guard.Institution)
                .HasPrincipalKey(inst => inst.Id)
                .OnDelete(DeleteBehavior.Cascade);
            
            // modelBuilder.Entity<Guardian>()
            //     .HasOne(guard => guard.Institution)
            //     .WithMany(inst => inst.Guardians)
            //     .HasForeignKey(guard => guard.Institution)
            //     .HasConstraintName("FK_guardian_institution_institution_id")
            //     .OnDelete(DeleteBehavior.NoAction);
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Guardian> guardians { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Categories { get; set; }

        // With this approach, you no longer need to hard-code the connection string in the OnConfiguring method, and you can easily switch between different database providers and connection strings just by modifying the appsettings.json file.
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //     => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=postgres;Username=postgres;Password=changeme");
    }
}
