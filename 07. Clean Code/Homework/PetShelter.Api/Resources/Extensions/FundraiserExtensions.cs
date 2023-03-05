using PetShelter.Domain;

namespace PetShelter.Api.Resources.Extensions
{
    public static class FundraiserExtensions
    {
        public static Domain.Fundraiser AsFundraiserInfo(this Fundraiser fundraiser)
        {
            return new Domain.Fundraiser
            {
                Name = fundraiser.Name,
                Description = fundraiser.Description,
                DueDate = fundraiser.DueDate,
                CreationDate = fundraiser.CreationDate,
                GoalValue = fundraiser.GoalValue,
                Status = fundraiser.Status,
                CurrentDonation = fundraiser.CurrentDonation,

            };
        }

        public static Domain.Fundraiser AsDomainModel(this CreatorOfFundraiser fundraiser)
        {
            if (fundraiser == null)
            {
                return null;
            }

            var domainModel = new Domain.Fundraiser();
            domainModel.Name = fundraiser.Name;
            domainModel.Description = fundraiser.Description;
            domainModel.DueDate = fundraiser.DueDate;
            domainModel.Owner = fundraiser.Owner.AsDomainModel();
            domainModel.GoalValue = fundraiser.GoalValue;
            domainModel.CreationDate = fundraiser.CreationDate;
            domainModel.CurrentDonation = fundraiser.CurrentDonation;
            domainModel.Status = fundraiser.Status;

            return domainModel;
        }

        public static IdentifiableFundraiser AsResource(this Domain.Fundraiser fundraiser)
        {
            return new IdentifiableFundraiser
            {
                Name = fundraiser.Name,
                Description = fundraiser.Description,
                DueDate = fundraiser.DueDate,
                CreationDate = fundraiser.CreationDate,
                GoalValue = fundraiser.GoalValue,
                Status = fundraiser.Status,
                CurrentDonation = fundraiser.CurrentDonation,
                Owner = fundraiser.Owner?.AsResource()
            };
        }
    }
}
