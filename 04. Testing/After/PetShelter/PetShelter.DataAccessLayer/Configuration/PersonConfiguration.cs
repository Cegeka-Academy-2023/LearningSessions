using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer.Configuration;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        //Primary key
        builder.HasKey(p => p.Id);

        //Columns mapping and constraints
        builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
        builder.Property(p => p.IdNumber).HasMaxLength(50).IsRequired();
    }
}