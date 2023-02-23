using Microsoft.EntityFrameworkCore;
using PetShelter.DataAccessLayer.Configuration;
using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer;

public class PetShelterContext : DbContext
{
    public PetShelterContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Pet> Pets { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Donation> Donations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PetConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new DonationConfiguration());
    }
}