using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain.Extensions.DomainModel
{
    internal static class FundraiserExtensions
    {
        public static Fundraiser? ToDomainModel(this DataAccessLayer.Models.Fundraiser fundraiser)
        {
            if (fundraiser == null)
            {
                return null;
            }

            var domainModel = new Fundraiser();
            domainModel.Name = fundraiser.Name;
            domainModel.Description = fundraiser.Description;
            domainModel.DueDate = fundraiser.DueDate;
            domainModel.Owner = fundraiser.Owner.ToDomainModel();
            domainModel.GoalValue = fundraiser.GoalValue;
            domainModel.CreationDate = fundraiser.CreationDate;
            domainModel.CurrentDonation = fundraiser.CurrentDonation;
            domainModel.Status= fundraiser.Status;
            
            return domainModel;
        }
    }
}
