using System;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Country> Countries { set; get; }
        public DbSet<Person> Persons { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Person>().ToTable("Persons");
        }
    }
}

