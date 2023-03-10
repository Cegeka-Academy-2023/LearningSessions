using PetShelter.DataAccessLayer.Repository;
using PetShelter.Domain.Exceptions;
using PetShelter.Domain.Extensions.DataAccess;
using PetShelter.Domain.Extensions.DomainModel;
using System.Collections.Immutable;
using PetShelter.Domain.Adapters;

namespace PetShelter.Domain.Services;

public class PetService : IPetService
{
    private readonly IPetRepository petRepository;
    private readonly IPersonRepository personRepository;

    public PetService(IPetRepository petRepository, IPersonRepository personRepository)
    {
        this.petRepository = petRepository;
        this.personRepository = personRepository;
    }

    public async Task AdoptPetAsync(Person adopter, int petId)
    {
        var person = await personRepository.GetOrAddPersonAsync(adopter.FromDomainModel());
        var adoptedPet = await petRepository.GetById(petId);
        adoptedPet.Adopter = person;
        adoptedPet.AdopterId = person.Id;
        adoptedPet.IsSheltered = false;
        await petRepository.Update(adoptedPet);
    }

    public async Task<IReadOnlyCollection<Pet>> GetAllPets()
    {
        var pets = await petRepository.GetAll();
        return pets.Select(p => p.ToDomainModel())
            .ToImmutableArray();
    }

    public async Task<Pet> GetPet(int petId)
    {
        var pet = await petRepository.GetById(petId);
        if (pet == null)
        {
            return null;
        }
        pet.Rescuer = await personRepository.GetById(pet.RescuerId.Value);

        if (pet.AdopterId.HasValue)
        {
            pet.Adopter = await personRepository.GetById(pet.AdopterId.Value);
        }

        DataLayerPetAdapter adapter = new DataLayerPetAdapter(pet);
        return adapter.GetDomainPet();
    }

    public async Task<int> RescuePetAsync(Person rescuer, Pet pet)
    {
        var person = await personRepository.GetOrAddPersonAsync(rescuer.FromDomainModel());
        var rescuedPet = new DataAccessLayer.Models.Pet
        {
            Birthdate = pet.BirthDate,
            Description = pet.Description,
            ImageUrl = pet.ImageUrl,
            IsHealthy = pet.IsHealthy,
            Name = pet.Name,
            Rescuer = person,
            RescuerId = person.Id,
            WeightInKg = pet.WeightInKg,
            IsSheltered = true,
        };
        await petRepository.Add(rescuedPet);
        return rescuedPet.Id;
    }

    public async Task UpdatePetAsync(int petId, PetInfo petInfo)
    {
        var savedPet = await petRepository.GetById(petId);
        if (savedPet == null)
        {
            throw new NotFoundException($"Pet with id {petId} not found.");
        }

        savedPet.Birthdate = petInfo.BirthDate;
        savedPet.Description = petInfo.Description;
        savedPet.ImageUrl = petInfo.ImageUrl;
        savedPet.IsHealthy = petInfo.IsHealthy;
        savedPet.Name = petInfo.Name;
        await petRepository.Update(savedPet);
    }
}

