using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShelter.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.DataAccessLayer.Configuration
{
    public class FundraiserConfiguration : IEntityTypeConfiguration<Fundraiser>
    {
        public void Configure(EntityTypeBuilder<Fundraiser> builder)
        {
            //Primary key
            builder.HasKey(p => p.Id);

            //Columns mapping and constraints
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Status).IsRequired().HasDefaultValue(true);
            builder.Property(p => p.GoalValue).IsRequired();
            builder.Property(p => p.CurrentDonation).IsRequired();
            builder.Property(p => p.DueDate).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(255);

            builder.HasOne(p => p.Owner).WithMany(p => p.Fundraisers).HasForeignKey(p => p.OwnerId)
            .IsRequired(false);

        }

    }
}
