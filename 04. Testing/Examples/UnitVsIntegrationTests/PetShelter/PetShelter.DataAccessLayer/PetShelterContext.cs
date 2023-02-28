using Microsoft.EntityFrameworkCore;
using PetShelter.DataAccessLayer.Configuration;
using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer;

public class PetShelterContext : DbContext
{
    public PetShelterContext()
    {
    }

    public PetShelterContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Pet> Pets { get; set; }
    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<Donation> Donations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PetConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new DonationConfiguration());
    }
}