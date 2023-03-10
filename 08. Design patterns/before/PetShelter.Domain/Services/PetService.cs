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
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IPersonRepository _personRepository;

        public PetService(IPetRepository petRepository, IPersonRepository personRepository)
        {
            _petRepository = petRepository;
            _personRepository = personRepository;
        }

        public async Task AdoptPetAsync(Person adopter, int petId)
        {
            var person = await _personRepository.GetOrAddPersonAsync(adopter.FromDomainModel());
            var adoptedPet = await _petRepository.GetById(petId);
            adoptedPet.Adopter = person;
            adoptedPet.AdopterId = person.Id;
            adoptedPet.IsSheltered = false;
            await _petRepository.Update(adoptedPet);
        }

        public async Task<IReadOnlyCollection<Pet>> GetAllPets()
        {
            var pets = await _petRepository.GetAll();
            return pets.Select(p => p.ToDomainModel())
                .ToImmutableArray();
        }

        public async Task<Pet> GetPet(int petId)
        {
            var pet = await _petRepository.GetById(petId);
            if (pet == null)
            {
                return null;
            }
            pet.Rescuer = await _personRepository.GetById(pet.RescuerId.Value);

            if (pet.AdopterId.HasValue)
            {
                pet.Adopter = await _personRepository.GetById(pet.AdopterId.Value);
            }
            return pet.ToDomainModel();
        }

        public async Task<int> RescuePetAsync(Person rescuer, Pet pet)
        {
            var person = await _personRepository.GetOrAddPersonAsync(rescuer.FromDomainModel());
            var rescuedPet = new DataAccessLayer.Models.Pet
            {
                Birthdate = pet.BirthDate,
                Description = pet.Description,
                ImageUrl = pet.ImageUrl,
                IsHealthy = pet.IsHealthy,
                Name = pet.Name,
                Rescuer = person,
                RescuerId = person.Id,
                Type = pet.Type.ToString(),
                WeightInKg = pet.WeightInKg,
                IsSheltered = true,
            };
            await _petRepository.Add(rescuedPet);
            return rescuedPet.Id;
        }

        public async Task UpdatePetAsync(int petId, PetInfo petInfo)
        {
            var savedPet = await _petRepository.GetById(petId);
            if (savedPet == null)
            {
                throw new NotFoundException($"Pet with id {petId} not found.");
            }

            savedPet.Birthdate = petInfo.BirthDate;
            savedPet.Description = petInfo.Description;
            savedPet.ImageUrl = petInfo.ImageUrl;
            savedPet.IsHealthy = petInfo.IsHealthy;
            savedPet.Name = petInfo.Name;
            await _petRepository.Update(savedPet);
        }
    }
}
