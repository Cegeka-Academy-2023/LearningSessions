using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer.Configuration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        //Primary key
        builder.HasKey(p => p.Id);

        //Columns mapping and constraints
        builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
        builder.Property(p => p.IsHealthy).IsRequired().HasDefaultValue(true);
        builder.Property(p => p.IsSheltered).IsRequired().HasDefaultValue(true);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(5000);
        builder.Property(p => p.ImageUrl).IsRequired().HasMaxLength(300);
        builder.Property(p => p.Birthdate).IsRequired();
        builder.Property(p => p.Type).IsRequired().HasMaxLength(250);

        //Relationships
        builder.HasOne(p => p.Rescuer).WithMany(p => p.RescuedPets).HasForeignKey(p => p.RescuerId)
            .IsRequired(false);

        builder.HasOne(p => p.Adopter).WithMany(p => p.AdoptedPets).HasForeignKey(p => p.AdopterId)
            .IsRequired(false);
    }
}