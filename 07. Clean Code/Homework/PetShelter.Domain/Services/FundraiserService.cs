using PetShelter.DataAccessLayer.Repository;
using PetShelter.Domain.Exceptions;
using PetShelter.Domain.Extensions.DataAccess;
using PetShelter.Domain.Extensions.DomainModel;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain.Services
{
    public class FundraiserService : IFundraiserService
    {
        private readonly IFundraiserRepository _fundraiserRepository;
        private readonly IPersonRepository _personRepository;

        public FundraiserService(IFundraiserRepository fundraiserRepository, IPersonRepository personRepository)
        {
            _fundraiserRepository = fundraiserRepository;
            _personRepository = personRepository;
        }

        public async Task<Fundraiser> GetFundraiser(int fundraiserId)
        {
            var fundraiser = await _fundraiserRepository.GetById(fundraiserId);
            if (fundraiser == null)
            {
                return null;
            }

            return fundraiser.ToDomainModel();
        }

        public async Task<IReadOnlyCollection<Fundraiser>> GetAllFundraisers()
        {
            var fundraisers = await _fundraiserRepository.GetAll();
            return fundraisers.Select(p => p.ToDomainModel())
                .ToImmutableArray();
        }

        public async Task UpdateFundraiserAsync(int fundraiserId, Fundraiser fundraiser)
        {
            var fundraiserToUpdate = await _fundraiserRepository.GetById(fundraiserId);
            if (fundraiser == null)
            {
                throw new NotFoundException($"Fundraiser with id {fundraiserId} not found.");
            }

            fundraiserToUpdate.GoalValue = fundraiser.GoalValue;
            fundraiserToUpdate.Description = fundraiser.Description;
            fundraiserToUpdate.DueDate = fundraiser.DueDate;
            //fundraiserToUpdate.Owner = fundraiser.Owner.FromDomainModel();
            fundraiserToUpdate.Name = fundraiser.Name;
            fundraiserToUpdate.Status = fundraiser.Status;
            fundraiserToUpdate.CurrentDonation = fundraiser.CurrentDonation;
            fundraiserToUpdate.CreationDate = fundraiser.CreationDate;
            await _fundraiserRepository.Update(fundraiserToUpdate);
        }

        public async Task<int> CreateFundraiserAsync(Person owner, Fundraiser fundraiser)
        {
            var person = await _personRepository.GetOrAddPersonAsync(owner.FromDomainModel());
            var newFundraiser = new DataAccessLayer.Models.Fundraiser
            {
                Name = fundraiser.Name,
                Description = fundraiser.Description,
                Status = fundraiser.Status,
                CreationDate = fundraiser.CreationDate,
                DueDate = fundraiser.DueDate,
                CurrentDonation = fundraiser.CurrentDonation,
                GoalValue = fundraiser.GoalValue,
                Owner = fundraiser.Owner.FromDomainModel(),
                OwnerId = person.Id
            };
            await _fundraiserRepository.Add(newFundraiser);
            return newFundraiser.Id;
        }
    }
}
