using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer.Configuration;

public class DonationConfiguration : IEntityTypeConfiguration<Donation>
{
    public void Configure(EntityTypeBuilder<Donation> builder)
    {
        //Primary key
        builder.HasKey(p => p.Id);

        //Columns mapping and constraints
        builder.Property(p => p.Amount).IsRequired();
        builder.Property(p => p.DonorId).IsRequired();

        //Relationships
        builder.HasOne(p => p.Donor).WithMany(p => p.Donations).HasForeignKey(p => p.DonorId)
            .IsRequired();
    }
}